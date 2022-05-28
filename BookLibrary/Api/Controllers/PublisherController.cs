using Application;
using Application.Commands.Publishers;
using Application.Dto.Publisher;
using Application.Queries.Publishers;
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
    public class PublisherController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public PublisherController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOnePublisherQuery query)
        {
            PublisherResultDto result = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get([FromBody] PublisherSearch search,
              [FromServices] IGetPublishersQuery query)
        {
            IEnumerable<PublisherResultDto> result = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddPublisherDto dto
            , [FromServices] IAddPublisherCommand command
            , [FromServices] AddPublisherValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Publisher publisher = _mapper.Map<Publisher>(dto);
                _useCaseExecutor.ExecuteCommand(command, publisher);
                return Ok("Publisher added successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ChangePublisherDto dto
            , [FromServices] IChangePublisherCommand command
            , [FromServices] ChangePublisherValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Publisher publisher = _mapper.Map<Publisher>(dto);
                _useCaseExecutor.ExecuteCommand(command, publisher);
                return Ok("Publisher changed successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemovePublisherCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Ok("Publisher removed successfully.");
        }
    }
}
