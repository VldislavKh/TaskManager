using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager_API.CQ.Commands.GoalCommands;
using TaskManager_API.CQ.Queries.GoalQueries;

namespace TaskManager_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GoalController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Create a new goal.
        /// </summary>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateGoal([FromBody] CreateGoalCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        [HttpDelete("{goalId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteGoal(Guid goalId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteGoalCommand { GoalId = goalId}, cancellationToken);
            return NoContent();
        }

        [HttpPut("{goalId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateGoal(Guid goalId, [FromBody] UpdateGoalCommand command, CancellationToken cancellationToken)
        {
            command.UpdatingGoalId = goalId;
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpGet("{goalId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Goal>> GetGoal(Guid goalId, CancellationToken cancellationToken)
        {
            var goal = await _mediator.Send(new GetGoalQuery { GoalId = goalId}, cancellationToken);

            return Ok(goal);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Goal>>> GetAllGoals(CancellationToken cancellationToken)
        {
            var goals = await _mediator.Send(new GetAllGoalsQuery(), cancellationToken);
            return Ok(goals);
        }
    }
}
