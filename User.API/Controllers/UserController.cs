using Microsoft.AspNetCore.Mvc;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IAppMediator _mediator;
        public UserController(IAppMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
