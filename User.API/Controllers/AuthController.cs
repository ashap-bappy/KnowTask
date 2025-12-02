using KnowTask.Core.Interfaces.Mediator;
using Microsoft.AspNetCore.Mvc;
using User.Application.CQRS.Auth.Commands.RegisterUser;
using User.Application.DTOs;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController(IAppMediator mediator) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthModel.RegisterRequest request)
        {
            var cmd = new RegisterUserCommand(request);
            var response = await mediator.Send(cmd);
            return CreatedAtAction(nameof(Register), response);
        }
    }
}
