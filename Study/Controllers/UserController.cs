using Microsoft.AspNetCore.Mvc;
using Study.Commands.User;
using Study.Handlers;

namespace Study.Controllers
{
    [ApiController]
    [Route("v1")]
    public class UserController: ControllerBase
    {
        [HttpPost("/user")]
        public IActionResult PostAsync(
            [FromBody] CreateUserRequest command,
            [FromServices] UserHandler handler
            )
        {
            return Ok(handler.Handler(command));
        }
    }
}
