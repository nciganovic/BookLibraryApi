using Application;
using Application.Commands.Reservations;
using Application.Dto.Reservation;
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
    public class ReservationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UseCaseExecutor _executor;

        public ReservationController(IMapper mapper, UseCaseExecutor executor)
        {
            _mapper = mapper;
            _executor = executor;
        }

        // GET: api/<ReservationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReservationController>
        [HttpPost]
        public IActionResult Post([FromBody] AddReservationDto dto
            , [FromServices] IAddReservationCommand command
            , [FromServices] AddReservationValidator validator)
        {
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                Reservation reservation = _mapper.Map<AddReservationDto, Reservation>(dto);
                _executor.ExecuteCommand(command, reservation);
                return Ok("Reservation created successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ChangeReservationDto dto
            , [FromServices] IChangeReservationCommand command
            , [FromServices] ChangeReservationValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);
            if (result.IsValid)
            {
                Reservation reservation = _mapper.Map<ChangeReservationDto, Reservation>(dto);
                _executor.ExecuteCommand(command, reservation);
                return Ok("Reservation changed successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveReservationCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return Ok("Reservation removed successfully.");
        }
    }
}
