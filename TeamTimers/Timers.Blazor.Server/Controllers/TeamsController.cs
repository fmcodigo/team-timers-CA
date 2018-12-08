using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Timers.Application.Teams;

namespace Timers.Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamsController(IMediator mediator) => _mediator = mediator;

        // GET: api/Teams
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetTeamDetailModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetTeamDetailsQuery { Id = id }));
        }

        // POST: api/Teams
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Teams/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
