using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class ProjectManager : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ILogger<ProjectManager> _logger;

        public ProjectManager(IProjectRepository projectRepository, ILogger<ProjectManager> logger)
        {
            _projectRepository = projectRepository;
            _logger = logger;
        }

        public async Task<Result<ProjectDto>> GetByIdAsync(int id)
        {
            try
            {
                var project = await _projectRepository.GetByIdAsync(id);
                if (project == null)
                    return Result<ProjectDto>.Fail("Proje bulunamadı.");

                return Result<ProjectDto>.Ok(MapToDto(project));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Proje getirilirken hata oluştu. Id={Id}", id);
                return Result<ProjectDto>.Fail("Proje getirilemedi.");
            }
        }

        public async Task<Result<IEnumerable<ProjectDto>>> GetAllAsync()
        {
            try
            {
                var projects = await _projectRepository.GetAllAsync();
                var dtos = projects.Select(MapToDto).ToList();

                return Result<IEnumerable<ProjectDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Proje listesi alınırken hata oluştu.");
                return Result<IEnumerable<ProjectDto>>.Fail("Proje listesi getirilemedi.");
            }
        }

        public async Task<Result<ProjectDto>> AddAsync(ProjectDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Title))
                    return Result<ProjectDto>.Fail("Proje başlığı boş olamaz.");

                var entity = MapToEntity(dto);
                entity.CreatedAt = DateTime.Now;

                await _projectRepository.AddAsync(entity);

                return Result<ProjectDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Proje eklenirken hata oluştu.");
                return Result<ProjectDto>.Fail("Proje eklenemedi.");
            }
        }

        public async Task<Result<ProjectDto>> UpdateAsync(ProjectDto dto)
        {
            try
            {
                var entity = await _projectRepository.GetByIdAsync(dto.Id);
                if (entity == null)
                    return Result<ProjectDto>.Fail("Güncellenecek proje bulunamadı.");

                entity.Title = dto.Title;
                entity.Subtitle = dto.Subtitle;
                entity.MainImagePath = dto.MainImagePath;
                entity.ContentImage1Path = dto.ContentImage1Path;
                entity.ContentImage2Path = dto.ContentImage2Path;
                entity.IntroText = dto.IntroText;
                entity.Description = dto.Description;
                entity.ProjectDate = dto.ProjectDate;
                entity.CustomerInfo = dto.CustomerInfo;
                entity.ExtraTitle = dto.ExtraTitle;
                entity.ExtraDescription = dto.ExtraDescription;

                entity.Features = dto.Features.Select(f => new ProjectFeature
                {
                    Id = f.Id,
                    Name = f.Name,
                    ProjectId = dto.Id
                }).ToList();

                await _projectRepository.UpdateAsync(entity);

                return Result<ProjectDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Proje güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<ProjectDto>.Fail("Proje güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _projectRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek proje bulunamadı.");

                await _projectRepository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Proje silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Proje silinemedi.");
            }
        }

        #region Mapping
        private static ProjectDto MapToDto(Project entity)
        {
            return new ProjectDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Subtitle = entity.Subtitle,
                MainImagePath = entity.MainImagePath,
                ContentImage1Path = entity.ContentImage1Path,
                ContentImage2Path = entity.ContentImage2Path,
                CreatedAt = entity.CreatedAt,
                IntroText = entity.IntroText,
                Description = entity.Description,
                ProjectDate = entity.ProjectDate,
                CustomerInfo = entity.CustomerInfo,
                ExtraTitle = entity.ExtraTitle,
                ExtraDescription = entity.ExtraDescription,
                Features = entity.Features.Select(f => new ProjectFeatureDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    ProjectId = f.ProjectId
                }).ToList()
            };
        }

        private static Project MapToEntity(ProjectDto dto)
        {
            return new Project
            {
                Id = dto.Id,
                Title = dto.Title,
                Subtitle = dto.Subtitle,
                MainImagePath = dto.MainImagePath,
                ContentImage1Path = dto.ContentImage1Path,
                ContentImage2Path = dto.ContentImage2Path,
                CreatedAt = dto.CreatedAt,
                IntroText = dto.IntroText,
                Description = dto.Description,
                ProjectDate = dto.ProjectDate,
                CustomerInfo = dto.CustomerInfo,
                ExtraTitle = dto.ExtraTitle,
                ExtraDescription = dto.ExtraDescription,
                Features = dto.Features.Select(f => new ProjectFeature
                {
                    Id = f.Id,
                    Name = f.Name,
                    ProjectId = dto.Id
                }).ToList()
            };
        }

        public async Task<Result<PagedResult<ProjectDto>>> GetPagedAsync(int pageNumber, int pageSize)
        {
            try
            {
                var projects = await _projectRepository.GetAllAsync();

                if (projects == null || !projects.Any())
                    return Result<PagedResult<ProjectDto>>.Fail("Proje bulunamadı.");

                var query = projects.AsQueryable();

                var totalCount = query.Count();

                var pagedProjects = query
                    .OrderByDescending(p => p.CreatedAt)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(MapToDto)
                    .ToList();

                var pagedResult = new PagedResult<ProjectDto>
                {
                    Items = pagedProjects,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                };

                return Result<PagedResult<ProjectDto>>.Ok(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Projeler listelenirken hata oluştu.");
                return Result<PagedResult<ProjectDto>>.Fail("Projeler yüklenirken hata oluştu.");
            }
        }

        #endregion
    }
}
