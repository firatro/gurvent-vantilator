using GurventVantilator.Application.Enums;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace GurventVantilator.Infrastructure.Services
{
    public class FileValidator : IFileValidator
    {
        private const long _maxFileSize = 10 * 1024 * 1024; // 10 MB
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp", ".xls", ".xlsx" };

        public void Validate(IFormFile file, FileType fileType)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Geçerli bir dosya yüklenmedi.");

            if (file.Length > _maxFileSize)
                throw new ArgumentException("Dosya boyutu 10 MB’ı geçemez.");

            var ext = Path.GetExtension(file.FileName).ToLower();

            string[] allowedExtensions = fileType switch
            {
                FileType.Image => new[] { ".jpg", ".jpeg", ".png", ".webp" },
                FileType.Pdf => new[] { ".pdf" },
                FileType.Model3D => new[] { ".glb", ".stl" },
                FileType.TestData => new[] { ".xls", ".xlsx" },
                _ => Array.Empty<string>()
            };

            if (!allowedExtensions.Contains(ext))
            {
                var formats = string.Join(", ", allowedExtensions);
                throw new ArgumentException($"Sadece {formats} formatları desteklenmektedir.");
            }
        }
    }
}
