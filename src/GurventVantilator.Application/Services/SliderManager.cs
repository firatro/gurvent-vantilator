

using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly ILogger<SliderManager> _logger;

        public SliderManager(ISliderRepository sliderRepository, ILogger<SliderManager> logger)
        {
            _sliderRepository = sliderRepository;
            _logger = logger;
        }

        public async Task<Result<SliderDto>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _sliderRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<SliderDto>.Fail("Slider bulunamadı.");

                return Result<SliderDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Slider getirilirken hata oluştu. Id={Id}", id);
                return Result<SliderDto>.Fail("Slider getirilemedi.");
            }
        }

        public async Task<Result<List<SliderDto>>> GetAllAsync()
        {
            try
            {
                var sliders = await _sliderRepository.GetAllAsync();
                var dtos = sliders.Select(MapToDto).ToList();

                return Result<List<SliderDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Slider listesi alınırken hata oluştu.");
                return Result<List<SliderDto>>.Fail("Slider listesi getirilemedi.");
            }
        }

        public async Task<Result<SliderDto>> AddAsync(SliderDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Title))
                    return Result<SliderDto>.Fail("Slider başlığı boş olamaz.");

                var entity = MapToEntity(dto);
                await _sliderRepository.AddAsync(entity);

                return Result<SliderDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Slider eklenirken hata oluştu.");
                return Result<SliderDto>.Fail("Slider eklenemedi.");
            }
        }

        public async Task<Result<bool>> UpdateAsync(SliderDto dto)
        {
            try
            {
                var entity = MapToEntity(dto);
                await _sliderRepository.UpdateAsync(entity);

                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Slider güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<bool>.Fail("Slider güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _sliderRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek slider bulunamadı.");

                await _sliderRepository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Slider silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Slider silinemedi.");
            }
        }

        #region Mapping
        private static SliderDto MapToDto(Slider entity)
        {
            return new SliderDto
            {
                Id = entity.Id,
                ImagePath = entity.ImagePath,
                Subtitle = entity.Subtitle,
                Tag = entity.Tag,
                Title = entity.Title
            };
        }

        private static Slider MapToEntity(SliderDto dto)
        {
            return new Slider
            {
                Id = dto.Id,
                ImagePath = dto.ImagePath,
                Subtitle = dto.Subtitle,
                Tag = dto.Tag,
                Title = dto.Title
            };
        }
        #endregion
    }

}
