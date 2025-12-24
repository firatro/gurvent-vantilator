using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IProductService
    {
        // 🔹 CRUD
        Task<Result<IEnumerable<ProductDto>>> GetAllAsync();
        Task<Result<ProductDto>> GetByIdAsync(int id);
        Task<Result<List<ProductDto>>> GetByModelIdAsync(int modelId);
        Task<Result<ProductDto>> AddAsync(ProductDto dto);
        Task<Result<ProductDto>> UpdateAsync(ProductDto dto);
        Task<Result<bool>> DeleteAsync(int id);

        // 🔹 Listeleme ve Filtreleme
        Task<Result<PagedResult<ProductDto>>> GetPagedAsync(int pageNumber, int pageSize);
        Task<Result<List<ProductDto>>> FilterAsync(ProductFilterRequest request);
        
    }
}
