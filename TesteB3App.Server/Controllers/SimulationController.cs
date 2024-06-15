using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteB3App.Core.Application.Commands;

namespace TesteB3App.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SimulationController(IMediator mediator) 
        { 
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Simulate([FromBody] SimulateIncomeCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
