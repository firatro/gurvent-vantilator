public interface IProductModelDocumentService
{
    Task<List<ProductModelDocumentDto>> GetByModelIdAsync(int modelId);
    Task AddAsync(ProductModelDocumentDto dto);
    Task DeleteAsync(int id);
    Task<ProductModelDocumentDto> GetByIdAsync(int id);
}
