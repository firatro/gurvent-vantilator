using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class SliderDtoValidator : AbstractValidator<SliderDto>
    {
        public SliderDtoValidator()
        {
            RuleFor(x => x.Tag)
                .NotEmpty().WithMessage("Etiket alanı zorunludur.")
                .MaximumLength(100).WithMessage("Etiket en fazla 100 karakter olabilir.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı zorunludur.")
                .MaximumLength(250).WithMessage("Başlık en fazla 250 karakter olabilir.");

            RuleFor(x => x.Subtitle)
                .NotEmpty().WithMessage("Alt başlık alanı zorunludur.")
                .MaximumLength(500).WithMessage("Alt başlık en fazla 500 karakter olabilir.");
        }
    }
}
