using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IProductModelService
    {
        // 🔹 CRUD
        Task<Result<IEnumerable<ProductModelDto>>> GetAllAsync();
        Task<Result<ProductModelDto>> GetByIdAsync(int id);
        Task<Result<ProductModelDto>> AddAsync(ProductModelDto dto);
        Task<Result<ProductModelDto>> UpdateAsync(ProductModelDto dto);
        Task<Result<bool>> DeleteAsync(int id);

        // 🔹 Listeleme
        Task<Result<List<ProductModelDto>>> GetBySeriesIdAsync(int seriesId);

        // 🔹 Sayfalama (Product ile birebir aynı)
        Task<Result<PagedResult<ProductModelDto>>> GetPagedAsync(int pageNumber, int pageSize);

        // 🔹 Filtreleme (Model bazlı filtre)
        Task<Result<List<ProductModelDto>>> FilterAsync(ProductModelFilterRequest request);
    }
}
