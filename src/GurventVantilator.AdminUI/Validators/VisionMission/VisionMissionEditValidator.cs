using GurventVantilator.AdminUI.Models.VisionMission;
using GurventVantilator.AdminUI.Validators.Common;
using FluentValidation;
namespace GurventVantilator.AdminUI.Validators
{
    public class VisionMissionEditViewModelValidator : AbstractValidator<VisionMissionEditViewModel>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long _maxFileSize = 2 * 1024 * 1024; // 2 MB

        public VisionMissionEditViewModelValidator()
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

            RuleFor(x => x.VisionImageFile).ValidImageFile();

            RuleFor(x => x.MissionImageFile).ValidImageFile();
        }
    }
}