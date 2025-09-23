using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IContactService
    {
        Task<Result<ContactDto>> GetByIdAsync(int id);
        Task<Result<IReadOnlyList<ContactDto>>> GetAllAsync();
        Task<Result<ContactDto>> AddAsync(ContactDto dto);
        Task<Result<ContactDto>> UpdateAsync(ContactDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
