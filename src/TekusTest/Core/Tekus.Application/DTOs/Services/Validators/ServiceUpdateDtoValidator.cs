using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekus.Application.DTOs.Services.Validators
{
    public class ServiceUpdateDtoValidator : AbstractValidator<ServiceUpdateDto>
    {
        public ServiceUpdateDtoValidator() 
        {
            RuleFor(x =>  x.Name)
                .NotEmpty()
                    .WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Id)
                .NotNull()
                    .WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

            RuleFor(x => x.HourlyRate)
                .NotNull()
                    .WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
        }
    }
}
