using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution.Application
{
    public static class DependencyInjectionValidation
    {
        public static IServiceCollection Addvalidations(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjectionValidation));
            //services.AddFluentValidation()


            //    services.AddMvc() // fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>()
            //    .AddFluentValidation(fv => {
            //        fv.RegisterValidatorsFromAssemblyContaining<ClassInAssemblyOne>());
            //        fv.RegisterValidatorsFromAssemblyContaining<ClassInAssemblyTwo>());
            //});

            return services;
        }
    }
}
