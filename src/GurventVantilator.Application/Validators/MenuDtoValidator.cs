using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class MenuDtoValidator : AbstractValidator<MenuDto>
    {
        public MenuDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Menü başlığı zorunludur.")
                .MaximumLength(100).WithMessage("Menü başlığı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Order)
               .NotEmpty().WithMessage("Sıra numarası zorunludur.");
        }
    }
}
