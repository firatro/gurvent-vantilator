using FluentValidation;
using GurventVantilator.AdminUI.Models.TeamMember;
using GurventVantilator.AdminUI.Validators.Common;

namespace GurventVantilator.AdminUI.Validators
{
    public class TeamMemberCreateViewModelValidator : AbstractValidator<TeamMemberCreateViewModel>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long _maxFileSize = 5 * 1024 * 1024; // 5 MB

        public TeamMemberCreateViewModelValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Ad Soyad zorunludur.")
                .MaximumLength(150).WithMessage("Ad Soyad en fazla 150 karakter olabilir.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Unvan alanı zorunludur.")
                .MaximumLength(100).WithMessage("Unvan en fazla 100 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.Phone)
                .MaximumLength(20).WithMessage("Telefon numarası en fazla 20 karakter olabilir.");

            RuleFor(x => x.Biography)
                .MaximumLength(10000).WithMessage("Biyografi en fazla 10000 karakter olabilir.");

            RuleFor(x => x.ImageFile)
                .NotNull().WithMessage("Ana görsel yüklenmelidir.")
                .ValidImageFile();
        }
    }
}
