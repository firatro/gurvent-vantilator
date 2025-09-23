using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class PageImageDtoValidator : AbstractValidator<PageImageDto>
    {
        public PageImageDtoValidator()
        {
            RuleFor(x => x.PageKey)
                .NotEmpty().WithMessage("Sayfa anahtarı zorunludur.")
                .MaximumLength(100).WithMessage("Sayfa anahtarı en fazla 100 karakter olabilir.");

            RuleFor(x => x.ImageType)
                .NotEmpty().WithMessage("Görsel tipi zorunludur.");
        }
    }
}
