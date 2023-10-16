using MediatR;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Commands.GoalCommands
{
    public class DeleteGoalCommand : IRequest
    {
        public Guid GoalId { get; set; }

        public class DeleteGoalCommandHandler : IRequestHandler<DeleteGoalCommand>
        {
            private readonly IGoalService _goalService;

            public DeleteGoalCommandHandler(IGoalService goalService)
            {
                _goalService = goalService;
            }

            public async Task Handle(DeleteGoalCommand command, CancellationToken cancellationToken)
            {
                await _goalService.DeleteAsync(command.GoalId);
            }
        }
    }
}
