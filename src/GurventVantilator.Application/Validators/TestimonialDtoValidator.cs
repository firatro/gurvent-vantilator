using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class TestimonialDtoValidator : AbstractValidator<TestimonialDto>
    {
        public TestimonialDtoValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Ad Soyad zorunludur.")
                .MaximumLength(150).WithMessage("Ad Soyad en fazla 150 karakter olabilir.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Unvan alanı zorunludur.")
                .MaximumLength(100).WithMessage("Unvan en fazla 100 karakter olabilir.");

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Yorum alanı zorunludur.")
                .MaximumLength(1000).WithMessage("Yorum en fazla 1000 karakter olabilir.");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).When(x => x.Rating.HasValue)
                .WithMessage("Puan 1 ile 5 arasında olmalıdır.");
        }
    }
}
