using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class SeoSettingRepository : ISeoSettingRepository
    {
        private readonly AppDbContext _context;

        public SeoSettingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SeoSetting?> GetAsync()
        {
            return await _context.SeoSettings.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(SeoSetting seoSetting)
        {
            _context.SeoSettings.Update(seoSetting);
            await _context.SaveChangesAsync();
        }

    }
}
