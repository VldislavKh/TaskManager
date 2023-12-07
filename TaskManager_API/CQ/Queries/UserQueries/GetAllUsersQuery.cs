using Domain.Models;
using MediatR;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Queries.UserQueries
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
        {
            private readonly IUserService _userService;

            public GetAllUsersQueryHandler(IUserService userService)
            {
                _userService = userService;
            }
            public async Task<List<User>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
            {
                return await _userService.GetAllUsersAsync();
            }
        }
    }
}
