using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class ProductApplicationDtoValidator : AbstractValidator<ProductApplicationDto>
    {
        public ProductApplicationDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Uygulama alanı adı zorunludur.")
                .MaximumLength(150).WithMessage("Uygulama alanı adı en fazla 150 karakter olabilir.");
        }
    }
}
