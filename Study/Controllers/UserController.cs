using Microsoft.AspNetCore.Mvc;
using Study.Domain.Commands.User;
using Study.Handlers;
using Study.Infra.Repositories;

namespace Study.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromServices] IUserRepository repository)
        {
            try
            {
                var results = await repository.GetAllAsync();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync([FromServices] IUserRepository repository, [FromRoute] int id)
        {
            try
            {
                var result = await repository.GetAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostAsync(
            [FromBody] CreateUserRequest command,
            [FromServices] UserHandler handler
            )
        {
            try
            {
                var result = handler.Handler(command);
                return Created("v1/user", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(
            [FromRoute] int id,
            [FromBody] UpdateUserRequest command,
            [FromServices] UserHandler handler
            )
        {
            try
            {

                var result = await handler.Handler(command, id);

                return Ok(result);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] UserHandler handler
            )
        {
            try
            {
                var result = await handler.Handler(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
