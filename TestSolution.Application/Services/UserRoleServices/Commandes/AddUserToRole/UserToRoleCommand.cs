using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution.Application.Services.UserRoleServices.Commandes.AddUserToRole
{
    public class UserToRoleCommand : IRequest<string?>
    {
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}
