using MediatR;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Commands.RoleCommands
{
    public class CreateRoleCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Guid>
        {
            private readonly IRoleService _roleService;

            public CreateRoleCommandHandler(IRoleService roleService)
            {
                _roleService = roleService;
            }

            public async Task<Guid> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
            {
                return await _roleService.CreateRoleAsync(command.Name);
            }
        }
    }
}
