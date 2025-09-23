using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class CompanyDtoValidator : AbstractValidator<CompanyDto>
    {
        public CompanyDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Firma adı zorunludur.")
                .MaximumLength(200).WithMessage("Firma adı en fazla 200 karakter olabilir.");
        }
    }
}

