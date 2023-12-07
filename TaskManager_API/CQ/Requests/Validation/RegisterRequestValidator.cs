using FluentValidation;

namespace TaskManager_API.CQ.Requests.Validation
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(s => s.Login).NotEmpty().WithMessage("Login is required");

            RuleFor(s => s.Email).NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("A valid email is required");

            RuleFor(s => s.Password).NotEmpty().WithMessage("Password is required");

            RuleFor(s => s.RepeatPassword).NotEmpty().WithMessage("Repeat password")
                .Equal(s => s.Password).WithMessage("Passwords should be equal");
        }
    }
}
