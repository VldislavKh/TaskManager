using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager_API.CQ.Commands.UserCommands;
using TaskManager_API.CQ.Queries.UserQueries;

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



        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteUser(Guid userId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteUserCommand { UserId = userId }, cancellationToken);
            return NoContent();
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateUser(Guid userId, [FromBody] UpdateUserCommand command, CancellationToken cancellationToken)
        {
            command.UserId = userId;
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> GetUser(Guid userId, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(new GetUserQuery { UserId = userId }, cancellationToken);
            return Ok(user);
        }

        [HttpGet("check/{login}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CheckLogin(string login)
        {
            var res = await _mediator.Send(new IsLoginUniqueQuery { Login = login });
            return Ok(res);
        }


        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(new GetAllUsersQuery(), cancellationToken);
            return Ok(users);
        }
    }
}
