using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution.Application.Services.UserRoleServices.Commandes.RemoveUserFromRole
{
    public class RemoveUserFromRoleCommandValidation : AbstractValidator<UserFromRoleCommand>
    {
        public RemoveUserFromRoleCommandValidation()
        {
            RuleFor(b => b.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                ;
            RuleFor(b => b.UserRole)
                .NotEmpty()
                .NotNull()
                ;
        }
    }
}
