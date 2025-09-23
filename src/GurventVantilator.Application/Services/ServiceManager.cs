using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class ServiceManager : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ILogger<ServiceManager> _logger;

        public ServiceManager(IServiceRepository serviceRepository, ILogger<ServiceManager> logger)
        {
            _serviceRepository = serviceRepository;
            _logger = logger;
        }

        public async Task<Result<ServiceDto>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _serviceRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<ServiceDto>.Fail("Servis kaydı bulunamadı.");

                return Result<ServiceDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Service getirilirken hata oluştu. Id={Id}", id);
                return Result<ServiceDto>.Fail("Servis kaydı getirilemedi.");
            }
        }

        public async Task<Result<IEnumerable<ServiceDto>>> GetAllAsync()
        {
            try
            {
                var entities = await _serviceRepository.GetAllAsync();
                var dtos = entities.Select(MapToDto).ToList();
                return Result<IEnumerable<ServiceDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Service listesi alınırken hata oluştu.");
                return Result<IEnumerable<ServiceDto>>.Fail("Servis listesi getirilemedi.");
            }
        }

        public async Task<Result<ServiceDto>> AddAsync(ServiceDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Name))
                    return Result<ServiceDto>.Fail("Servis adı boş olamaz.");

                var entity = MapToEntity(dto);
                await _serviceRepository.AddAsync(entity);

                return Result<ServiceDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Service eklenirken hata oluştu.");
                return Result<ServiceDto>.Fail("Servis kaydı eklenemedi.");
            }
        }

        public async Task<Result<ServiceDto>> UpdateAsync(ServiceDto dto)
        {
            try
            {
                var existing = await _serviceRepository.GetByIdAsync(dto.Id);
                if (existing == null)
                    return Result<ServiceDto>.Fail("Güncellenecek servis bulunamadı.");

                var entity = MapToEntity(dto);
                await _serviceRepository.UpdateAsync(entity);

                return Result<ServiceDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Service güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<ServiceDto>.Fail("Servis kaydı güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _serviceRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek servis kaydı bulunamadı.");

                await _serviceRepository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Service silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Servis kaydı silinemedi.");
            }
        }

        #region Mapping
        private static ServiceDto MapToDto(Service entity)
        {
            return new ServiceDto
            {
                Id = entity.Id,
                MainImagePath = entity.MainImagePath,
                ContentImage1Path = entity.ContentImage1Path,
                ContentImage2Path = entity.ContentImage2Path,
                LogoPath = entity.LogoPath,
                Name = entity.Name,
                Title = entity.Title,
                Description = entity.Description,
                ExtraTitle = entity.ExtraTitle,
                ExtraDescription = entity.ExtraDescription,
                Features = entity.Features.Select(f => new ServiceFeatureDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    Value = f.Value
                }).ToList(),
                Faqs = entity.Faqs.Select(f => new ServiceFaqDto
                {
                    Id = f.Id,
                    Question = f.Question,
                    Answer = f.Answer
                }).ToList()
            };
        }

        private static Service MapToEntity(ServiceDto dto)
        {
            return new Service
            {
                Id = dto.Id,
                MainImagePath = dto.MainImagePath,
                ContentImage1Path = dto.ContentImage1Path,
                ContentImage2Path = dto.ContentImage2Path,
                LogoPath = dto.LogoPath,
                Name = dto.Name,
                Title = dto.Title,
                Description = dto.Description,
                ExtraTitle = dto.ExtraTitle,
                ExtraDescription = dto.ExtraDescription,
                Features = dto.Features.Select(f => new ServiceFeature
                {
                    Id = f.Id,
                    Name = f.Name,
                    Value = f.Value,
                    ServiceId = dto.Id
                }).ToList(),
                Faqs = dto.Faqs.Select(f => new ServiceFaq
                {
                    Id = f.Id,
                    Question = f.Question,
                    Answer = f.Answer,
                    ServiceId = dto.Id
                }).ToList()
            };
        }
        #endregion
    }
}
