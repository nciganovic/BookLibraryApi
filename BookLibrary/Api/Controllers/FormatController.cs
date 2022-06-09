using Application;
using Application.Commands.Formats;
using Application.Dto.Format;
using Application.Queries.Format;
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
    public class FormatController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public FormatController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneFormatQuery query)
        {
            FormatResultDto result = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get([FromBody] FormatSearch search,
              [FromServices] IGetFormatsQuery query)
        {
            IEnumerable<FormatResultDto> result = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddFormatDto dto
            , [FromServices] IAddFormatCommand command
            , [FromServices] AddFormatValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Format format = _mapper.Map<Format>(dto);
                _useCaseExecutor.ExecuteCommand(command, format);
                return Ok("Format added successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ChangeFormatDto dto
            , [FromServices] IChangeFormatCommand command
            , [FromServices] ChangeFormatValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Format format = _mapper.Map<Format>(dto);
                _useCaseExecutor.ExecuteCommand(command, format);
                return Ok("Format changed successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveFormatCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Ok("Format removed successfully.");
        }
    }
}
