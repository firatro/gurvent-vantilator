using FluentValidation;
using GurventVantilator.AdminUI.Models.PageImage;
using GurventVantilator.AdminUI.Validators.Common;

namespace GurventVantilator.AdminUI.Validators.PageImage
{
    public class PageImageCreateViewModelValidator : AbstractValidator<PageImageCreateViewModel>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long _maxFileSize = 5 * 1024 * 1024; // 5 MB

        public PageImageCreateViewModelValidator()
        {
            RuleFor(x => x.PageKey)
                .NotEmpty().WithMessage("Sayfa alanı zorunludur.")
                .MaximumLength(150).WithMessage("Sayfa en fazla 150 karakter olabilir.");

            RuleFor(x => x.ImageType)
                .NotEmpty().WithMessage("Görsel türü zorunludur.")
                .MaximumLength(150).WithMessage("Firma adı en fazla 150 karakter olabilir.");

            RuleFor(x => x.ImageFile)
                .NotNull().WithMessage("Görsel yüklenmelidir.")
                .ValidImageFile();
        }
    }
}
