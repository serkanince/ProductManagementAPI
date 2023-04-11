using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Product.Application.IoC
{
    public static class ApplicationServiceRegistration
    {
        public static void AddServiceRegistration(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
