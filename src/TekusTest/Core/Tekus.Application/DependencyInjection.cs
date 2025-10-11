using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tekus.Application.Profiles;

namespace Tekus.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(config =>
            {
                config.AddProfile<MappingProfile>();
            }, AppDomain.CurrentDomain.GetAssemblies());

            // MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            // FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
