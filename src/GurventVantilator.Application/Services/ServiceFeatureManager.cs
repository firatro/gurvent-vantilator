

using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class ServiceFeatureManager : IServiceFeatureService
    {
        private readonly IServiceFeatureRepository _serviceFeatureRepository;
        private readonly ILogger<ServiceFeatureManager> _logger;

        public ServiceFeatureManager(IServiceFeatureRepository serviceFeatureRepository, ILogger<ServiceFeatureManager> logger)
        {
            _serviceFeatureRepository = serviceFeatureRepository;
            _logger = logger;
        }

        public async Task<Result<ServiceFeatureDto>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _serviceFeatureRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<ServiceFeatureDto>.Fail("Özellik bulunamadı.");

                return Result<ServiceFeatureDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ServiceFeature getirilirken hata oluştu. Id={Id}", id);
                return Result<ServiceFeatureDto>.Fail("Özellik getirilemedi.");
            }
        }

        public async Task<Result<List<ServiceFeatureDto>>> GetAllByIdAsync(int serviceId)
        {
            try
            {
                var features = await _serviceFeatureRepository.GetAllByIdAsync(serviceId);
                var dtos = features.Select(MapToDto).ToList();

                return Result<List<ServiceFeatureDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ServiceFeature listesi alınırken hata oluştu. ServiceId={ServiceId}", serviceId);
                return Result<List<ServiceFeatureDto>>.Fail("Özellikler getirilemedi.");
            }
        }

        public async Task<Result<ServiceFeatureDto>> AddAsync(ServiceFeatureDto dto, int serviceId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Name))
                    return Result<ServiceFeatureDto>.Fail("Özellik adı boş olamaz.");

                var entity = MapToEntity(dto);
                entity.ServiceId = serviceId;

                await _serviceFeatureRepository.AddAsync(entity);

                return Result<ServiceFeatureDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ServiceFeature eklenirken hata oluştu.");
                return Result<ServiceFeatureDto>.Fail("Özellik eklenemedi.");
            }
        }

        public async Task<Result<bool>> UpdateAsync(ServiceFeatureDto dto)
        {
            try
            {
                var entity = MapToEntity(dto);
                await _serviceFeatureRepository.UpdateAsync(entity);

                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ServiceFeature güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<bool>.Fail("Özellik güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _serviceFeatureRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek özellik bulunamadı.");

                await _serviceFeatureRepository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ServiceFeature silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Özellik silinemedi.");
            }
        }

        #region Mapping
        private static ServiceFeatureDto MapToDto(ServiceFeature entity)
        {
            return new ServiceFeatureDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Value = entity.Value,
                ServiceId = entity.ServiceId
            };
        }

        private static ServiceFeature MapToEntity(ServiceFeatureDto dto)
        {
            return new ServiceFeature
            {
                Id = dto.Id,
                Name = dto.Name,
                Value = dto.Value,
                ServiceId = dto.ServiceId
            };
        }
        #endregion
    }

}