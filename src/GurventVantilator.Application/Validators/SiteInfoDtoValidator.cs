using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class SiteInfoDtoValidator : AbstractValidator<SiteInfoDto>
    {
        public SiteInfoDtoValidator()
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
        }
    }
}
