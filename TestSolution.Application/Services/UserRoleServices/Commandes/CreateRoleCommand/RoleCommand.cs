using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution.Application.Services.UserRoleServices.Commandes.CreateRoleCommand
{
    public class RoleCommand : IRequest<string>
    {
        public string RoleName { get; set; }
    }
}
