using Domain.Models;
using MediatR;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Queries.RoleQueries
{
    public class GetRoleQuery : IRequest<Role>
    {
        public Guid RoleId { get; set; }

        public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, Role>
        {
            private readonly IRoleService _roleService;

            public GetRoleQueryHandler(IRoleService roleService)
            {
                _roleService = roleService;
            }

            public async Task<Role> Handle(GetRoleQuery query, CancellationToken cancellationToken)
            {
                return await _roleService.GetRoleAsync(query.RoleId);
            }
        }
    }
}
