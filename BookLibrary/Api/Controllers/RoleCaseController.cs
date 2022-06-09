using Application;
using Application.Commands.RoleCases;
using Application.Dto.RoleCase;
using Application.Queries.RoleCases;
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
    public class RoleCaseController : ControllerBase
    {
        private readonly UseCaseExecutor _useCaseExecutor;
        private readonly IMapper _mapper;

        public RoleCaseController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        // GET api/<RoleCaseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetCasesByRoleIdQuery query)
        {
            IEnumerable<int> useCaseIds = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(useCaseIds);
        }

        // POST api/<RoleCaseController>
        [HttpPost]
        public IActionResult Post([FromBody] RoleCaseDto dto
            , [FromServices] IAddRoleCaseCommand command
            , [FromServices] AddRoleCaseValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                RoleUserCase applicationUserCase = _mapper.Map<RoleCaseDto, RoleUserCase>(dto);
                _useCaseExecutor.ExecuteCommand(command, applicationUserCase);
                return Ok("Role use case created successfully.");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // DELETE api/<RoleCaseController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] RoleCaseDto dto
            , [FromServices] RemoveRoleCaseValidator validator
            , [FromServices] IGetOneRoleCaseQuery query
            , [FromServices] IRemoveRoleCaseCommand command)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                RoleUserCase roleCase = _useCaseExecutor.ExecuteQuery(query, dto);
                _useCaseExecutor.ExecuteCommand(command, roleCase);
                return Ok("Role use case removed successfully.");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }
    }
}