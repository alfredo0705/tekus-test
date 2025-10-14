using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tekus.Application.DTOs.Dashboard;
using Tekus.Application.Features.Dashboard.Requests.Queries;

namespace Tekus.Api.Controllers
{
    //[Authorize(Policy = "RequireAdminRole")]
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
    }
}
