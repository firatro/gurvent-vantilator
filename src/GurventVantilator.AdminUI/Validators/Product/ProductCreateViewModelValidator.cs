using FluentValidation;
using GurventVantilator.AdminUI.Models.Product;
using GurventVantilator.AdminUI.Validators.Common;
using System.Globalization;
using System.Linq.Expressions;

namespace GurventVantilator.AdminUI.Validators
{
    public class ProductCreateViewModelValidator : AbstractValidator<ProductCreateViewModel>
    {
        public ProductCreateViewModelValidator()
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

            RuleFor(x => x.SpeedControl)
                .NotEmpty().WithMessage("Speed Control zorunludur.");

            // 🔹 Sayısal alanlar (kültür bağımsız)
            ValidateNumeric(x => x.Diameter, "Çap değeri geçerli bir sayı olmalıdır.");
            ValidateNumeric(x => x.AirFlow, "Hava debisi geçerli bir sayı olmalıdır.");
            ValidateNumeric(x => x.Pressure, "Basınç geçerli bir sayı olmalıdır.");
            ValidateNumeric(x => x.Power, "Güç değeri geçerli bir sayı olmalıdır.");
            ValidateNumeric(x => x.Voltage, "Voltaj değeri geçerli bir sayı olmalıdır.");
            ValidateNumeric(x => x.Frequency, "Frekans değeri geçerli bir sayı olmalıdır.");
            ValidateNumeric(x => x.Speed, "Devir değeri geçerli bir sayı olmalıdır.");
            ValidateNumeric(x => x.NoiseLevel, "Ses seviyesi geçerli bir sayı olmalıdır.");

            // 🔹 Unit alanları
            RuleFor(x => x.DiameterUnit).MaximumLength(10);
            RuleFor(x => x.AirFlowUnit).MaximumLength(10);
            RuleFor(x => x.PressureUnit).MaximumLength(10);
            RuleFor(x => x.PowerUnit).MaximumLength(10);
            RuleFor(x => x.SpeedUnit).MaximumLength(10);
            RuleFor(x => x.NoiseLevelUnit).MaximumLength(10);

            // 🔹 Sıralama
            RuleFor(x => x.Order)
                .NotNull().WithMessage("Sıra numarası boş bırakılamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Sıra numarası negatif olamaz.");

            // 🔹 Dosyalar
            RuleFor(x => x.Image1File)
                .NotNull().WithMessage("Görsel yüklenmelidir.")
                .ValidImageFile();
            RuleFor(x => x.Image2File)
                .NotNull().WithMessage("Görsel yüklenmelidir.")
                .ValidImageFile();
            RuleFor(x => x.Image3File)
                .NotNull().WithMessage("Görsel yüklenmelidir.")
                .ValidImageFile();
            RuleFor(x => x.Image4File)
                .NotNull().WithMessage("Görsel yüklenmelidir.")
                .ValidImageFile();
            RuleFor(x => x.Image5File)
                .NotNull().WithMessage("Görsel yüklenmelidir.")
                .ValidImageFile();

            RuleFor(x => x.DataSheetFile).ValidPdfFile();
            RuleFor(x => x.Model3DFile).Valid3DFile();
            RuleFor(x => x.TestDataFile).ValidXSLFile();

            RuleFor(x => x.ScaleImageFile).ValidImageFile();
        }

        // ✅ Expression versiyonu
        private void ValidateNumeric(Expression<Func<ProductCreateViewModel, string?>> selector, string message)
        {
            RuleFor<string?>(selector)
                .Must(v => string.IsNullOrWhiteSpace(v) ||
                           double.TryParse(v.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                .WithMessage(message);
        }
    }
}
