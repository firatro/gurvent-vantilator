using GurventVantilator.AdminUI.Models.Blog;
using GurventVantilator.AdminUI.Validators.Common;
using FluentValidation;

namespace GurventVantilator.AdminUI.Validators
{
    public class BlogCreateViewModelValidator : AbstractValidator<BlogCreateViewModel>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long _maxFileSize = 5 * 1024 * 1024; // 5 MB

        public BlogCreateViewModelValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Yazar adı zorunludur.")
                .MaximumLength(100).WithMessage("Yazar adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.CategoryId)
                .NotEqual(0)
                .WithMessage("Kategori zorunludur.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Blog başlığı zorunludur.")
                .MaximumLength(150).WithMessage("Başlık en fazla 150 karakter olabilir.");

            RuleFor(x => x.Subtitle)
                .NotEmpty().WithMessage("Blog başlığı zorunludur.")
                .MaximumLength(250).WithMessage("Alt başlık en fazla 250 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama zorunludur.")
                .MaximumLength(20000).WithMessage("Açıklama en fazla 20000 karakter olabilir.");

            RuleFor(x => x.EntryTitle)
                .NotEmpty().WithMessage("Giriş başlığı zorunludur.")
                .MaximumLength(150).WithMessage("Giriş başlığı en fazla 150 karakter olabilir.");

            RuleFor(x => x.EntryDescription)
                .NotEmpty().WithMessage("Giriş açıklama zorunludur.")
                .MaximumLength(20000).WithMessage("Giriş açıklaması en fazla 20000 karakter olabilir.");

            RuleFor(x => x.Quote)
                .MaximumLength(500).WithMessage("Alıntı en fazla 500 karakter olabilir.");

            RuleFor(x => x.QuoteSource)
                .MaximumLength(250).WithMessage("Alıntı kaynağı en fazla 250 karakter olabilir.");

            RuleFor(x => x.MainImageFile)
                .NotNull().WithMessage("Ana görsel yüklenmelidir.")
                .ValidImageFile();

            RuleFor(x => x.ContentImage1File)
                .NotNull().WithMessage("İçerik Görsel (1) yüklenmelidir.")
                .ValidImageFile();

            RuleFor(x => x.ContentImage2File)
                .NotNull().WithMessage("İçerik Görsel (2) yüklenmelidir.")
                .ValidImageFile();
        }
    }
}
