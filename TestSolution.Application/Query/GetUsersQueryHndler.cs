using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestSolutoin.Infrastructure;

namespace TestSolution.Application.Query
{
    public class GetUsersQueryHndler : IRequestHandler<GetUsersQuery, List<GetUsersQueryDto>>
    {
        private readonly UserContext _context;

        public GetUsersQueryHndler(UserContext context)
        {
            _context = context;
        }
        public async Task<List<GetUsersQueryDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            mapping();
            var users = await _context.users.ToListAsync(cancellationToken);

            

            var ListUserDto = new List<GetUsersQueryDto>();

           

             ListUserDto = users.Adapt<List<GetUsersQueryDto>>();


            //foreach (var user in users)
            //{
            //    ListUserDto.Add(user.Adapt<GetUsersQueryDto>());

            //        //new GetUsersQueryDto()
            //        //{
            //        //    Name = user.Name,
            //        //    Address = user.Address,
            //        //    Age = user.Age,
            //        //    Id = user.Id
            //        //});

            //}


            return ListUserDto;
        }

        private void mapping()
        {           
           TypeAdapterConfig<Domain.User, GetUsersQueryDto>
                .NewConfig()                
                .Map(dest => dest.NewName,
                src => string.Format("{0} {1}", src.Name, src.Name));
        }

    }
}
