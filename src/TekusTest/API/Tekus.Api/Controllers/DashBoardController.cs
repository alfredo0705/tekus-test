using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tekus.Application.DTOs.Dashboard;
using Tekus.Application.Features.Dashboard.Requests.Queries;

namespace Tekus.Api.Controllers
{
    public class DashBoardController : BaseApiController
    {
        private readonly IMediator _mediator;

        public DashBoardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene un resumen de indicadores globales (servicios/proveedores por país)
        /// </summary>
        [HttpGet("summary")]
        public async Task<ActionResult<DashboardSummaryDto>> GetSummary()
        {
            var summary = await _mediator.Send(new GetDashboardSummaryQuery());
            return Ok(summary);
        }

        /// <summary>
        /// Obtiene la cantidad de servicios agrupados por país
        /// </summary>
        [HttpGet("services-by-country")]
        public async Task<ActionResult<IEnumerable<CountryCountDto>>> GetServicesByCountry()
        {
            var result = await _mediator.Send(new GetServicesByCountryQuery());
            return Ok(result);
        }

        /// <summary>
        /// Obtiene la cantidad de proveedores agrupados por país
        /// </summary>
        [HttpGet("providers-by-country")]
        public async Task<ActionResult<IEnumerable<CountryCountDto>>> GetProvidersByCountry()
        {
            var result = await _mediator.Send(new GetProvidersByCountryQuery());
            return Ok(result);
        }
    }
}
