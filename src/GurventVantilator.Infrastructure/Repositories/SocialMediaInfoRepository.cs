using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class SocialMediaInfoRepository : ISocialMediaInfoRepository
    {
        private readonly AppDbContext _context;

        public SocialMediaInfoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SocialMediaInfo?> GetAsync()
        {
            return await _context.SocialMediaInfo
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync();
        }


        public async Task UpdateAsync(SocialMediaInfo socialMediaInfo)
        {
            _context.SocialMediaInfo.Update(socialMediaInfo);
            await _context.SaveChangesAsync();
        }

    }
}
