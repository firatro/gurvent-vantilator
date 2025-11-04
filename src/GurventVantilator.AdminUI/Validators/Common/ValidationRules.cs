using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace GurventVantilator.AdminUI.Validators.Common
{
    public static class ValidationRules
    {
        // Görseller
        private static readonly string[] _allowedImageExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        // PDF dosyaları
        private static readonly string[] _allowedPdfExtensions = { ".pdf" };
        // 3D model dosyaları
        private static readonly string[] _allowed3DExtensions = { ".glb", ".stl" };
        private static readonly string[] _allowedXLSExtensions = { ".xls", ".xlsx" };

        private const long _maxImageFileSize = 10 * 1024 * 1024; // 10 MB
        private const long _maxPdfFileSize = 10 * 1024 * 1024;   // 10 MB
        private const long _max3DFileSize = 10 * 1024 * 1024;    // 10 MB
        private const long _maxXLSFileSize = 10 * 1024 * 1024;    // 10 MB

        // 🔹 Görsel dosyalar için doğrulama
        public static IRuleBuilderOptions<T, IFormFile?> ValidImageFile<T>(
            this IRuleBuilder<T, IFormFile?> ruleBuilder)
        {
            return ruleBuilder
                .Must(file => file == null || file.Length <= _maxImageFileSize)
                    .WithMessage($"Görsel dosya boyutu {_maxImageFileSize / 1024 / 1024} MB’ı geçemez.")
                .Must(file => file == null || _allowedImageExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
                    .WithMessage("Sadece .jpg, .jpeg, .png, .webp formatları desteklenmektedir.");
        }

        // 🔹 PDF dosyalar için doğrulama
        public static IRuleBuilderOptions<T, IFormFile?> ValidPdfFile<T>(
            this IRuleBuilder<T, IFormFile?> ruleBuilder)
        {
            return ruleBuilder
                .Must(file => file == null || file.Length <= _maxPdfFileSize)
                    .WithMessage($"PDF dosya boyutu {_maxPdfFileSize / 1024 / 1024} MB’ı geçemez.")
                .Must(file => file == null || _allowedPdfExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
                    .WithMessage("Sadece .pdf formatı desteklenmektedir.");
        }

        // 🔹 3D model dosyalar için doğrulama
        public static IRuleBuilderOptions<T, IFormFile?> Valid3DFile<T>(
            this IRuleBuilder<T, IFormFile?> ruleBuilder)
        {
            return ruleBuilder
                .Must(file => file == null || file.Length <= _max3DFileSize)
                    .WithMessage($"3D model dosya boyutu {_max3DFileSize / 1024 / 1024} MB’ı geçemez.")
                .Must(file => file == null || _allowed3DExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
                    .WithMessage("Sadece .glb ve .stl formatları desteklenmektedir.");
        }
        public static IRuleBuilderOptions<T, IFormFile?> ValidXSLFile<T>(
            this IRuleBuilder<T, IFormFile?> ruleBuilder)
        {
            return ruleBuilder
                .Must(file => file == null || file.Length <= _maxXLSFileSize)
                    .WithMessage($"Test data dosya boyutu {_maxXLSFileSize / 1024 / 1024} MB’ı geçemez.")
                .Must(file => file == null || _allowedXLSExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
                    .WithMessage("Sadece .xls ve .xlsx formatları desteklenmektedir.");
        }
    }
}
