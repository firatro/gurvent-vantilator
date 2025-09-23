using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IMenuService
    {
        Task<Result<IEnumerable<MenuDto>>> GetAllAsync();
        Task<Result<MenuDto>> GetByIdAsync(int id);
        Task<Result<MenuDto>> AddAsync(MenuDto dto);
        Task<Result<MenuDto>> UpdateAsync(MenuDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
