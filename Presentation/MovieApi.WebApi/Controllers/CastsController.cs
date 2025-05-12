using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CastsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("CastList")]
        public async Task<IActionResult> CastList()
        {
            var result = await _mediator.Send(new GetCastQuery());
            return Ok(result);
        }

        [HttpPost("CreateCast")]
        public async Task<IActionResult> CreateCast([FromBody] CreateCastCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("GetCastById/{id}")]

        public async Task<IActionResult> GetCastById(int id)
        {
            await _mediator.Send(new GetCastByIdQuery(id));
            return Ok();
        }

        [HttpDelete("DeleteCast/{id}")]
        public async Task<IActionResult> DeleteCast(int id)
        {
            await _mediator.Send(new RemoveCastCommand(id));
            return Ok();
        }
    }
}
