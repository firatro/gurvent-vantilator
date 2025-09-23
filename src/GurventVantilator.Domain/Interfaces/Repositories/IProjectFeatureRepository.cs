using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IProjectFeatureRepository
    {
        Task<List<ProjectFeature>> GetAllAsync();
        Task<ProjectFeature?> GetByIdAsync(int projectFeatureId);
        Task<List<ProjectFeature>> GetAllByIdAsync(int projectId);
        Task AddAsync(ProjectFeature projectFeature);
        Task UpdateAsync(ProjectFeature projectFeature);
        Task DeleteAsync(ProjectFeature projectFeature);
    }
}