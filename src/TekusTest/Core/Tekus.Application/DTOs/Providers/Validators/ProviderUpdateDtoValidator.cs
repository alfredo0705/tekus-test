using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekus.Application.DTOs.Providers.Validators
{
    public class ProviderUpdateDtoValidator : AbstractValidator<ProviderUpdateDto>
    {
        public ProviderUpdateDtoValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("{PropertyName} is required.");
            RuleFor(x => x.NIT)
                .NotEmpty()
                    .WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Email)
                .NotEmpty()
                    .WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Id)
                .NotNull()
                    .WithMessage("{PropertyName} is required.");
        }
    }
}
