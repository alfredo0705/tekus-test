using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekus.Application.DTOs.Providers.Validators
{
    public class CustomFieldDtoValidator : AbstractValidator<CustomFieldDto>
    {
        public CustomFieldDtoValidator() 
        { 
            RuleFor(x => x.FieldValue)
                .NotEmpty()
                    .WithMessage("{PropertyName} is required.");
            RuleFor(x => x.FieldName) 
                .NotEmpty()
                    .WithMessage("{PropertyName} is required.");
        }
    }
}
