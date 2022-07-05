using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolution.Application.Commend;
using TestSolution.Domain;
using TestSolutoin.Infrastructure;

namespace TestSolution.Api.Tests.TestCommands.TestCreatUserCommand
{
    public class CreateUserCommandTests
    {
        private readonly UserContext userContext;

        public CreateUserCommandTests(UserContext userContext)
        {
            this.userContext = userContext;
        }

        [Fact]
        public async void CreateUserCommandHandler_test()
        {
            //Arrange 
           // var user = new User("gamal", "nnn", 20);
            var createUser = new CreateUserCommandHandler(userContext);
            var create = new CreateUserCommand
            {
                Address = "nnn",
                Age = 20,
                UserName = "gamal"
            };
            //Act
            await createUser.Handle(create, CancellationToken.None);

        }
    }
}
