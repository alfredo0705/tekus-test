using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tekus.Application.DTOs.Providers;
using Tekus.Application.Features.Providers.Requests.Commands;
using Tekus.Application.Features.Providers.Requests.Queries;

namespace Tekus.Api.Controllers
{
    //[Authorize(Policy = "RequireAdminRole")]
    public class ProvidersController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProvidersController> _logger;

        public ProvidersController(IMediator mediator, ILogger<ProvidersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("getProviders")]
        public async Task<ActionResult<List<ProviderDto>>> GetProvider()
        {
            return Ok(await _mediator.Send(new GetAllProvidersQuery()));
        }

        [HttpGet("getProvider")]
        public async Task<ActionResult<ProviderDto>> GetProvider(int id)
        {
            return Ok(await _mediator.Send(new GetProviderByIdQuery { Id = id }));
        }

        [HttpPost("addProvider")]
        public async Task<ActionResult> AddProvider(ProviderCreateDto providerCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var command = new CreateProviderCommand { Provider = providerCreate };
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

        [HttpPut("updateProvider")]
        public async Task<ActionResult> UpdateProvider(ProviderUpdateDto providerUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var command = new UpdateProviderCommand { Provider = providerUpdate };
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

        [HttpPost("{id}/custom-fields")]
        public async Task<IActionResult> AddCustomFields(int id, [FromBody] List<CustomFieldDto> fields)
        {
            var command = new ProviderCustomFieldsCreateCommand
            {
                ProviderCustomField = new ProviderCustomFieldsCreateDto
                {
                    ProviderId = id,
                    Fields = fields
                }
            };

            var result = await _mediator.Send(command);
            return result.Success ? Ok("Custom fields added successfully.") : BadRequest("Failed to add custom fields.");
        }
    }
}
