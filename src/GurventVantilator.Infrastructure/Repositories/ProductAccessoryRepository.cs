using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class ProductAccessoryRepository : IProductAccessoryRepository
    {
        private readonly AppDbContext _context;

        public ProductAccessoryRepository(AppDbContext context)
        {
            _context = context;
        }

        // ===========================================================
        // 🔹 GET BY PRODUCT
        // ===========================================================
        public async Task<List<ProductAccessory>> GetByProductIdAsync(int productId)
        {
            return await _context.ProductAccessories
                .Where(x => x.ProductId == productId && x.IsActive)
                .ToListAsync();
        }

        // ===========================================================
        // 🔹 GET BY ID
        // ===========================================================
        public async Task<ProductAccessory?> GetByIdAsync(int id)
        {
            return await _context.ProductAccessories
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // ===========================================================
        // 🔹 ADD
        // ===========================================================
        public async Task AddAsync(ProductAccessory entity)
        {
            _context.ProductAccessories.Add(entity);
            await _context.SaveChangesAsync();
        }

        // ===========================================================
        // 🔹 UPDATE
        // ===========================================================
        public async Task UpdateAsync(ProductAccessory entity)
        {
            _context.ProductAccessories.Update(entity);
            await _context.SaveChangesAsync();
        }

        // ===========================================================
        // 🔹 DELETE
        // ===========================================================
        public async Task DeleteAsync(ProductAccessory entity)
        {
            _context.ProductAccessories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
