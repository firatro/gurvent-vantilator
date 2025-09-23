using FluentValidation;
using GurventVantilator.AdminUI.Models.Testimonial;
using GurventVantilator.AdminUI.Validators.Common;

namespace GurventVantilator.AdminUI.Validators
{
    public class TestimonialEditViewModelValidator : AbstractValidator<TestimonialEditViewModel>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long _maxFileSize = 5 * 1024 * 1024;

        public TestimonialEditViewModelValidator()
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

            RuleFor(x => x.ImageFile).ValidImageFile();

        }
    }
}
