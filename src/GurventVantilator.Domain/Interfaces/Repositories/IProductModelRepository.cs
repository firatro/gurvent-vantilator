using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IProductModelRepository
    {
        // LIST
        Task<List<ProductModel>> GetAllAsync();

        // GET BY ID (basit)
        Task<ProductModel?> GetByIdAsync(int id);

        // GET BY ID with Includes
        Task<ProductModel?> GetByIdWithIncludesAsync(int id);

        // GET BY SERIES
        Task<List<ProductModel>> GetBySeriesIdAsync(int seriesId);

        // CREATE
        Task AddAsync(ProductModel entity);

        // UPDATE
        Task UpdateAsync(ProductModel entity);

        // DELETE
        Task DeleteAsync(ProductModel entity);

        // PAGED
        Task<(List<ProductModel> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize);
    }
}
