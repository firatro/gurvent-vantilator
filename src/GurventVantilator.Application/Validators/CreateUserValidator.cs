using GurventVantilator.Application.DTOs;
using FluentValidation;

namespace GurventVantilator.AdminUI.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı zorunludur.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre zorunludur.")
                .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad zorunludur.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad zorunludur.");
        }
    }
}
