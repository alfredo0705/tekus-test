using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tekus.Application.Contracts.Persistence;
using Tekus.Persistence.Repositories;

namespace Tekus.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TekusDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DBConnectionString"),
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly("Tekus.Persistence"); // Especifica el ensamblado de migraciones
                        sqlOptions.EnableRetryOnFailure();
                    }));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
