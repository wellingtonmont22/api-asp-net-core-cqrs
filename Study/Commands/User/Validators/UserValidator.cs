using FluentValidation;

namespace Study.Commands.User.Validators
{
    public class UserValidator : AbstractValidator<CreateUserRequest>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Senha)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50)
                .MinimumLength(8);
                
        }
    }
}
