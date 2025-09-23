using FluentValidation;
using GurventVantilator.AdminUI.Models.Company;
using GurventVantilator.AdminUI.Validators.Common;

namespace GurventVantilator.AdminUI.Validators.Company
{
    public class CompanyCreateViewModelValidator : AbstractValidator<CompanyCreateViewModel>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long _maxFileSize = 2 * 1024 * 1024; // 2 MB

        public CompanyCreateViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Firma adı zorunludur.")
                .MaximumLength(200).WithMessage("Firma adı en fazla 200 karakter olabilir.");

            RuleFor(x => x.LogoFile)
                .NotNull().WithMessage("Logo yüklenmelidir.")
                .ValidImageFile();
        }
    }
}
