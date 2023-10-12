using Domain.Models;
using MediatR;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Queries.RoleQueries
{
    public class GetAllRolesQuery : IRequest<List<Role>>
    {
        public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<Role>>
        {
            private readonly IRoleService _roleService;

            public GetAllRolesQueryHandler(IRoleService roleService)
            {
                _roleService = roleService;
            }

            public async Task<List<Role>> Handle(GetAllRolesQuery query, CancellationToken cancellationToken)
            {
                return await _roleService.GetAllAsync();
            }
        }
    }
}
