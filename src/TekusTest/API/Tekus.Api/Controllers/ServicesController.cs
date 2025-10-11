using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tekus.Application.DTOs.Services;
using Tekus.Application.Features.Services.Requests.Commands;
using Tekus.Application.Features.Services.Requests.Queries;

namespace Tekus.Api.Controllers
{
    public class ServicesController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ServicesController> _logger;

        public ServicesController(IMediator mediator, ILogger<ServicesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("getServices")]
        public async Task<ActionResult<List<ServiceDto>>> GetServices()
        {
            return Ok(await _mediator.Send(new GetAllServicesQuery()));
        }

        [HttpGet("getService")]
        public async Task<ActionResult<ServiceDto>> GetService(int id)
        {
            return Ok(await _mediator.Send(new GetServiceByIdQuery { Id = id }));
        }

        [HttpPost("addService")]
        public async Task<ActionResult> AddService(ServiceCreateDto ServiceCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var command = new CreateServiceCommand { Service = ServiceCreate };
                var response = await _mediator.Send(command);

                if (response.Success)
                    return NoContent();

                return BadRequest(response);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Argument null exception while adding agency");

                return BadRequest("Invalid input. Please check your data.");
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(new
                {
                    Message = "Validation failed",
                    Errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding agency");

                return StatusCode(500, new
                {
                    Message = "An unexpected error occurred. Please contact support."
                });
            }
        }

        [HttpPut("updateService")]
        public async Task<ActionResult> UpdateService(ServiceUpdateDto ServiceUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var command = new UpdateServiceCommand { Service = ServiceUpdate };
                var response = await _mediator.Send(command);

                if (response.Success)
                    return NoContent();

                return BadRequest(response);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Argument null exception while updating agency");

                return BadRequest("Invalid input. Please check your data.");
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(new
                {
                    Message = "Validation failed",
                    Errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating agency");

                return StatusCode(500, new
                {
                    Message = "An unexpected error occurred. Please contact support."
                });
            }
        }
    }
}