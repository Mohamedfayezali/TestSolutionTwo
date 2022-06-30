using MediatR;
using Microsoft.AspNetCore.Identity;

namespace TestSolution.Application.Services.UserRoleServices.Commandes.RemoveUserFromRole
{
    public class RemoveUserFromRoleCommandHandler : IRequestHandler<UserFromRoleCommand, string?>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RemoveUserFromRoleCommandHandler(RoleManager<IdentityRole> roleManager,UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public async Task<string?> Handle(UserFromRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return $"The User With Email {request.Email} Does Not Exist";
            var userRole = await _roleManager.RoleExistsAsync(request.UserRole);
            if (!userRole)
                return $"The {request.UserRole} Role Does Not Exist";
            var removeUserFromRole = await _userManager.RemoveFromRoleAsync(user,request.UserRole);
            if (removeUserFromRole.Succeeded)
                return $"The User With Email {request.Email} Removed Successfuly From {request.UserRole} Role";
            return $"Can Not Remove User With Email {request.Email} From {request.UserRole} Role";
        }
    }
}
