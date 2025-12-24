using GurventVantilator.Domain.Entities;

public interface IProductModelDocumentRepository
{
    Task<List<ProductModelDocument>> GetByModelIdAsync(int modelId);
    Task AddAsync(ProductModelDocument document);
    Task DeleteAsync(int id);
    Task<ProductModelDocument?> GetByIdAsync(int id);
}
