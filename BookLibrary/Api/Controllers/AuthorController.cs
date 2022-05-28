using Application;
using Application.Commands.Authors;
using Application.Dto.Author;
using Application.Queries.Authors;
using Application.Searches;
using AutoMapper;
using Domain;
using Implementation.ResponseMessages;
using Implementation.Validator;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public AuthorController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneAuthorQuery query)
        {
            AuthorResultDto result = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get([FromBody] AuthorSearch search,
              [FromServices] IGetAuthorsQuery query)
        {
            IEnumerable<AuthorResultDto> result = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddAuthorDto dto
            , [FromServices] IAddAuthorCommand command
            , [FromServices] AddAuthorValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Author author = _mapper.Map<Author>(dto);
                _useCaseExecutor.ExecuteCommand(command, author);
                return Ok("Author added successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ChangeAuthorDto dto
            , [FromServices] IChangeAuthorCommand command
            , [FromServices] ChangeAuthorValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Author author = _mapper.Map<Author>(dto);
                _useCaseExecutor.ExecuteCommand(command, author);
                return Ok("Author changed successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveAuthorCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Ok("Author removed successfully.");
        }
    }
}
