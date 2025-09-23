using Microsoft.AspNetCore.Http;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IFileValidator
    {
        void Validate(IFormFile file);
    }
}
