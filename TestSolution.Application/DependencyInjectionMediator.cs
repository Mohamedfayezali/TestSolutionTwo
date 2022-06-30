using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TestSolution.Application
{
    public static class DependencyInjectionMediator
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjectionMediator).Assembly);
            return services;
        }
    }
}
