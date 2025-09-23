using FluentValidation;
using GurventVantilator.AdminUI.Models.Slider;
using GurventVantilator.AdminUI.Validators.Common;

namespace GurventVantilator.AdminUI.Validators
{
    public class SliderEditViewModelValidator : AbstractValidator<SliderEditViewModel>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long _maxFileSize = 5 * 1024 * 1024;

        public SliderEditViewModelValidator()
        {
            RuleFor(x => x.Tag)
                .NotEmpty().WithMessage("Etiket alanı zorunludur.")
                .MaximumLength(100).WithMessage("Etiket en fazla 100 karakter olabilir.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı zorunludur.")
                .MaximumLength(250).WithMessage("Başlık en fazla 250 karakter olabilir.");

            RuleFor(x => x.Subtitle)
                .NotEmpty().WithMessage("Alt başlık alanı zorunludur.")
                .MaximumLength(500).WithMessage("Alt başlık en fazla 500 karakter olabilir.");

            RuleFor(x => x.ImageFile).ValidImageFile();

        }
    }
}
