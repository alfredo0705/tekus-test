using MediatR;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.DTOs.Providers.Validators;
using Tekus.Application.Features.Providers.Requests.Commands;
using Tekus.Application.Responses;
using Tekus.Domain.Entities;

namespace Tekus.Application.Features.Providers.Handlers.Commands
{
    public class CreateProviderCommandHandler : IRequestHandler<CreateProviderCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProviderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                var validator = new ProviderCreateDtoValidator();
                var validationResult = await validator.ValidateAsync(request.Provider);
                if (!validationResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "Creation failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                }

                var provider = new Provider(nit: request.Provider.NIT, name: request.Provider.Name, email: request.Provider.Email);

                await _unitOfWork.ProviderRepository.AddAsync(provider);
                await _unitOfWork.SaveAsync();

                response.Success = true;
                response.Message = "Provider created successfully";
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
