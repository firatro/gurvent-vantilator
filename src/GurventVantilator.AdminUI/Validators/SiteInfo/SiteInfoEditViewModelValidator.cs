using GurventVantilator.AdminUI.Models.SiteInfo;
using GurventVantilator.AdminUI.Validators.Common;
using FluentValidation;
namespace GurventVantilator.AdminUI.Validators
{
    public class SiteInfoEditViewModelValidator : AbstractValidator<SiteInfoEditViewModel>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long _maxFileSize = 2 * 1024 * 1024; // 2 MB

        public SiteInfoEditViewModelValidator()
        {
            RuleFor(x => x.Phone1)
                .NotEmpty().WithMessage("Telefon (1) alanı zorunludur.");

            RuleFor(x => x.Email1)
                .NotEmpty().WithMessage("E-posta (1) alanı zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.Email2)
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.SiteName)
                .NotEmpty().WithMessage("Site adı zorunludur.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres alanı zorunludur.");

            RuleFor(x => x.SiteInformation)
                .MaximumLength(500).WithMessage("Tanıtım en fazla 500 karakter olabilir.");

            RuleFor(x => x.LogoFile).ValidImageFile();
        }
    }
}