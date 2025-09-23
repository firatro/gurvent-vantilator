using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class VisionMissionDtoValidator : AbstractValidator<VisionMissionDto>
    {
        public VisionMissionDtoValidator()
        {
            RuleFor(x => x.VisionTitle)
                .NotEmpty().WithMessage("Vizyon başlığı zorunludur.")
                .MaximumLength(150).WithMessage("Vizyon başlığı en fazla 150 karakter olabilir.");

            RuleFor(x => x.VisionDescription)
                .NotEmpty().WithMessage("Vizyon açıklaması zorunludur.")
                .MaximumLength(10000).WithMessage("Vizyon açıklaması en fazla 10000 karakter olabilir.");

            RuleFor(x => x.MissionTitle)
                .NotEmpty().WithMessage("Misyon başlığı zorunludur.")
                .MaximumLength(150).WithMessage("Misyon başlığı en fazla 150 karakter olabilir.");

            RuleFor(x => x.MissionDescription)
                .NotEmpty().WithMessage("Misyon açıklaması zorunludur.")
                .MaximumLength(10000).WithMessage("Misyon açıklaması en fazla 10000 karakter olabilir.");
        }
    }
}
