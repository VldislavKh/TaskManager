using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration.UserSecrets;
using TaskManager_API.CQ.Extensions;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Commands.GoalCommands
{
    public class CreateGoalCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDay { get; set; }
        public DateTime Deadline { get; set; }
        public Priority Priority { get; set; }
        public Guid UserId { get; set; }

        public class CreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, Guid>
        {
            private readonly IGoalService _goalService;
            private readonly AuthorizationService _authorizationService;

            public CreateGoalCommandHandler(IGoalService goalService)
            {
                _goalService = goalService;
            }

            public async Task<Guid> Handle(CreateGoalCommand command, CancellationToken cancellationToken)
            {
                var goal = new Goal
                {
                    Name = command.Name,
                    Description = command.Description,
                    CreationDay = command.CreationDay,
                    Deadline = command.Deadline,
                    Priority = command.Priority,
                    UserId = command.UserId,
                };

                //_authorizationService = new AuthorizationService(_context, _context.Users.SingleOrDefault)

                return await _goalService.CreateGoalAsync(goal);

                //return await _goalService.CreateAsync(command.Name, command.Description, command.CreationDay, 
                //    command.Deadline, command.Priority, command.UserId);
            }
        }
    }
}
