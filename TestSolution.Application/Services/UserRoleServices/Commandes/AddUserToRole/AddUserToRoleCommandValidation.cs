using FluentValidation;

namespace TestSolution.Application.Services.UserRoleServices.Commandes.AddUserToRole
{
    public class AddUserToRoleCommandValidation : AbstractValidator<UserToRoleCommand>
    {
        public AddUserToRoleCommandValidation()
        {
            RuleFor(b => b.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                ;
            RuleFor(b => b.RoleName)
                .NotEmpty()
                .NotNull()
                ;
        }
    }
}
