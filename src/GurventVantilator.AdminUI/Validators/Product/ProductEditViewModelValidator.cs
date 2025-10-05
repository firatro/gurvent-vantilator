using FluentValidation;
using GurventVantilator.AdminUI.Models.Product;
using System.IO;
using GurventVantilator.AdminUI.Validators.Common;

namespace GurventVantilator.AdminUI.Validators
{
    public class ProductEditViewModelValidator : AbstractValidator<ProductEditViewModel>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long _maxFileSize = 5 * 1024 * 1024;

        public ProductEditViewModelValidator()
        {
            // 🔹 Temel alanlar
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün adı zorunludur.")
                .MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Ürün kodu zorunludur.")
                .MaximumLength(50).WithMessage("Ürün kodu en fazla 50 karakter olabilir.");

            RuleFor(x => x.ProductCategoryId)
                .GreaterThan(0).WithMessage("Lütfen bir kategori seçiniz.");

            // 🔹 Teknik bilgiler
            RuleFor(x => x.Diameter)
                .MaximumLength(50).WithMessage("Çap alanı en fazla 50 karakter olabilir.");
            RuleFor(x => x.Power)
                .MaximumLength(50).WithMessage("Güç alanı en fazla 50 karakter olabilir.");
            RuleFor(x => x.Voltage)
                .MaximumLength(50).WithMessage("Voltaj alanı en fazla 50 karakter olabilir.");
            RuleFor(x => x.Frequency)
                .MaximumLength(50).WithMessage("Frekans alanı en fazla 50 karakter olabilir.");

            // 🔹 Sıralama
            RuleFor(x => x.Order)
                .GreaterThanOrEqualTo(0).WithMessage("Sıra numarası negatif olamaz.");

            RuleFor(x => x.ImageFile).ValidImageFile();

        }
    }
}
