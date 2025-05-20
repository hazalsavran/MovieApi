using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using System.Text.Json;


namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        public MovieController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler, CreateMovieCommandHandler createMovieCommandHandler, GetMovieQueryHandler getMovieQueryHandler)
        {
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
        }


        [HttpGet]
        public async Task<IActionResult> MovieList()
        {
            var value = await _getMovieQueryHandler.Handle();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] JsonElement data)
        {
            if (data.ValueKind == JsonValueKind.Object)
            {
                var command = JsonSerializer.Deserialize<CreateMovieCommand>(data.GetRawText());
                await _createMovieCommandHandler.Handle(command);
            }
            else if (data.ValueKind == JsonValueKind.Array)
            {
                var commands = JsonSerializer.Deserialize<List<CreateMovieCommand>>(data.GetRawText());
                foreach (var command in commands)
                {
                    await _createMovieCommandHandler.Handle(command);
                }
            }
            else
            {
                return BadRequest("Geçersiz veri formatı.");
            }

            return Ok("Film(ler) başarıyla eklendi.");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
            return Ok("Silme işlemi başarılı!");
        }
        [HttpGet("GetMovie")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("Güncelleme işlemi başarılı!");
        }

    }
}
