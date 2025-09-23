using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IVersionInfoRepository
    {
        Task<List<VersionInfo>> GetAllAsync();
        Task<VersionInfo?> GetByIdAsync(int id);
        Task<VersionInfo?> GetActiveAsync();
        Task AddAsync(VersionInfo entity);
        Task UpdateAsync(VersionInfo entity);
        Task DeleteAsync(int id);

    }
}
