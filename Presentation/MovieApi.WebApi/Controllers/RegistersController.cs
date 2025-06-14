using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.UserRegisterCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly CreateUserRegisterCommandHandler _createUserRegisterCommandHandler;

        public RegistersController(CreateUserRegisterCommandHandler createUserRegisterCommandHandler)
        {
            _createUserRegisterCommandHandler = createUserRegisterCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserRegisterCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid user registration data.");
            }
            try
            {
                await _createUserRegisterCommandHandler.Handle(command);
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error registering user: {ex.Message}");
            }
        }
    }
}
