using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution.Application.Services.UserRoleServices.Commandes.CreateRoleCommand
{
    public class CreateRoleCommandValidation : AbstractValidator<RoleCommand>
    {
        public CreateRoleCommandValidation()
        {
            RuleFor(b => b.RoleName)
                .NotEmpty()
                .NotNull()
                ;
        }
    }
}
