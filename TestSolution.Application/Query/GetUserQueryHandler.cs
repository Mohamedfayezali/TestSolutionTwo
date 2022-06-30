using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolutoin.Infrastructure;

namespace TestSolution.Application.Query
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryDto>
    {
        private readonly UserContext _context;

        public GetUserQueryHandler(UserContext context)
        {
            _context = context;
        }
        public async Task<GetUserQueryDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.users.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
            if (user == null) throw new Exception();

            var userDto = user.Adapt<GetUserQueryDto>();

            //userDto.Id = user.Id;
            //userDto.Name = user.Name;
            //userDto.Address = user.Address;
            //userDto.Age = user.Age; 

            return userDto;
        }
    }
}
