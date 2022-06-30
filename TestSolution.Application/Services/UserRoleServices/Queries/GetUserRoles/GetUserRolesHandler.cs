using MediatR;
using Microsoft.AspNetCore.Identity;

namespace TestSolution.Application.Services.UserRoleServices.Queries.GetUserRoles
{
    public class GetUserRolesHandler : IRequestHandler<UserRoles, IList<string>>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public GetUserRolesHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IList<string>> Handle(UserRoles request, CancellationToken cancellationToken)
        {
            //check if the user exist or not 
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new Exception("Invalid Email");
            //check if the role not found
            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Any())
                throw new Exception($"no role assigned to this {request.Email}");
            return roles;
        }
    }
}
