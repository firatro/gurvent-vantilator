using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class BeforeAfterManager : IBeforeAfterService
    {
        private readonly IBeforeAfterRepository _beforeAfterRepository;
        private readonly ILogger<BeforeAfterManager> _logger;

        public BeforeAfterManager(IBeforeAfterRepository beforeAfterRepository, ILogger<BeforeAfterManager> logger)
        {
            _beforeAfterRepository = beforeAfterRepository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<BeforeAfterDto>>> GetAllAsync()
        {
            try
            {
                var list = await _beforeAfterRepository.GetAllAsync();
                var dtos = list.Select(MapToDto).ToList();
                return Result<IEnumerable<BeforeAfterDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BeforeAfter listesi alınırken hata oluştu.");
                return Result<IEnumerable<BeforeAfterDto>>.Fail("Öncesi/Sonrası listesi getirilemedi.");
            }
        }

        public async Task<Result<BeforeAfterDto>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _beforeAfterRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<BeforeAfterDto>.Fail("Kayıt bulunamadı.");

                return Result<BeforeAfterDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BeforeAfter kaydı getirilirken hata oluştu. Id={Id}", id);
                return Result<BeforeAfterDto>.Fail("Kayıt getirilemedi.");
            }
        }

        public async Task<Result<BeforeAfterDto>> AddAsync(BeforeAfterDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Title))
                    return Result<BeforeAfterDto>.Fail("Başlık boş olamaz.");

                var entity = MapToEntity(dto);
                await _beforeAfterRepository.AddAsync(entity);

                return Result<BeforeAfterDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BeforeAfter eklenirken hata oluştu.");
                return Result<BeforeAfterDto>.Fail("Öncesi/Sonrası kaydı eklenemedi.");
            }
        }

        public async Task<Result<BeforeAfterDto>> UpdateAsync(BeforeAfterDto dto)
        {
            try
            {
                var entity = await _beforeAfterRepository.GetByIdAsync(dto.Id);
                if (entity == null)
                    return Result<BeforeAfterDto>.Fail("Güncellenecek kayıt bulunamadı.");

                entity.Title = dto.Title;
                entity.Subtitle = dto.Subtitle;
                entity.Description = dto.Description;
                entity.BeforeImagePath = dto.BeforeImagePath;
                entity.AfterImagePath = dto.AfterImagePath;

                await _beforeAfterRepository.UpdateAsync(entity);

                return Result<BeforeAfterDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BeforeAfter güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<BeforeAfterDto>.Fail("Öncesi/Sonrası kaydı güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _beforeAfterRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek kayıt bulunamadı.");

                await _beforeAfterRepository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BeforeAfter silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Öncesi/Sonrası kaydı silinemedi.");
            }
        }

        #region Mapping
        private static BeforeAfterDto MapToDto(BeforeAfter entity)
        {
            return new BeforeAfterDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Subtitle = entity.Subtitle,
                Description = entity.Description,
                BeforeImagePath = entity.BeforeImagePath,
                AfterImagePath = entity.AfterImagePath
            };
        }

        private static BeforeAfter MapToEntity(BeforeAfterDto dto)
        {
            return new BeforeAfter
            {
                Id = dto.Id,
                Title = dto.Title,
                Subtitle = dto.Subtitle,
                Description = dto.Description,
                BeforeImagePath = dto.BeforeImagePath,
                AfterImagePath = dto.AfterImagePath
            };
        }
        #endregion
    }
}
