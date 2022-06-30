using MediatR;

namespace TestSolution.Application.Commend
{
    public class CreateUserCommand : IRequest<Guid?>
    {
        public UserType Type { get; set; }
        public string? UserName { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }

    }
}
