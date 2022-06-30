using FluentValidation;

namespace TestSolution.Application.Register
{
    public class CommandRegisterValidation : AbstractValidator<CommandRegister>
    {
        //private readonly CommandRegister _command;

        public CommandRegisterValidation()
        {
            RuleFor(b => b.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(30)
                ;

            RuleFor(b => b.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(50)
                ;

            RuleFor(b => b.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(50)
                ;

            RuleFor(b => b.ConfirmPassword)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(50)
                .Must(IsMatch).WithMessage("confirm password does not match the password")
                ;
            
          
        }

        private bool IsMatch(CommandRegister command,string confirm)
        {
            if (command.Password == confirm)
                return true;
            return false;
        }


    }
}
