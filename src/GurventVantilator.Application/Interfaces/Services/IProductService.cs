using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<Result<IEnumerable<ProductDto>>> GetAllAsync();
        Task<Result<ProductDto>> GetByIdAsync(int id);
        Task<Result<ProductDto>> AddAsync(ProductDto dto);
        Task<Result<ProductDto>> UpdateAsync(ProductDto dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<PagedResult<ProductDto>>> GetPagedAsync(int pageNumber, int pageSize);
        Task<Result<PagedResult<ProductDto>>> GetPagedAsync(int? categoryId, int pageNumber, int pageSize);
        Task<Result<List<ProductDto>>> GetProductsByCategoryAsync(int categoryId, bool includeSubCategories);
        Task<Result<List<ProductDto>>> FilterAsync(ProductFilterRequest request);

    }
}
