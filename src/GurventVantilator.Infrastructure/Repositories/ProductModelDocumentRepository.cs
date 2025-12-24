using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class ProductModelDocumentRepository : IProductModelDocumentRepository
{
    private readonly AppDbContext _context;

    public ProductModelDocumentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductModelDocument>> GetByModelIdAsync(int modelId)
    {
        return await _context.ProductModelDocuments
            .Where(x => x.ProductModelId == modelId)
            .ToListAsync();
    }

    public async Task AddAsync(ProductModelDocument document)
    {
        await _context.ProductModelDocuments.AddAsync(document);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var doc = await _context.ProductModelDocuments.FindAsync(id);
        if (doc != null)
        {
            _context.ProductModelDocuments.Remove(doc);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<ProductModelDocument?> GetByIdAsync(int id)
    {
        return await _context.ProductModelDocuments.FindAsync(id);
    }

}
