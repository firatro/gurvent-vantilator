using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _context;

        public MenuRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Menu>> GetAllAsync()
        {
            return await _context.Menus
                                 .ToListAsync();
        }

        public async Task<Menu?> GetByIdAsync(int id)
        {
            return await _context.Menus.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Menu menu)
        {
            _context.Menus.Update(menu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Menu menu)
        {
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Menu>> GetMenusWithParentsAsync()
        {
            return await _context.Menus
                .Include(m => m.Parent)
                .ToListAsync();
        }

        public async Task<List<Menu>> GetAllWithChildrenAsync()
        {
           return await _context.Menus
                .Include(m => m.Children)
                .ThenInclude(c => c.Children) // 2 seviye alt menüler için (isteğe bağlı)
                .AsNoTracking()
                .OrderBy(m => m.Order)
                .ToListAsync();
        }

        public async Task<List<Menu>> GetRootMenusAsync()
        {
            return await _context.Menus
                .Where(m => m.ParentId == null)
                .Include(m => m.Children)
                .OrderBy(m => m.Order)
                .ToListAsync();
        }

        public async Task<Menu?> GetBySlugAsync(string slug)
        {
            return await _context.Menus
                .Include(m => m.Children)
                .FirstOrDefaultAsync(m => m.Slug == slug);
        }



    }
}
