using Application;
using Application.Commands.Roles;
using Application.Dto.Role;
using Application.Queries.Roles;
using Application.Searches;
using AutoMapper;
using Domain;
using Implementation.ResponseMessages;
using Implementation.Validator;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public RoleController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneRoleQuery query)
        {
            RoleResultDto result = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get([FromBody] RoleSearch search,
              [FromServices] IGetRolesQuery query)
        {
            IEnumerable<RoleResultDto> result = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddRoleDto dto
            , [FromServices] IAddRoleCommand command
            , [FromServices] AddRoleValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Role role = _mapper.Map<Role>(dto);
                _useCaseExecutor.ExecuteCommand(command, role);
                return Ok("Role added successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ChangeRoleDto dto
            , [FromServices] IChangeRoleCommand command
            , [FromServices] ChangeRoleValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Role role = _mapper.Map<Role>(dto);
                _useCaseExecutor.ExecuteCommand(command, role);
                return Ok("Role changed successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveRoleCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Ok("Role removed successfully.");
        }
    }
}
