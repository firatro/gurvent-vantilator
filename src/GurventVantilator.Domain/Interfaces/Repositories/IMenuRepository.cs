using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllAsync();
        Task<Menu?> GetByIdAsync(int menuId);
        Task AddAsync(Menu menu);
        Task UpdateAsync(Menu menu);
        Task DeleteAsync(Menu menu);
        Task<List<Menu>> GetMenusWithParentsAsync();
        Task<List<Menu>> GetAllWithChildrenAsync();
        Task<List<Menu>> GetRootMenusAsync();
        Task<Menu?> GetBySlugAsync(string slug);
    }
}
