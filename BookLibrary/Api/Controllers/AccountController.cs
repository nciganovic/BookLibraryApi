using Api.Core;
using Application;
using Application.Commands.Account;
using Application.Dto.Account;
using Application.Dto.User;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Implementation.ResponseMessages;
using Implementation.Validator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtManager _manager;
        private readonly IMapper _mapper;
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public AccountController(JwtManager manager
            , IMapper mapper
            , UseCaseExecutor executor
            , IApplicationActor actor)
        {
            _manager = manager;
            _mapper = mapper;
            _executor = executor;
            _actor = actor;
        }

        // POST api/<AccountController>
        [HttpPost("[action]")]
        public IActionResult Login([FromBody] LoginDto dto
            , [FromServices] LoginValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                string token = _manager.MakeToken(dto.Email);
                return Ok(new { token });
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // PUT api/<AccountController>/5
        [HttpPost("[action]")]
        public IActionResult Register([FromBody] RegisterDto dto
            , [FromServices] IRegisterCommand command
            , [FromServices] RegisterValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                User user = _mapper.Map<User>(dto);
                _executor.ExecuteCommand(command, user);
                return Ok("User created successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [Authorize]
        [HttpPatch("[action]")]
        public IActionResult ChangeProfile([FromBody] ChangeProfileDto dto
            , [FromServices] IChangeProfileCommand command
            , [FromServices] ChangeProfileValidator validator)
        {
            dto.Id = _actor.Id;
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                User user = _mapper.Map<User>(dto);
                _executor.ExecuteCommand(command, user);
                return Ok("User changed successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }
    }
}
