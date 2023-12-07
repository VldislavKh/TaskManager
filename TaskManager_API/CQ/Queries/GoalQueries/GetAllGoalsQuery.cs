using Domain.Models;
using MediatR;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Queries.GoalQueries
{
    public class GetAllGoalsQuery : IRequest<List<Goal>>
    {
        public class GetAllGoalsQueryHandler : IRequestHandler<GetAllGoalsQuery, List<Goal>>
        {
            private readonly IGoalService _goalService;

            public GetAllGoalsQueryHandler(IGoalService goalService)
            {
                _goalService = goalService;
            }

            public async Task<List<Goal>> Handle(GetAllGoalsQuery command, CancellationToken cancellationToken)
            {
                return await _goalService.GetAllGoalsAsync();
            }
        }
    }
}
