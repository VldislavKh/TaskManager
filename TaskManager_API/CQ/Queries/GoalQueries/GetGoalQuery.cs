using Domain.Models;
using MediatR;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Queries.GoalQueries
{
    public class GetGoalQuery : IRequest<Goal>
    {
        public Guid GoalId { get; set; }

        public class GetGoalQueryHandler : IRequestHandler<GetGoalQuery, Goal>
        {
            private readonly IGoalService _goalService;

            public GetGoalQueryHandler(IGoalService goalService)
            {
                _goalService = goalService;
            }

            public async Task<Goal> Handle(GetGoalQuery query, CancellationToken cancellationToken)
            {
                return await _goalService.GetGoalAsync(query.GoalId);
            }
        }
    }
}
