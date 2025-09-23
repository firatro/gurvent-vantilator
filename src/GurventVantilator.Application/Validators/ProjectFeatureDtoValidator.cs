using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class ProjectFeatureDtoValidator : AbstractValidator<ProjectFeatureDto>
    {
        public ProjectFeatureDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Özellik adı zorunludur.")
                .MaximumLength(150).WithMessage("Özellik adı en fazla 150 karakter olabilir.");

            RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("Proje zorunludur.");
        }
    }
}
