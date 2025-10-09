using FluentValidation;
using GurventVantilator.AdminUI.Models.ProductCategory;

namespace GurventVantilator.AdminUI.Validators
{
    public class ProductCategoryEditViewModelValidator : AbstractValidator<ProductCategoryEditViewModel>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long _maxFileSize = 5 * 1024 * 1024; // 5 MB

        public ProductCategoryEditViewModelValidator()
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
