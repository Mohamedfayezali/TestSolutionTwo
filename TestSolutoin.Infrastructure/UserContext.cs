using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TestSolutoin.Infrastructure
{
    public class UserContext : IdentityDbContext<IdentityUser> 
    {
        public UserContext(DbContextOptions<UserContext> option):base(option)
        {

        }

        public DbSet<TestSolution.Domain.User> users => Set<TestSolution.Domain.User>();
        //public DbSet<TestSolution.Domain.User> users { get; set; }

    }
}