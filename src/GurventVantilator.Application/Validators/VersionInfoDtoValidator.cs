using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class VersionInfoDtoValidator : AbstractValidator<VersionInfoDto>
    {
        public VersionInfoDtoValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama zorunludur.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı zorunludur.")
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            RuleFor(x => x.ReleaseDate)
                .NotEmpty().WithMessage("Tarih alanı zorunludur.");

            RuleFor(x => x.VersionNumber)
                .NotEmpty().WithMessage("Versiyon alanı zorunludur.");
        }
    }
}
