using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class ChatBotQADtoValidator : AbstractValidator<ChatBotQADto>
    {
        public ChatBotQADtoValidator()
        {
            RuleFor(x => x.LanguageCode)
                .NotEmpty().WithMessage("Dil kodu zorunludur.");

            RuleFor(x => x.Question)
                .NotEmpty().WithMessage("Soru alanı zorunludur.")
                .MaximumLength(500).WithMessage("Soru en fazla 500 karakter olabilir.");

            RuleFor(x => x.Answer)
                .NotEmpty().WithMessage("Cevap alanı zorunludur.")
                .MaximumLength(1000).WithMessage("Cevap en fazla 1000 karakter olabilir.");
        }
    }
}
