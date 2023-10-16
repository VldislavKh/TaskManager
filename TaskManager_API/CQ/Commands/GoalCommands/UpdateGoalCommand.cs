﻿using Domain.Models;
using MediatR;
using System.Text.Json.Serialization;
using TaskManager_API.Interfaces;

namespace TaskManager_API.CQ.Commands.GoalCommands
{
    public class UpdateGoalCommand : IRequest
    {
        [JsonIgnore]
        public Guid GoalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDay { get; set; }
        public DateTime Deadline { get; set; }
        public Priority Priority { get; set; }
        public Guid UserId { get; set; }

        public class UpdateGoalCommandHandler : IRequestHandler<UpdateGoalCommand>
        {
            private readonly IGoalService _goalService;

            public UpdateGoalCommandHandler(IGoalService goalService)
            {
                _goalService = goalService;
            }

            public async Task Handle(UpdateGoalCommand command, CancellationToken cancellationToken)
            {
                await _goalService.UpdateAsync(command.GoalId, command.Name, command.Description, command.CreationDay,
                    command.Deadline, command.Priority, command.UserId);
            }
        }
    }
}