using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution.Application.Services.UserRoleServices.Queries.GetUserRoles
{
    public class UserRoles : IRequest<IList<string>>
    {
        public string Email { get; set; }
    }
}
