using MediatR;
using Microsoft.EntityFrameworkCore;
using TestSolutoin.Infrastructure;

namespace TestSolution.Application.Commend
{
    public class DeleteUserCommandHadler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly UserContext _context;

        public DeleteUserCommandHadler(UserContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.users.FirstOrDefaultAsync(b => b.Id == request.UserId,cancellationToken);
            if (user == null) throw new Exception("user with this id not found.");
            _context.users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
