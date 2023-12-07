using Domain.Models;
using FluentValidation;
using MediatR;
using TaskManager_API.CQ.Commands.UserCommands.Validation;
using TaskManager_API.Interfaces;
using TaskManager_API.CQ.Extensions;

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
            private readonly CreateUserCommandValidator _validator;
            private readonly AuthorizationService _authorizationService;

            public CreateUserCommandHandler(IUserService userService)
            {
                _userService = userService;
                _validator = new CreateUserCommandValidator();
            }

            public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                await _validator.ValidateAndThrowAsync(command);

                var user = new User { 
                    Login = command.Login,
                    Email = command.Email,
                    Password = command.Password,
                    RoleId = command.RoleId 
                };

                return await _userService.CreateUserAsync(user);
            }
        }
    }
}
