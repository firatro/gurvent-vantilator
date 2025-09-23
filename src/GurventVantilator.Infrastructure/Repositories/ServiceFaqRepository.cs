using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class ServiceFaqRepository : IServiceFaqRepository
    {
        private readonly AppDbContext _context;

        public ServiceFaqRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServiceFaq>> GetAllByIdAsync(int id)
        {
            return await _context.ServiceFaqs
                                 .Where(f => f.ServiceId == id)
                                 .ToListAsync();
        }

        public async Task<ServiceFaq?> GetByIdAsync(int id)
        {
            return await _context.ServiceFaqs.FindAsync(id);
        }

        public async Task AddAsync(ServiceFaq serviceFaq)
        {
            await _context.ServiceFaqs.AddAsync(serviceFaq);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ServiceFaq serviceFaq)
        {
            _context.ServiceFaqs.Update(serviceFaq);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ServiceFaq serviceFaq)
        {
            _context.ServiceFaqs.Remove(serviceFaq);
            await _context.SaveChangesAsync();
        }
    }
}
