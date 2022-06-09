using Application;
using Application.Commands.Users;
using Application.Dto.User;
using Application.Queries.Users;
using Application.Searches;
using AutoMapper;
using Domain;
using Implementation.ResponseMessages;
using Implementation.Validator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public UserController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneUserQuery query)
        {
            UserResultDto result = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetByEmail([FromBody] object email, [FromServices] IGetUserByEmailQuery query)
        {
            UserResultDto result = _useCaseExecutor.ExecuteQuery(query, email.ToString());
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get([FromBody] UserSearch search,
              [FromServices] IGetUsersQuery query)
        {
            IEnumerable<UserResultDto> result = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddUserDto dto
            , [FromServices] IAddUserCommand command
            , [FromServices] AddUserValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                User User = _mapper.Map<User>(dto);
                _useCaseExecutor.ExecuteCommand(command, User);
                return Ok("User added successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ChangeUserDto dto
            , [FromServices] IChangeUserCommand command
            , [FromServices] ChangeUserValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                User User = _mapper.Map<User>(dto);
                _useCaseExecutor.ExecuteCommand(command, User);
                return Ok("User changed successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveUserCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Ok("User removed successfully.");
        }
    }
}
