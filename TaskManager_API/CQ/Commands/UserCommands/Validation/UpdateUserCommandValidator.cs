using FluentValidation;

namespace TaskManager_API.CQ.Commands.UserCommands.Validation
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.Login).NotEmpty().WithMessage("Login should not be empty");

            RuleFor(u => u.Email).NotEmpty().WithMessage("Email should not be empty")
                .EmailAddress().WithMessage("Email shoul be email address");

            RuleFor(u => u.Password).NotEmpty().WithMessage("Password should not be empty");
        }

    }
}
