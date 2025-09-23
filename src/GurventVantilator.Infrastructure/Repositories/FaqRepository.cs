using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class FaqRepository : IFaqRepository
    {
        private readonly AppDbContext _context;

        public FaqRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Faq>> GetAllAsync()
        {
            return await _context.Faqs
                                 .ToListAsync();
        }

        public async Task<Faq?> GetByIdAsync(int id)
        {
            return await _context.Faqs.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Faq>> GetAllByIdAsync()
        {
            return await _context.Faqs
                                 .ToListAsync();
        }

        public async Task AddAsync(Faq faq)
        {
            await _context.Faqs.AddAsync(faq);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Faq faq)
        {
            _context.Faqs.Update(faq);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Faq faq)
        {
            _context.Faqs.Remove(faq);
            await _context.SaveChangesAsync();
        }
    }
}
