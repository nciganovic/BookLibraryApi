using Application;
using Application.Queries.UseCaseLogs;
using Application.Searches;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private UseCaseExecutor _executor;

        public AuditController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<AuditController>
        [HttpGet]
        public IActionResult Get([FromBody] UseCaseLogSearch search, [FromServices] IGetUseCaseLogsQuery query)
        {
            IEnumerable<UseCaseLog> useCaseLogs  = _executor.ExecuteQuery(query, search);
            return Ok(useCaseLogs);
        }
    }
}
