using GurventVantilator.Application.Enums;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace GurventVantilator.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IFileValidator _validator;

        public FileService(IFileValidator validator)
        {
            _validator = validator;
        }

        public async Task<string?> SaveFileAsync(IFormFile file, string folder, FileType fileType)
        {
             _validator.Validate(file, fileType);

            
            if (file == null || file.Length == 0)
                return null;

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folder);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return "/" + Path.Combine(folder, fileName).Replace("\\", "/");
        }

        public void DeleteFile(string? path, string folder)
        {
            if (string.IsNullOrEmpty(path))
                return;

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path.TrimStart('/'));
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}
