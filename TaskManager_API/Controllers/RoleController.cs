using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager_API.CQ.Commands.RoleCommands;

namespace TaskManager_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("roles/create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> AddRole([FromBody] CreateRoleCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        [HttpDelete("roles/{roleId}/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteRole(Guid roleId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteRoleCommand() { RoleId = roleId }, cancellationToken);
            return NoContent();
        }

        [HttpPut("roles/{roleId}/update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateRole(Guid roleId, UpdateRoleCommand command, CancellationToken cancellationToken)
        {
            command.RoleId = roleId;
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
