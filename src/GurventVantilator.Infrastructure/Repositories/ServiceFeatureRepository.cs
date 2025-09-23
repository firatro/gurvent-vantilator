using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class FeatureRepository : IServiceFeatureRepository
    {
        private readonly AppDbContext _context;

        public FeatureRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceFeature?> GetByIdAsync(int id)
        {
            return await _context.ServiceFeatures.FindAsync(id);
        }

        public async Task<List<ServiceFeature>> GetAllByIdAsync(int id)
        {
            return await _context.ServiceFeatures
                                 .Where(f => f.ServiceId == id)
                                 .ToListAsync();
        }

        public async Task AddAsync(ServiceFeature serviceFeature)
        {
            await _context.ServiceFeatures.AddAsync(serviceFeature);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ServiceFeature serviceFeature)
        {
            _context.ServiceFeatures.Update(serviceFeature);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ServiceFeature serviceFeature)
        {
            _context.ServiceFeatures.Remove(serviceFeature);
            await _context.SaveChangesAsync();
        }
    }
}
