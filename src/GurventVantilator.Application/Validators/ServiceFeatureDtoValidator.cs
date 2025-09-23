using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class ServiceFeatureDtoValidator : AbstractValidator<ServiceFeatureDto>
    {
        public ServiceFeatureDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Özellik adı zorunludur.")
                .MaximumLength(150).WithMessage("Özellik adı en fazla 150 karakter olabilir.");

            RuleFor(x => x.Value)
                .MaximumLength(500).WithMessage("Özellik değeri en fazla 500 karakter olabilir.");
        }
    }
}
