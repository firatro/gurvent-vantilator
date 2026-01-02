using GurventVantilator.Domain.Entities;

public interface IProductAccessoryRepository
{
    Task<List<ProductAccessory>> GetByProductIdAsync(int productId);
    Task<ProductAccessory?> GetByIdAsync(int id);

    Task AddAsync(ProductAccessory entity);
    Task UpdateAsync(ProductAccessory entity);
    Task DeleteAsync(ProductAccessory entity);
    Task SaveChangesAsync();


}
