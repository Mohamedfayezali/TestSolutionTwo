using MediatR;
using Microsoft.AspNetCore.Identity;

namespace TestSolution.Application.Services.UserRoleServices.Queries.GetRoles
{
    public class RolesQuery : IRequest<List<IdentityRole>>
    {
    }
}
