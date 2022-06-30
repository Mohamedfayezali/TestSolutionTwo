using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution.Application.Services.UserRoleServices.Commandes.AddUserToRole
{
    public class AddUserToRoleCommandHandler : IRequestHandler<UserToRoleCommand, string?>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AddUserToRoleCommandHandler(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<string?> Handle(UserToRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return $"The User With Email {request.Email} Does Not Exist";
            var role = await _roleManager.FindByNameAsync(request.RoleName);
            if (role == null)
                return $"The {request.RoleName} Role Does Not Exist";

            var addUserToRole = await _userManager.AddToRoleAsync(user,request.RoleName);
            if (addUserToRole.Succeeded)
            {
                return $"The {request.Email} Added to {request.RoleName} Role Successfuly";
            }
            return $"The {request.Email} Can Not Added To The {request.RoleName} Role";
        }
    }
}
