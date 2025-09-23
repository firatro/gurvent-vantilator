using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces;
using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class VersionInfoRepository : IVersionInfoRepository
    {
        private readonly AppDbContext _context;

        public VersionInfoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<VersionInfo>> GetAllAsync()
        {
            return await _context.VersionInfos.ToListAsync();
        }

        public async Task<VersionInfo?> GetByIdAsync(int id)
        {
            return await _context.VersionInfos.FindAsync(id);
        }

        public async Task<VersionInfo?> GetActiveAsync()
        {
            return await _context.VersionInfos.FirstOrDefaultAsync(x => x.IsActive);
        }

        public async Task AddAsync(VersionInfo entity)
        {
            await _context.VersionInfos.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VersionInfo entity)
        {
            _context.VersionInfos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.VersionInfos.FindAsync(id);
            if (entity != null)
            {
                _context.VersionInfos.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
