using FluentValidation;

namespace TaskManager_API.CQ.Requests.Validation
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(u => u.Login).NotEmpty().WithMessage("Login should not be empty");

            RuleFor(u => u.Password).NotEmpty().WithMessage("Password should not be empty");
        }
    }
}
