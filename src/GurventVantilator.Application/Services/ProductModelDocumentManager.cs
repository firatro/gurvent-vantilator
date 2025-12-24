using GurventVantilator.Domain.Entities;

public class ProductModelDocumentManager : IProductModelDocumentService
{
    private readonly IProductModelDocumentRepository _repo;

    public ProductModelDocumentManager(IProductModelDocumentRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<ProductModelDocumentDto>> GetByModelIdAsync(int modelId)
    {
        var docs = await _repo.GetByModelIdAsync(modelId);
        return docs.Select(x => new ProductModelDocumentDto
        {
            Id = x.Id,
            ProductModelId = x.ProductModelId,
            Title = x.Title,
            FilePath = x.FilePath
        }).ToList();
    }

    public async Task AddAsync(ProductModelDocumentDto dto)
    {
        var doc = new ProductModelDocument
        {
            ProductModelId = dto.ProductModelId,
            Title = dto.Title,
            FilePath = dto.FilePath
        };

        await _repo.AddAsync(doc);
    }
    public async Task<ProductModelDocumentDto?> GetByIdAsync(int id)
    {
        var doc = await _repo.GetByIdAsync(id);
        if (doc == null) return null;

        return new ProductModelDocumentDto
        {
            Id = doc.Id,
            ProductModelId = doc.ProductModelId,
            Title = doc.Title,
            FilePath = doc.FilePath
        };
    }


    public async Task DeleteAsync(int id) =>
        await _repo.DeleteAsync(id);
}
