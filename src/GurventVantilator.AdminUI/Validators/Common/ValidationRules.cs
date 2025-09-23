using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace GurventVantilator.AdminUI.Validators.Common
{
    public static class ValidationRules
    {
        private static readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long _maxFileSize = 2 * 1024 * 1024; // 2 MB

        public static IRuleBuilderOptions<T, IFormFile?> ValidImageFile<T>(
            this IRuleBuilder<T, IFormFile?> ruleBuilder)
        {
            return ruleBuilder
                .Must(file => file == null || file.Length <= _maxFileSize)
                    .WithMessage($"Dosya boyutu {_maxFileSize / 1024 / 1024} MB’ı geçemez.")
                .Must(file => file == null || _allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
                    .WithMessage("Sadece .jpg, .jpeg, .png, .webp formatları desteklenmektedir.");
        }
    }
}
