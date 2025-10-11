using FluentValidation;

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
