using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class AboutUsManager : IAboutUsService
    {
        private readonly IAboutUsRepository _aboutUsRepository;
        private readonly ILogger<AboutUsManager> _logger;

        public AboutUsManager(IAboutUsRepository aboutUsRepository, ILogger<AboutUsManager> logger)
        {
            _aboutUsRepository = aboutUsRepository;
            _logger = logger;
        }

        public async Task<Result<AboutUsDto>> GetAsync()
        {
            try
            {
                var entity = await _aboutUsRepository.GetAsync();
                if (entity == null)
                    return Result<AboutUsDto>.Fail("Hakkımızda bilgisi bulunamadı.");

                return Result<AboutUsDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hakkımızda bilgisi alınırken hata oluştu.");
                return Result<AboutUsDto>.Fail("Hakkımızda bilgisi getirilemedi.");
            }
        }

        public async Task<Result<AboutUsDto>> UpdateAsync(AboutUsDto dto)
        {
            try
            {
                var entity = MapToEntity(dto);
                await _aboutUsRepository.UpdateAsync(entity);

                return Result<AboutUsDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hakkımızda bilgisi güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<AboutUsDto>.Fail("Hakkımızda bilgisi güncellenemedi.");
            }
        }

        #region Mapping
        public static AboutUsDto MapToDto(AboutUs entity)
        {
            return new AboutUsDto
            {
                Id = entity.Id,
                Title = entity.Title,
                ExtraTitle = entity.ExtraTitle,
                Description = entity.Description,
                ExtraDescription = entity.ExtraDescription,
                ImagePath = entity.ImagePath,
                ExperienceYear = entity.ExperienceYear,
                HappyClients = entity.HappyClients,
                CompletedProjects = entity.CompletedProjects,
                Awards = entity.Awards,
                YoutubeVideoUrl = entity.YoutubeVideoUrl
            };
        }

        public static AboutUs MapToEntity(AboutUsDto dto)
        {
            return new AboutUs
            {
                Id = dto.Id,
                Title = dto.Title,
                ExtraTitle = dto.ExtraTitle,
                Description = dto.Description,
                ImagePath = dto.ImagePath,
                ExtraDescription = dto.ExtraDescription,
                ExperienceYear = dto.ExperienceYear,
                HappyClients = dto.HappyClients,
                CompletedProjects = dto.CompletedProjects,
                Awards = dto.Awards,
                YoutubeVideoUrl = dto.YoutubeVideoUrl
            };
        }
        #endregion
    }
}
