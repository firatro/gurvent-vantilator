using FluentValidation;
using GurventVantilator.AdminUI.Models.Product;
using GurventVantilator.AdminUI.Validators.Common;
using System.Globalization;
using System.Linq.Expressions;

namespace GurventVantilator.AdminUI.Validators
{
    public class ProductEditViewModelValidator : AbstractValidator<ProductEditViewModel>
    {
        public ProductEditViewModelValidator()
        {
            // ======================================================
            // 🧱 TEMEL ALANLAR
            // ======================================================
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün adı zorunludur.")
                .MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Ürün kodu zorunludur.")
                .MaximumLength(50).WithMessage("Ürün kodu en fazla 50 karakter olabilir.");

            // ======================================================
            // 🔹 SERİ / MODEL SEÇİMİ
            // ======================================================
            RuleFor(x => x.ProductSeriesId)
                .NotNull().WithMessage("Lütfen bir seri seçiniz.")
                .GreaterThan(0).WithMessage("Lütfen bir seri seçiniz.");

            RuleFor(x => x.ProductModelId)
                .NotNull().WithMessage("Lütfen bir model seçiniz.")
                .GreaterThan(0).WithMessage("Lütfen bir model seçiniz.");

            // ======================================================
            // ⚙️ PERFORMANS PARAMETRELERİ
            // ======================================================
            ValidateNumeric(x => x.AirFlow, "Hava debisi geçerli bir sayı olmalıdır.");
            ValidateNumeric(x => x.TotalPressure, "Basınç değeri geçerli bir sayı olmalıdır.");
            ValidateNumeric(x => x.Power, "Güç değeri geçerli bir sayı olmalıdır.");
            ValidateNumeric(x => x.Voltage, "Voltaj değeri geçerli bir sayı olmalıdır.");
            ValidateNumeric(x => x.Frequency, "Frekans değeri geçerli bir sayı olmalıdır.");

            RuleFor(x => x.SpeedControl)
                .NotEmpty().WithMessage("Lütfen bir hız kontrol tipi giriniz.")
                .MaximumLength(100).WithMessage("Hız kontrol tipi en fazla 100 karakter olabilir.");

            // ======================================================
            // 🔹 UNIT ALANLARI
            // ======================================================
            RuleFor(x => x.AirFlowUnit).MaximumLength(10);
            RuleFor(x => x.TotalPressureUnit).MaximumLength(10);

            // ======================================================
            // 🖼️ DOSYA ALANLARI
            // ======================================================
            // Edit modunda dosyalar zorunlu değil ama format kontrolü yapılır
            RuleFor(x => x.Image1File).ValidImageFile();
            RuleFor(x => x.Image2File).ValidImageFile();
            RuleFor(x => x.Image3File).ValidImageFile();
            RuleFor(x => x.Image4File).ValidImageFile();
            RuleFor(x => x.Image5File).ValidImageFile();

            RuleFor(x => x.DataSheetFile).ValidPdfFile();
            RuleFor(x => x.Model3DFile).Valid3DFile();
            RuleFor(x => x.TestDataFile).ValidXSLFile();
            RuleFor(x => x.ScaleImageFile).ValidImageFile();

            // ======================================================
            // 📄 İÇERİK ALANLARI
            // ======================================================
            RuleFor(x => x.ContentTitle)
                .MaximumLength(150).WithMessage("İçerik başlığı en fazla 150 karakter olabilir.");

            RuleFor(x => x.ContentDescription)
                .MaximumLength(1000).WithMessage("İçerik açıklaması en fazla 1000 karakter olabilir.");

            // ======================================================
            // 🔹 SIRA / DURUM
            // ======================================================
            RuleFor(x => x.Order)
                .NotNull().WithMessage("Sıra numarası boş bırakılamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Sıra numarası negatif olamaz.");
        }

        // ======================================================
        // 🔧 SAYISAL KONTROL (kültür bağımsız)
        // ======================================================
        private void ValidateNumeric(Expression<Func<ProductEditViewModel, string?>> selector, string message)
        {
            RuleFor(selector)
                .Must(v => string.IsNullOrWhiteSpace(v) ||
                           double.TryParse(v.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                .WithMessage(message);
        }
    }
}
