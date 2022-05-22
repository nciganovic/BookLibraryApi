﻿using Application.Commands.MembershipCommands;
using Application;
using Application.Dto;
using AutoMapper;
using Domain;
using Implementation.ResponseMessages;
using Implementation.Validator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly UseCaseExecutor _useCaseExecutor;
        private readonly IMapper _mapper;

        public MembershipController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        // POST api/<MembershipController>
        [HttpPost]
        public IActionResult Post([FromBody] AddMembershipDto dto
            , [FromServices] IAddMembershipCommand command
            , [FromServices] AddMembershipValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Membership membership = _mapper.Map<Membership>(dto);
                _useCaseExecutor.ExecuteCommand(command, membership);
                return Ok("Membership added successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ChangeMembershipDto dto
            , [FromServices] IChangeMembershipCommand command
            , [FromServices] ChangeMembershipValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Membership membership = _mapper.Map<Membership>(dto);
                _useCaseExecutor.ExecuteCommand(command, membership);
                return Ok("Membership changed successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveMembershipCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Ok("Membership removed successfully.");
        }
    }
}
