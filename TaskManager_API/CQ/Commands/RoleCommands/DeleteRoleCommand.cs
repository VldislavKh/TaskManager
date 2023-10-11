using MediatR;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Commands.RoleCommands
{
    public class DeleteRoleCommand : IRequest
    {
        public Guid RoleId { get; set; }

        public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
        {
            private readonly IRoleService _roleService;

            public DeleteRoleCommandHandler(IRoleService roleService)
            {
                _roleService = roleService;
            }

            public async Task Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
            {
                await _roleService.DeleteAsync(command.RoleId);
            }
        }
    }
}
