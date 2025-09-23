using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class BeforeAfterRepository : IBeforeAfterRepository
    {
        private readonly AppDbContext _context;

        public BeforeAfterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BeforeAfter>> GetAllAsync()
        {
            return await _context.BeforeAfters.ToListAsync();
        }

        public async Task<BeforeAfter?> GetByIdAsync(int id)
        {
            return await _context.BeforeAfters.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<BeforeAfter>> GetAllByIdAsync()
        {
            return await _context.BeforeAfters.ToListAsync();
        }

        public async Task AddAsync(BeforeAfter beforeAfter)
        {
            await _context.BeforeAfters.AddAsync(beforeAfter);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BeforeAfter beforeAfter)
        {
            _context.BeforeAfters.Update(beforeAfter);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(BeforeAfter beforeAfter)
        {
            _context.BeforeAfters.Remove(beforeAfter);
            await _context.SaveChangesAsync();
        }
    }
}
