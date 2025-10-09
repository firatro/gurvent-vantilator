using FluentValidation;
using GurventVantilator.AdminUI.Models.ProductCategory;

namespace GurventVantilator.AdminUI.Validators
{
    public class ProductCategoryCreateViewModelValidator : AbstractValidator<ProductCategoryCreateViewModel>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long _maxFileSize = 5 * 1024 * 1024; // 5 MB

        public ProductCategoryCreateViewModelValidator()
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
