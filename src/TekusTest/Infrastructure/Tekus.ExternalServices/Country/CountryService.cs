using System.Text.Json;
using Tekus.Application.Contracts.ExternalServices;
using Tekus.Application.DTOs.Country;

namespace Tekus.ExternalServices.Country
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CountryDto>> GetAllCountriesAsync()
        {
            var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all?fields=name,code");
            response.EnsureSuccessStatusCode();


            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<RestCountryResponse>>(json);

            return data?.Select(c => new CountryDto
            {
                Name = c.name.common,
                Description = c.name.official,
            }) ?? new List<CountryDto>();
        }
    }
}
