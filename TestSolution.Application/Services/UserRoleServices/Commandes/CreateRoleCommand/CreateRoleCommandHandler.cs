using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution.Application.Services.UserRoleServices.Commandes.CreateRoleCommand
{
    public class CreateRoleCommandHandler : IRequestHandler<RoleCommand, string>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateRoleCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<string> Handle(RoleCommand request, CancellationToken cancellationToken)
        {
            var roleExist = await _roleManager.RoleExistsAsync(request.RoleName);
            if (!roleExist)
            {
                var addRole = await _roleManager.CreateAsync(new IdentityRole(request.RoleName));
                if (addRole.Succeeded)
                {
                    return $"the {addRole} is added successfuly";
                }
                return $"Can Not Create The {addRole} Role";
            }
            return $"The Role Exist Before";
        }
    }
}
