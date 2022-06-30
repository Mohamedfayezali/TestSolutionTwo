using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestSolutoin.Infrastructure.Seeding;

namespace TestSolutoin.Infrastructure
{
    public static class DependencyInjectionContext
    {
        public static IServiceCollection AddUserInfrastructure(this IServiceCollection service ,IConfiguration configuration)
        {
            service.AddDbContext<UserContext>(option => option.UseSqlServer(
                configuration.GetConnectionString("SqlConnection"),
                b => b.MigrationsAssembly(typeof(UserContext).Assembly.FullName)));
            service.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<UserContext>().AddDefaultTokenProviders();
            

            //service.AddDbContext<IdentityContext>(option => option.UseSqlServer(configuration.GetConnectionString("SqlConnection"),
            //  b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));
            
            return service;
        }

        //public static IServiceCollection AddIdentityUserInfrastructure(this IServiceCollection service,IConfiguration configuration)
        //{
        //    service.AddDbContext<IdentityContext>(option => option.UseSqlServer(configuration.GetConnectionString("SqlConnection"),
        //        b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));

        //    //service.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
        //    //    .AddEntityFrameworkStores<IdentityContext>();

        //    return service;
        //}
    }
}
