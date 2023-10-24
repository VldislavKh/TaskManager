using Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Commands.UserCommands
{
    public class UpdateUserCommand : IRequest
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
        {
            private readonly IUserService _userService;

            public UpdateUserCommandHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    Login = command.Login,
                    Email = command.Email,
                    Password = command.Password,
                    RoleId = command.RoleId
                };

                //await _userService.UpdateAsync(command.UserId, command.Login, command.Email, command.Password, command.RoleId);

                await _userService.UpdateAsync(command.UserId, user);
            }
        }
    }
}
