using AutoMapper;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services, IWebHostEnvironment environment)
        {
            services.AddAutoMapper(typeof(Program).Assembly);

            services.AddControllers().ConfigureApiBehaviorOptions(options => { 
                options.SuppressModelStateInvalidFilter = environment.IsProduction(); 
            });


            return services;
        }

    }
}
