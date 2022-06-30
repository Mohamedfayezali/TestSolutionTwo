using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution.Application.Services.UserRoleServices.Commandes.RemoveUserFromRole
{
    public class UserFromRoleCommand : IRequest<string?>
    {
        public string Email { get; set; }
        public string UserRole { get; set; }
    }
}
