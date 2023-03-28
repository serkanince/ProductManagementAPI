using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Contract;
using Product.Infrastructure.Persistence;
using Product.Infrastructure.Repositories;

namespace Product.Infrastructure.IoC
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDBContext>(options =>
            options.UseNpgsql(configuration["Database:ProductConnection"], b => b.MigrationsAssembly("Product.Api")));


            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
