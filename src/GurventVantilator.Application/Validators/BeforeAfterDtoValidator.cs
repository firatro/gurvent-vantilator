using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class BeforeAfterDtoValidator : AbstractValidator<BeforeAfterDto>
    {
        public BeforeAfterDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı zorunludur.")
                .MaximumLength(150).WithMessage("Başlık en fazla 150 karakter olabilir.");

            RuleFor(x => x.Subtitle)
                .MaximumLength(250).WithMessage("Alt başlık en fazla 250 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı zorunludur.")
                .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.");

        }
    }
}
