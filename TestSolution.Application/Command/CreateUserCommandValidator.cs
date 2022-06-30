using FluentValidation;

namespace TestSolution.Application.Commend
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
           //RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(a => a.Type)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .IsInEnum();

            RuleFor(a => a.UserName)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100)
                ;

            RuleFor(a => a.Address)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .When(a => a.UserName == "Admin");

            RuleFor(a => a.Age)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .Must(BeValid).WithMessage("Age must be between 0-100");
        }

        private bool BeValid(int age)
        {
            if (age <= 0) return false;
            if (age > 100) return false;
            return true;
        }
    }
    public enum UserType
    {
        Admin = 1,
        Manager = 2
    };
}
