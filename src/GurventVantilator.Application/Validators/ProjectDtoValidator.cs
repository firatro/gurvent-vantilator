using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class ProjectDtoValidator : AbstractValidator<ProjectDto>
    {
        public ProjectDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Proje başlığı zorunludur.")
                .MaximumLength(150).WithMessage("Başlık en fazla 150 karakter olabilir.");

            RuleFor(x => x.Subtitle)
                .NotEmpty().WithMessage("Proje alt başlığı zorunludur.")
                .MaximumLength(250).WithMessage("Alt başlık en fazla 250 karakter olabilir.");

            RuleFor(x => x.IntroText)
                .NotEmpty().WithMessage("Giriş metni zorunludur.")
                .MaximumLength(500).WithMessage("Giriş metni en fazla 500 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı zorunludur.")
                .MaximumLength(20000).WithMessage("Açıklama en fazla 20000 karakter olabilir.");

            RuleFor(x => x.CustomerInfo)
                .NotEmpty().WithMessage("Müşteri bilgisi zorunludur.")
                .MaximumLength(250).WithMessage("Müşteri bilgisi en fazla 250 karakter olabilir.");

             RuleFor(x => x.ProjectDate)
                .NotEmpty().WithMessage("Proje tarihi zorunludur.");
        }
    }
}
