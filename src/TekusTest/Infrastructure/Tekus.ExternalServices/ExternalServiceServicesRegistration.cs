using Microsoft.Extensions.DependencyInjection;
using Tekus.Application.Contracts.ExternalServices;
using Tekus.ExternalServices.Country;

namespace Tekus.ExternalServices
{
    public static class ExternalServiceServicesRegistration
    {
        public static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            services.AddHttpClient<ICountryService, CountryService>(client =>
            {
                client.BaseAddress = new Uri("https://restcountries.com/v3.1/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient<ICountryService, CountryService>();

            return services;
        }
    }
}
