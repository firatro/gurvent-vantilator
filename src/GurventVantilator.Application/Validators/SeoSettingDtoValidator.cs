using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class SeoSettingDtoValidator : AbstractValidator<SeoSettingDto>
    {
        public SeoSettingDtoValidator()
        {
            RuleFor(x => x.SiteName)
                .NotEmpty().WithMessage("Site adı zorunludur.")
                .MaximumLength(200).WithMessage("Site adı en fazla 200 karakter olabilir.");

            RuleFor(x => x.DefaultTitle)
                .NotEmpty().WithMessage("Site başlığı zorunludur.")
                .MaximumLength(150).WithMessage("Varsayılan başlık en fazla 150 karakter olabilir.");

            RuleFor(x => x.DefaultMetaDescription)
                .MaximumLength(300).WithMessage("Meta açıklama en fazla 300 karakter olabilir.");

            RuleFor(x => x.DefaultMetaKeywords)
                .MaximumLength(300).WithMessage("Meta anahtar kelimeler en fazla 300 karakter olabilir.");
        }
    }
}
