

using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;

namespace GurventVantilator.Application.Services
{
    public class ProjectFeatureManager : IProjectFeatureService
    {
        private readonly IProjectFeatureRepository _projectFeatureRepository;

        public ProjectFeatureManager(IProjectFeatureRepository projectFeatureRepository)
        {
            _projectFeatureRepository = projectFeatureRepository;
        }

        public async Task<ProjectFeatureDto?> GetByIdAsync(int id)
        {
            var feature = await _projectFeatureRepository.GetByIdAsync(id);
            
            return feature == null ? null : MapToDto(feature);
        }

        public async Task<List<ProjectFeatureDto>> GetAllAsync()
        {
            var features = await _projectFeatureRepository.GetAllAsync();
            
            return features.Select(MapToDto).ToList();
        }

        public async Task AddAsync(ProjectFeatureDto dto)
        {
            var entity = MapToEntity(dto);
            await _projectFeatureRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(ProjectFeatureDto dto)
        {
            var entity = MapToEntity(dto);
            await _projectFeatureRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _projectFeatureRepository.GetByIdAsync(id);
            if (entity != null)
            {
                await _projectFeatureRepository.DeleteAsync(entity);
            }
        }

        #region Mapping
        private static ProjectFeatureDto MapToDto(ProjectFeature entity)
        {
            return new ProjectFeatureDto
            {
                Id = entity.Id,
                Name = entity.Name,
                ProjectId = entity.ProjectId,
                ProjectTitle = entity.Project?.Title
            };
        }

        private static ProjectFeature MapToEntity(ProjectFeatureDto dto)
        {
            return new ProjectFeature
            {
                Id = dto.Id,
                Name = dto.Name,
                ProjectId = dto.ProjectId
            };
        }
        #endregion
    }
}
