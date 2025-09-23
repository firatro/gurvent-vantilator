using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IProjectFeatureService
    {
        Task<List<ProjectFeatureDto>> GetAllAsync();
        Task<ProjectFeatureDto?> GetByIdAsync(int id);
        Task AddAsync(ProjectFeatureDto dto);
        Task UpdateAsync(ProjectFeatureDto dto);
        Task DeleteAsync(int id);
    }

}
