using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Product.Application.IoC
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
