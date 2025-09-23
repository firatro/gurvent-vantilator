using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class AboutUsRepository : IAboutUsRepository
    {
        private readonly AppDbContext _context;

        public AboutUsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AboutUs?> GetAsync()
        {
            return await _context.AboutUs.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(AboutUs aboutUs)
        {
            _context.AboutUs.Update(aboutUs);
            await _context.SaveChangesAsync();
        }
    }
}
