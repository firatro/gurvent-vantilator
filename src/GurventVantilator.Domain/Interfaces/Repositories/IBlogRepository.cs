using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetAllAsync();
        Task<Blog?> GetByIdAsync(int blogId);
        Task AddAsync(Blog blog);
        Task UpdateAsync(Blog blog);
        Task DeleteAsync(Blog blog);
        Task RemoveBlogTags(IEnumerable<BlogTag> blogTags);
        Task<(IEnumerable<Blog> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize);

    }
}
