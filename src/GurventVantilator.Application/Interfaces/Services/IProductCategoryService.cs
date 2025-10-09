using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IProductCategoryService
    {
        Task<Result<List<ProductCategoryDto>>> GetAllAsync(bool onlyTopLevel = false);
        Task<Result<ProductCategoryDto>> GetByIdAsync(int id);
        Task<Result<ProductCategoryDto>> AddAsync(ProductCategoryDto dto);
        Task<Result<ProductCategoryDto>> UpdateAsync(ProductCategoryDto dto);
        Task<Result<bool>> DeleteAsync(int id);
        
    }
}
