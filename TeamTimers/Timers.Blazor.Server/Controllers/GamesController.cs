using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timers.Application.Games;
using Timers.Shared.ViewModels;

namespace Timers.Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GamesController(IMediator mediator) => _mediator = mediator;

        // GET: api/Games/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GameVM), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new DetailsQuery { Id = id }));
        }
    }
}