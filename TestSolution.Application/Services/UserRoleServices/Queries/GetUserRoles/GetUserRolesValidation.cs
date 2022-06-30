using FluentValidation;

namespace TestSolution.Application.Services.UserRoleServices.Queries.GetUserRoles
{
    public class GetUserRolesValidation : AbstractValidator<UserRoles>
    {
        public GetUserRolesValidation()
        {
            RuleFor(b => b.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                ;
        }
    }
}
