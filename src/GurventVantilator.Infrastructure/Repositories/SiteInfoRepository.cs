using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class SiteInfoRepository : ISiteInfoRepository
    {
        private readonly AppDbContext _context;

        public SiteInfoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SiteInfo?> GetAsync()
        {
            return await _context.SiteInfo
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync();
        }


        public async Task UpdateAsync(SiteInfo siteInfo)
        {
            _context.SiteInfo.Update(siteInfo);
            await _context.SaveChangesAsync();
        }

    }
}
