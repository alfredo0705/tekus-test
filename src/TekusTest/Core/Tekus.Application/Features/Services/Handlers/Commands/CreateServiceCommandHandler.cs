using MediatR;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.DTOs.Services.Validators;
using Tekus.Application.Features.Services.Requests.Commands;
using Tekus.Application.Responses;
using Tekus.Domain.Entities;

namespace Tekus.Application.Features.Services.Handlers.Commands
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateServiceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                var validator = new ServiceCreateDtoValidator();
                var validationResult = await validator.ValidateAsync(request.Service);
                if (!validationResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "Creation failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                }

                var service = new Service(
                    name: request.Service.Name,
                    hourlyRate: request.Service.HourlyRate,
                    providerId: request.Service.ProviderId);

                await _unitOfWork.ServiceRepository.AddAsync(service);
                await _unitOfWork.SaveAsync();

                response.Success = true;
                response.Message = "Service created successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
