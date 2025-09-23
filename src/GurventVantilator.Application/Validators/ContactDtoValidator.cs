using FluentValidation;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Validators
{
    public class ContactDtoValidator : AbstractValidator<ContactDto>
    {
        public ContactDtoValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Boş bırakılamaz")
                .MaximumLength(100).WithMessage("100 karakter sınırını aşamazsınız");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Boş bırakılamaz")
                .EmailAddress().WithMessage("Geçersiz e-posta adresi");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Geçersiz telefon numarası");

            RuleFor(x => x.Subject)
                .MaximumLength(200).WithMessage("200 karakter sınırını aşamazsınız");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Boş bırakılamaz");

            RuleFor(x => x.Notes).NotEmpty().WithMessage("Boş bırakılamaz");
        }
    }
}