using MediatR;
using TestSolution.Application.Services;
using TestSolution.Domain;
using TestSolutoin.Infrastructure;

namespace TestSolution.Application.Commend
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid?>
    {
        private readonly UserContext _context;
        private readonly IUserService _userService;

        public CreateUserCommandHandler(UserContext context,IUserService service)
        {
            _context = context;
            _userService = service;
        }
        public async Task<Guid?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.UserName,request.Address,request.Age);
            //var reult = _userService.GenerateString();
            await _context.AddAsync(user,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            
            return user.Id;
        }
    }
}
