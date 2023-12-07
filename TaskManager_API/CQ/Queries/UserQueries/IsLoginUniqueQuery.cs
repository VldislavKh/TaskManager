using Domain.Infrastructure.DBConnection;
using MediatR;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Queries.UserQueries
{
    public class IsLoginUniqueQuery : IRequest<bool>
    {
        public string Login { get; set; }

        public class IsLoginUniqueQueryHandler : IRequestHandler<IsLoginUniqueQuery, bool>
        {
            private readonly IUserService _userService;

            public IsLoginUniqueQueryHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<bool> Handle(IsLoginUniqueQuery query, CancellationToken cancellationToken)
            {
                return await _userService.IsLoginUniqueAsync(query.Login);
            }
        }
    }
}
