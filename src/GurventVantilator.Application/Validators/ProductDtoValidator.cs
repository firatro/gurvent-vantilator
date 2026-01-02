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

            RuleFor(x => x.AirFlow)
                .GreaterThanOrEqualTo(0).When(x => x.AirFlow.HasValue)
                .WithMessage("Hava debisi negatif olamaz.");

            RuleFor(x => x.TotalPressure)
                .GreaterThanOrEqualTo(0).When(x => x.TotalPressure.HasValue)
                .WithMessage("Basınç negatif olamaz.");

            RuleFor(x => x.Voltage)
                .MaximumLength(10).WithMessage("Ürün kodu en fazla 10 karakter olabilir.");

            RuleFor(x => x.Frequency)
                .GreaterThan(0).When(x => x.Frequency.HasValue)
                .WithMessage("Frekans değeri 0'dan büyük olmalıdır.");

            RuleFor(x => x.SpeedControl)
                .NotEmpty().WithMessage("Speed Control zorunludur.");

            RuleFor(x => x.AirFlowUnit)
                .MaximumLength(10).When(x => !string.IsNullOrEmpty(x.AirFlowUnit));

            RuleFor(x => x.TotalPressureUnit)
                .MaximumLength(10).When(x => !string.IsNullOrEmpty(x.TotalPressureUnit));


            // 🔹 Sıralama
            RuleFor(x => x.Order)
                .NotNull().WithMessage("Sıra numarası boş bırakılamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Sıra numarası negatif olamaz.");
        }
    }
}
