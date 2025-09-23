using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class AboutUsDtoValidator : AbstractValidator<AboutUsDto>
    {
        public AboutUsDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı zorunludur.")
                .MaximumLength(150).WithMessage("Başlık en fazla 150 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı zorunludur.")
                .MaximumLength(20000).WithMessage("Açıklama en fazla 1000 karakter olabilir.");

            RuleFor(x => x.ExtraDescription)
                .MaximumLength(20000).WithMessage("Ek açıklama en fazla 20000 karakter olabilir.");

            RuleFor(x => x.ExperienceYear)
                .GreaterThanOrEqualTo(0).WithMessage("Deneyim yılı negatif olamaz.");

            RuleFor(x => x.HappyClients)
                .GreaterThanOrEqualTo(0).WithMessage("Mutlu müşteri sayısı negatif olamaz.");

            RuleFor(x => x.CompletedProjects)
                .GreaterThanOrEqualTo(0).WithMessage("Tamamlanan proje sayısı negatif olamaz.");

            RuleFor(x => x.Awards)
                .GreaterThanOrEqualTo(0).WithMessage("Ödül sayısı negatif olamaz.");
        }
    }
}
