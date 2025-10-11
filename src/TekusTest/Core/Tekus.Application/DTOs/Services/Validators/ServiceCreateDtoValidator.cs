using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekus.Application.DTOs.Services.Validators
{
    public class ServiceCreateDtoValidator : AbstractValidator<ServiceCreateDto>
    {
        public ServiceCreateDtoValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("{PropertyName} is required.");
            RuleFor(x => x.HourlyRate)
                .NotNull()
                    .WithMessage("{PropertyName} is required.");
        }
    }
}
