using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
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

            // 🔹 Sayısal teknik bilgiler (opsiyonel ama varsa geçerli aralıkta olmalı)
            RuleFor(x => x.Diameter)
                .GreaterThan(0).When(x => x.Diameter.HasValue)
                .WithMessage("Çap değeri 0'dan büyük olmalıdır.");

            RuleFor(x => x.AirFlow)
                .GreaterThanOrEqualTo(0).When(x => x.AirFlow.HasValue)
                .WithMessage("Hava debisi negatif olamaz.");

            RuleFor(x => x.Pressure)
                .GreaterThanOrEqualTo(0).When(x => x.Pressure.HasValue)
                .WithMessage("Basınç negatif olamaz.");

            RuleFor(x => x.Power)
                .GreaterThan(0).When(x => x.Power.HasValue)
                .WithMessage("Güç değeri 0'dan büyük olmalıdır.");

            RuleFor(x => x.Voltage)
                .GreaterThan(0).When(x => x.Voltage.HasValue)
                .WithMessage("Voltaj değeri 0'dan büyük olmalıdır.");

            RuleFor(x => x.Frequency)
                .GreaterThan(0).When(x => x.Frequency.HasValue)
                .WithMessage("Frekans değeri 0'dan büyük olmalıdır.");

            RuleFor(x => x.Speed)
                .GreaterThan(0).When(x => x.Speed.HasValue)
                .WithMessage("Devir sayısı 0'dan büyük olmalıdır.");

            RuleFor(x => x.NoiseLevel)
                .GreaterThanOrEqualTo(0).When(x => x.NoiseLevel.HasValue)
                .WithMessage("Ses seviyesi negatif olamaz.");

            RuleFor(x => x.SpeedControl)
                .NotEmpty().WithMessage("Speed Control zorunludur.");

            // 🔹 Birim alanları (opsiyonel ama girildiyse uzunluk sınırı)
            RuleFor(x => x.DiameterUnit)
                .MaximumLength(10).When(x => !string.IsNullOrEmpty(x.DiameterUnit));

            RuleFor(x => x.AirFlowUnit)
                .MaximumLength(10).When(x => !string.IsNullOrEmpty(x.AirFlowUnit));

            RuleFor(x => x.PressureUnit)
                .MaximumLength(10).When(x => !string.IsNullOrEmpty(x.PressureUnit));

            RuleFor(x => x.PowerUnit)
                .MaximumLength(10).When(x => !string.IsNullOrEmpty(x.PowerUnit));

            // 🔹 Sıralama
            RuleFor(x => x.Order)
                .NotNull().WithMessage("Sıra numarası boş bırakılamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Sıra numarası negatif olamaz.");
        }
    }
}
