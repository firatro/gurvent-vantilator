using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace GurventVantilator.Infrastructure.Services
{
    public class FileValidator : IFileValidator
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long _maxFileSize = 2 * 1024 * 1024; // 2 MB

        public void Validate(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Geçerli bir dosya yüklenmedi.");

            if (file.Length > _maxFileSize)
                throw new ArgumentException("Dosya boyutu 2 MB’ı geçemez.");

            var ext = Path.GetExtension(file.FileName).ToLower();
            if (!_allowedExtensions.Contains(ext))
                throw new ArgumentException("Sadece .jpg, .jpeg, .png, .webp formatları desteklenmektedir.");
        }
    }
}
