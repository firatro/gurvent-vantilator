using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class TagDtoValidator : AbstractValidator<TagDto>
    {
        public TagDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Etiket adı zorunludur.")
                .MaximumLength(100).WithMessage("Etiket adı en fazla 100 karakter olabilir.");
        }
    }
}
