using Application;
using Application.Commands.Languages;
using Application.Dto.Language;
using Application.Queries.Language;
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
    public class LanguageController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public LanguageController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneLanguageQuery query)
        {
            LanguageResultDto result = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get([FromBody] LanguageSearch search,
              [FromServices] IGetLanguagesQuery query)
        {
            IEnumerable<LanguageResultDto> result = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddLanguageDto dto
            , [FromServices] IAddLanguageCommand command
            , [FromServices] AddLanguageValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Language language = _mapper.Map<Language>(dto);
                _useCaseExecutor.ExecuteCommand(command, language);
                return Ok("Language added successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ChangeLanguageDto dto
            , [FromServices] IChangeLanguageCommand command
            , [FromServices] ChangeLanguageValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Language language = _mapper.Map<Language>(dto);
                _useCaseExecutor.ExecuteCommand(command, language);
                return Ok("Language changed successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveLanguageCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Ok("Language removed successfully.");
        }
    }
}
