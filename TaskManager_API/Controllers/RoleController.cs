using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager_API.CQ.Commands.RoleCommands;
using TaskManager_API.CQ.Queries.RoleQueries;

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
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateRole([FromBody] CreateRoleCommand command, CancellationToken cancellationToken)
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

        [HttpGet("roles/{roleId}/get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Role>> GetRole(Guid roleId, CancellationToken cancellationToken)
        {
            var role = await _mediator.Send(new GetRoleQuery { RoleId = roleId }, cancellationToken);
            return Ok(role);
        }

        [HttpGet("roles/all/get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Role>>> GetAllRoles(CancellationToken cancellationToken)
        {
            var roles = await _mediator.Send(new GetAllRolesQuery(),cancellationToken); 
            return Ok(roles);
        }
        
    }
}
