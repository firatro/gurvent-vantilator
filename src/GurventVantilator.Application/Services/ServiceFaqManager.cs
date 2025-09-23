using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class ServiceFaqManager : IServiceFaqService
    {
        private readonly IServiceFaqRepository _serviceFaqRepository;
        private readonly ILogger<ServiceFaqManager> _logger;

        public ServiceFaqManager(IServiceFaqRepository serviceFaqRepository, ILogger<ServiceFaqManager> logger)
        {
            _serviceFaqRepository = serviceFaqRepository;
            _logger = logger;
        }

        public async Task<Result<ServiceFaqDto>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _serviceFaqRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<ServiceFaqDto>.Fail("Soru bulunamadı.");

                return Result<ServiceFaqDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ServiceFaq getirilirken hata oluştu. Id={Id}", id);
                return Result<ServiceFaqDto>.Fail("Soru getirilemedi.");
            }
        }

        public async Task<Result<IReadOnlyList<ServiceFaqDto>>> GetAllByIdAsync(int serviceId)
        {
            try
            {
                var serviceFaqs = await _serviceFaqRepository.GetAllByIdAsync(serviceId);
                var dtos = serviceFaqs.Select(MapToDto).ToList();

                return Result<IReadOnlyList<ServiceFaqDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ServiceFaq listesi alınırken hata oluştu. ServiceId={ServiceId}", serviceId);
                return Result<IReadOnlyList<ServiceFaqDto>>.Fail("Soru listesi getirilemedi.");
            }
        }

        public async Task<Result<ServiceFaqDto>> AddAsync(ServiceFaqDto dto, int serviceId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Question))
                    return Result<ServiceFaqDto>.Fail("Soru boş olamaz.");

                var entity = MapToEntity(dto);
                entity.ServiceId = serviceId;

                await _serviceFaqRepository.AddAsync(entity);

                return Result<ServiceFaqDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ServiceFaq eklenirken hata oluştu.");
                return Result<ServiceFaqDto>.Fail("Soru eklenemedi.");
            }
        }

        public async Task<Result<bool>> UpdateAsync(ServiceFaqDto dto)
        {
            try
            {
                var entity = MapToEntity(dto);
                await _serviceFaqRepository.UpdateAsync(entity);

                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ServiceFaq güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<bool>.Fail("Soru güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _serviceFaqRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek soru bulunamadı.");

                await _serviceFaqRepository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ServiceFaq silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Soru silinemedi.");
            }
        }

        #region Mapping
        private static ServiceFaqDto MapToDto(ServiceFaq entity)
        {
            return new ServiceFaqDto
            {
                Id = entity.Id,
                Question = entity.Question,
                Answer = entity.Answer,
                ServiceId = entity.ServiceId
            };
        }

        private static ServiceFaq MapToEntity(ServiceFaqDto dto)
        {
            return new ServiceFaq
            {
                Id = dto.Id,
                Question = dto.Question,
                Answer = dto.Answer,
                ServiceId = dto.ServiceId
            };
        }
        #endregion
    }

}

