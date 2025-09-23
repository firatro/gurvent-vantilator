using GurventVantilator.AdminUI.Models.BeforeAfter;
using GurventVantilator.AdminUI.Validators.Common;
using FluentValidation;
namespace GurventVantilator.AdminUI.Validators
{
    public class BeforeAfterEditViewModelValidator : AbstractValidator<BeforeAfterEditViewModel>
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long _maxFileSize = 2 * 1024 * 1024; // 2 MB

        public BeforeAfterEditViewModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı zorunludur.")
                .MaximumLength(150).WithMessage("Başlık en fazla 150 karakter olabilir.");


            RuleFor(x => x.Subtitle)
                .NotEmpty().WithMessage("Alt başlık alanı zorunludur.")
                .MaximumLength(250).WithMessage("Alt başlık en fazla 250 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı zorunludur.")
                .MaximumLength(20000).WithMessage("Açıklama en fazla 1000 karakter olabilir.");

            RuleFor(x => x.BeforeImageFile).ValidImageFile();
            RuleFor(x => x.AfterImageFile).ValidImageFile();
        }
    }
}