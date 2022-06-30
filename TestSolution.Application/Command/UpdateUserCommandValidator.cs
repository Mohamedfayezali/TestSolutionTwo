using FluentValidation;
using TestSolutoin.Infrastructure;

namespace TestSolution.Application.Commend
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly UserContext _context;

        public UpdateUserCommandValidator(UserContext context)
        {
            
            _context = context;

            //RuleFor(b=> b.UserId)
            //    .Cascade(CascadeMode.Stop)
            //    .NotNull().WithMessage("UserId Can not be null value")
            //    .Must(IdIsInDb).WithMessage("ID Not Found In DB")
            //    ;

            //RuleFor(b => b.Address)
            //    .Cascade(CascadeMode.Stop)
            //    .NotNull()
            //    .NotEmpty().WithMessage("Address Can not Be Empty")
            //    .Must(IsValid).WithMessage("Address Must Be between 5 And 50")
                ;
        }
         

        private bool IsValid(string text)
        {
            if (string.IsNullOrWhiteSpace(text))return false;
            if (text.Length < 5 && text.Length > 50)return false;
            return true;
        }
        private bool IdIsInDb(Guid Id)
        {
            if (_context.users.FirstOrDefault(b => b.Id == Id) == null)return false;
            return true;
        }
    }
}
