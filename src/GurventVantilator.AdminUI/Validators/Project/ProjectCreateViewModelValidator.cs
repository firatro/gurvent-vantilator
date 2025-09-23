using FluentValidation;
using GurventVantilator.AdminUI.Models.Project;
using GurventVantilator.AdminUI.Validators.Common;

namespace GurventVantilator.AdminUI.Validators
{
    public class ProjectCreateViewModelValidator : AbstractValidator<ProjectCreateViewModel>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long _maxFileSize = 5 * 1024 * 1024; // 5 MB

        public ProjectCreateViewModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Proje başlığı zorunludur.")
                .MaximumLength(150).WithMessage("Başlık en fazla 150 karakter olabilir.");

            RuleFor(x => x.Subtitle)
                .NotEmpty().WithMessage("Proje alt başlığı zorunludur.")
                .MaximumLength(250).WithMessage("Alt başlık en fazla 250 karakter olabilir.");

            RuleFor(x => x.IntroText)
                .NotEmpty().WithMessage("Giriş metni zorunludur.")
                .MaximumLength(500).WithMessage("Giriş metni en fazla 500 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı zorunludur.")
                .MaximumLength(20000).WithMessage("Açıklama en fazla 20000 karakter olabilir.");

            RuleFor(x => x.CustomerInfo)
                .NotEmpty().WithMessage("Müşteri bilgisi zorunludur.")
                .MaximumLength(250).WithMessage("Müşteri bilgisi en fazla 250 karakter olabilir.");

            RuleFor(x => x.ProjectDate)
               .NotEmpty().WithMessage("Proje tarihi zorunludur.");

            RuleFor(x => x.MainImageFile)
                .NotNull().WithMessage("Ana görsel yüklenmelidir.")
                .Must(file => file == null || file.Length <= _maxFileSize)
                    .WithMessage("Ana görsel 5 MB’tan büyük olamaz.")
                .Must(file => file == null || _allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
                    .WithMessage("Ana görsel yalnızca .jpg, .jpeg, .png, .webp formatında olabilir.");

            RuleFor(x => x.ContentImage1File)
                .NotNull().WithMessage("İçerik Görsel (1) yüklenmelidir.")
                .ValidImageFile();

            RuleFor(x => x.ContentImage2File)
                .NotNull().WithMessage("İçerik Görsel (2) yüklenmelidir.")
                .ValidImageFile();
        }
    }
}
