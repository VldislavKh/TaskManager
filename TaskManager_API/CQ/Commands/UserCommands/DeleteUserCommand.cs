﻿using MediatR;
using System.Security.Cryptography;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Commands.UserCommands
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public Guid UserId { get; set;}

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
        {
            private readonly IUserService _userService;

            public DeleteUserCommandHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<Unit> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
            {
                await _userService.DeleteAsync(command.UserId);
                return Unit.Value;
            }
        }
    }
}
