using MediatR;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.DTOs.Providers.Validators;
using Tekus.Application.Features.Providers.Requests.Commands;
using Tekus.Application.Responses;

namespace Tekus.Application.Features.Providers.Handlers.Commands
{
    public class UpdateProviderCommandHandler : IRequestHandler<UpdateProviderCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProviderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                var validator = new ProviderUpdateDtoValidator();

                var validationResult = await validator.ValidateAsync(request.Provider);

                if (!validationResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "Update failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                    return response;
                }

                var providerToUpdate = await _unitOfWork.ProviderRepository.GetByIdAsync(request.Provider.Id);

                if (providerToUpdate is null)
                {
                    response.Success = false;
                    response.Message = "Service not found";
                    return response;
                }

                providerToUpdate.UpdateName(newName: request.Provider.Name);
                providerToUpdate.UpdateNit(newNit: request.Provider.NIT);
                providerToUpdate.UpdateEmail(newEmail: request.Provider.Email);

                await _unitOfWork.ProviderRepository.UpdateAsync(providerToUpdate);
                await _unitOfWork.SaveAsync();

                response.Success = true;
                response.Message = "Service updated successfully";
                response.Id = request.Provider.Id;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Errors = new List<string> { ex.Message };
            }

            return response;
        }
    }
}
