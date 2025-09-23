using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using GurventVantilator.Application.Common;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _context;

        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _context.Blogs
                .Include(b => b.Category)
                .Include(b => b.BlogTags).ThenInclude(bt => bt.Tag)
                .Include(b => b.Comments)
                .ToListAsync();
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await _context.Blogs
                .Include(b => b.Category)
                .Include(b => b.BlogTags).ThenInclude(bt => bt.Tag)
                .Include(b => b.Comments)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Blog blog)
        {
            var existing = await _context.Blogs
            .Include(b => b.Category)
            .Include(b => b.BlogTags)
            .ThenInclude(bt => bt.Tag)
            .FirstOrDefaultAsync(b => b.Id == blog.Id);

            if (existing != null)
            {
                _context.BlogTags.RemoveRange(existing.BlogTags);
                _context.Entry(existing).CurrentValues.SetValues(blog);
                existing.BlogTags = blog.BlogTags;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Blog blog)
        {
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveBlogTags(IEnumerable<BlogTag> blogTags)
        {
            _context.BlogTags.RemoveRange(blogTags);
            await _context.SaveChangesAsync();
        }
        public async Task<(IEnumerable<Blog> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _context.Blogs
                .Include(b => b.Category)
                .Include(b => b.BlogTags).ThenInclude(bt => bt.Tag)
                .Include(b => b.Comments)
                .OrderByDescending(b => b.CreatedAt);

            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();

            return (items, totalCount);
        }

    }
}
