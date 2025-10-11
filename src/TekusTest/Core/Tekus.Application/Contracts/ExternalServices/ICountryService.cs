using Tekus.Application.DTOs.Country;

namespace Tekus.Application.Contracts.ExternalServices
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllCountriesAsync();
    }
}
