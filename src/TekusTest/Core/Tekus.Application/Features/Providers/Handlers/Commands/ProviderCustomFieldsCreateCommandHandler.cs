using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.DTOs.Providers.Validators;
using Tekus.Application.Features.Providers.Requests.Commands;
using Tekus.Application.Responses;
using Tekus.Domain.Entities;

namespace Tekus.Application.Features.Providers.Handlers.Commands
{
    public class ProviderCustomFieldsCreateCommandHandler : IRequestHandler<ProviderCustomFieldsCreateCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProviderCustomFieldsCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(ProviderCustomFieldsCreateCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            try
            {
                var provider = await _unitOfWork.ProviderRepository.GetByIdAsync(request.ProviderCustomField.ProviderId);
                if (provider == null)
                    throw new KeyNotFoundException("Provider not found");


                foreach (var field in request.ProviderCustomField.Fields)
                {
                    var validator = new CustomFieldDtoValidator();
                    var validationResult = await validator.ValidateAsync(field);
                    if (!validationResult.IsValid)
                    {
                        response.Success = false;
                        response.Message = "Creation failed";
                        response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                        return response;
                    }

                    var customField = new ProviderCustomField
                    {
                        ProviderId = provider.Id,
                        FieldName = field.FieldName,
                        FieldValue = field.FieldValue
                    };

                    provider.CustomFields.Add(customField);
                }

                await _unitOfWork.SaveAsync();

                response.Success = true;
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
