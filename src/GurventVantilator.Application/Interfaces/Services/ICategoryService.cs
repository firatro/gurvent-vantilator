using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<Result<IEnumerable<CategoryDto>>> GetAllAsync();
        Task<Result<CategoryDto>> GetByIdAsync(int id);
        Task<Result<CategoryDto>> AddAsync(CategoryDto dto);
        Task<Result<CategoryDto>> UpdateAsync(CategoryDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
