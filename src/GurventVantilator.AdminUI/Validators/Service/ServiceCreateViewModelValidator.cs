using GurventVantilator.AdminUI.Models.Service;
using GurventVantilator.AdminUI.Validators.Common;
using FluentValidation;

namespace GurventVantilator.AdminUI.Validators
{
    public class ServiceCreateViewModelValidator : AbstractValidator<ServiceCreateViewModel>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long _maxFileSize = 5 * 1024 * 1024; // 5 MB

        public ServiceCreateViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Hizmet adı zorunludur.")
                .MaximumLength(150).WithMessage("Hizmet adı en fazla 150 karakter olabilir.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık zorunludur.")
                .MaximumLength(1000).WithMessage("Başlık en fazla 1000 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama zorunludur.")
                .MaximumLength(20000).WithMessage("Açıklama en fazla 20000 karakter olabilir.");

            RuleFor(x => x.ExtraTitle)
                .MaximumLength(1000).WithMessage("Ek başlık en fazla 1000 karakter olabilir.");

            RuleFor(x => x.ExtraDescription)
                .MaximumLength(20000).WithMessage("Ek Açıklama en fazla 20000 karakter olabilir.");

            RuleFor(x => x.MainImageFile)
                .NotNull().WithMessage("Ana görsel yüklenmelidir.")
                .ValidImageFile();

            RuleFor(x => x.ContentImage1File)
                .NotNull().WithMessage("İçerik Görsel (1) yüklenmelidir.")
                .ValidImageFile();

            RuleFor(x => x.ContentImage2File)
                .NotNull().WithMessage("İçerik Görsel (2) yüklenmelidir.")
                .ValidImageFile();

            RuleFor(x => x.LogoFile)
                .NotNull().WithMessage("Logo yüklenmelidir.")
                .ValidImageFile();
        }
    }
}
