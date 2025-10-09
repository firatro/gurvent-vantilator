using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class ProductCategoryDtoValidator : AbstractValidator<ProductCategoryDto>
    {
        public ProductCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori adı zorunludur.")
                .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir.");

            // 🔹 Sıralama
            RuleFor(x => x.Order)
                .NotNull().WithMessage("Sıra numarası boş bırakılamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Sıra numarası negatif olamaz.");
        }
    }
}
