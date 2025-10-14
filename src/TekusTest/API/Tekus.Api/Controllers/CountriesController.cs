using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tekus.Application.Contracts.ExternalServices;

namespace Tekus.Api.Controllers
{
    //[Authorize(Policy = "RequireAdminRole")]
    public class CountriesController : BaseApiController
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        /// <summary>
        /// Obtiene la lista de países desde un servicio externo (RestCountries API)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _countryService.GetAllCountriesAsync();

            if (countries == null || !countries.Any())
                return NotFound("No se encontraron países o el servicio externo no respondió.");

            return Ok(countries);
        }
    }
}
