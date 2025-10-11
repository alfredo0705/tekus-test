using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Application.Contracts.Persistence;
using Tekus.Application.DTOs.Services.Validators;
using Tekus.Application.Features.Services.Requests.Commands;
using Tekus.Application.Responses;

namespace Tekus.Application.Features.Services.Handlers.Commands
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateServiceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                var validator = new ServiceUpdateDtoValidator();

                var validationResult = await validator.ValidateAsync(request.Service);

                if (!validationResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "Update failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                    return response;
                }

                var serviceToUpdate = await _unitOfWork.ServiceRepository.GetByIdAsync(request.Service.Id);

                if (serviceToUpdate is null)
                {
                    response.Success = false;
                    response.Message = "Service not found";
                    return response;
                }

                serviceToUpdate.UpdateName(newName: request.Service.Name);
                serviceToUpdate.UpdateRate(newRate: request.Service.HourlyRate);

                await _unitOfWork.ServiceRepository.UpdateAsync(serviceToUpdate);
                await _unitOfWork.SaveAsync();

                response.Success = true;
                response.Message = "Service updated successfully";
                response.Id = request.Service.Id;
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
