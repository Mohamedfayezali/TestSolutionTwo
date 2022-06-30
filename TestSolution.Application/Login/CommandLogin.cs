using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolution.Application.Register;

namespace TestSolution.Application.Login
{
    public class CommandLogin : IRequest<Response?>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
