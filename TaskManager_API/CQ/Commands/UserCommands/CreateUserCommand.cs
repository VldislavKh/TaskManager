using MediatR;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>    
        {
            private readonly IUserService _userService;

            public CreateUserCommandHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                return await _userService.CreateAsync(command.Login, command.Email, command.Password, command.RoleId);
            }
        }
    }
}
