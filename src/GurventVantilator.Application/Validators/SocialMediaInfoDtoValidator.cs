using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class SocialMediaInfoDtoValidator : AbstractValidator<SocialMediaInfoDto>
    {
        public SocialMediaInfoDtoValidator()
        {
            RuleFor(x => x.Facebook)
                .MaximumLength(250).WithMessage("Facebook adresi en fazla 250 karakter olabilir.");

            RuleFor(x => x.Instagram)
                .MaximumLength(250).WithMessage("Instagram adresi en fazla 250 karakter olabilir.");

            RuleFor(x => x.Youtube)
                .MaximumLength(250).WithMessage("Youtube adresi en fazla 250 karakter olabilir.");

            RuleFor(x => x.X)
                .MaximumLength(250).WithMessage("X adresi en fazla 250 karakter olabilir.");

            RuleFor(x => x.Tiktok)
                .MaximumLength(250).WithMessage("Tiktok adresi en fazla 250 karakter olabilir.");
        }
    }
}
