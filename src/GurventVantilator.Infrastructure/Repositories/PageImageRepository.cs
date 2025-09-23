using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class PageImageRepository : IPageImageRepository
    {
        private readonly AppDbContext _context;

        public PageImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PageImage>> GetAllAsync()
        {
            return await _context.PageImages
                              .ToListAsync();
        }

        public async Task<PageImage?> GetByIdAsync(int id)
        {
            return await _context.PageImages.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(PageImage pageImage)
        {
            await _context.PageImages.AddAsync(pageImage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PageImage pageImage)
        {
            _context.PageImages.Remove(pageImage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PageImage pageImage)
        {
            _context.PageImages.Update(pageImage);
            await _context.SaveChangesAsync();
        }
        
        public async Task<PageImage?> GetByPageAndTypeAsync(string pageKey, string imageType)
        {
            return await _context.PageImages
                .FirstOrDefaultAsync(x => x.PageKey == pageKey && x.ImageType == imageType);
        }
    }
}
