using MediatR;
using Microsoft.EntityFrameworkCore;
using TestSolutoin.Infrastructure;

namespace TestSolution.Application.Commend
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid?>
    {
        private readonly UserContext _context;

        public UpdateUserCommandHandler(UserContext context)
        {
            _context = context;
        }
        public async Task<Guid?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.users.FirstOrDefaultAsync(b=>b.Id==request.UserId);
            //if (user == null) throw new Exception("No user to update");
            user.SetAddress(request.Address);
            await _context.SaveChangesAsync();
            return user.Id;
        }
    }
}
