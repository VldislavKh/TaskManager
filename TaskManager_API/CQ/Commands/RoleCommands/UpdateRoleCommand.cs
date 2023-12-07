using MediatR;
using System.Text.Json.Serialization;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Commands.RoleCommands
{
    public class UpdateRoleCommand : IRequest
    {
        [JsonIgnore]
        public Guid RoleId { get; set; }

        public string RoleName { get; set; }

        public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
        {
            private readonly IRoleService _roleService;

            public UpdateRoleCommandHandler(IRoleService roleService)
            {
                _roleService = roleService;
            }

            public async Task Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
            {
                await _roleService.UpdateRoleAsync(command.RoleId, command.RoleName);
            }
        }
    }
}
