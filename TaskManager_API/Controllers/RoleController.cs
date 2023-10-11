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

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> AddRole([FromBody] CreateRoleCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        [HttpDelete("[action]/{roleId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteRole(Guid roleId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteRoleCommand() { RoleId = roleId }, cancellationToken);
            return NoContent();
        }
    }
}
