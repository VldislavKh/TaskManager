﻿using FluentValidation;

namespace TaskManager_API.CQ.Commands.GoalCommands.Validation
{
    public class UpdateGoalCommandValidator : AbstractValidator<UpdateGoalCommand>
    {
        public UpdateGoalCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Name should not be empty");

            RuleFor(u => u.Description).NotEmpty().WithMessage("Description should not be empty");

            RuleFor(u => u.Deadline).GreaterThan(u => u.CreationDay).WithMessage("Deadline should be greater than Creation day");
        }
    }
}
