using KnowTask.Core.Interfaces.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IAppMediator mediator) : ControllerBase
    {
        private IAppMediator _mediator = mediator;
    }
}
