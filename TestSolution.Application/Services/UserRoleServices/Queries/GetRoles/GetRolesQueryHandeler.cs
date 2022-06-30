using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TestSolution.Application.Services.UserRoleServices.Queries.GetRoles
{
    public class GetRolesQueryHandeler : IRequestHandler<RolesQuery, List<IdentityRole>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetRolesQueryHandeler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<IdentityRole>> Handle(RolesQuery request, CancellationToken cancellationToken)
        {
            return await _roleManager.Roles.ToListAsync(cancellationToken);
        }

        //public  List<IdentityRole> GetAllRoles()
        //{
        //    return ( _roleManager.Roles.ToList());
        //}


    }
}
