using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager_API.CQ.Commands.UserCommands;

namespace TaskManager_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("users/create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        [HttpDelete("users/{userId}/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteUser(Guid userId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteUserCommand { UserId = userId }, cancellationToken);
            return NoContent();
        }

        [HttpPut("users/{userId}/update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateUser(Guid userId, [FromBody] UpdateUserCommand command, CancellationToken cancellationToken)
        {
            command.UserId = userId;
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
