using Domain.Models;
using MediatR;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Queries.UserQueries
{
    public class GetUserQuery : IRequest<User>
    {
        public Guid UserId { get; set; }

        public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
        {
            private readonly IUserService _userService;

            public GetUserQueryHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<User> Handle(GetUserQuery query, CancellationToken cancellationToken)
            {
                return await _userService.GetUserAsync(query.UserId);
            }
        }
    }
}
