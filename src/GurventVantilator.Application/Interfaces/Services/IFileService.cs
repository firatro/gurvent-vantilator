using Microsoft.AspNetCore.Http;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IFileService
    {
        Task<string?> SaveFileAsync(IFormFile file, string folder);
        void DeleteFile(string? path, string folder);
    }
}
