using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class SeoSettingManager : ISeoSettingService
    {
        private readonly ISeoSettingRepository _seoSettingRepository;
        private readonly ILogger<SeoSettingManager> _logger;

        public SeoSettingManager(ISeoSettingRepository seoSettingRepository, ILogger<SeoSettingManager> logger)
        {
            _seoSettingRepository = seoSettingRepository;
            _logger = logger;
        }

        public async Task<Result<SeoSettingDto>> GetAsync()
        {
            try
            {
                var entity = await _seoSettingRepository.GetAsync();
                if (entity == null)
                    return Result<SeoSettingDto>.Fail("SEO ayarları bulunamadı.");

                return Result<SeoSettingDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SEO ayarları alınırken hata oluştu.");
                return Result<SeoSettingDto>.Fail("SEO ayarları getirilemedi.");
            }
        }

        public async Task<Result<SeoSettingDto>> UpdateAsync(SeoSettingDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.SiteName))
                    return Result<SeoSettingDto>.Fail("Site adı boş olamaz.");

                var entity = MapToEntity(dto);
                await _seoSettingRepository.UpdateAsync(entity);

                return Result<SeoSettingDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SEO ayarları güncellenirken hata oluştu.");
                return Result<SeoSettingDto>.Fail("SEO ayarları güncellenemedi.");
            }
        }

        #region Mapping
        private static SeoSettingDto MapToDto(SeoSetting entity)
        {
            return new SeoSettingDto
            {
                Id = entity.Id,
                SiteName = entity.SiteName,
                DefaultTitle = entity.DefaultTitle,
                DefaultMetaDescription = entity.DefaultMetaDescription,
                DefaultMetaKeywords = entity.DefaultMetaKeywords,
                DefaultOgImagePath = entity.DefaultOgImagePath,
                RobotsTxtContent = entity.RobotsTxtContent,
                GoogleAnalyticsId = entity.GoogleAnalyticsId,
                GoogleTagManagerId = entity.GoogleTagManagerId,
                FacebookPixelId = entity.FacebookPixelId
            };
        }

        private static SeoSetting MapToEntity(SeoSettingDto dto)
        {
            return new SeoSetting
            {
                Id = dto.Id,
                SiteName = dto.SiteName,
                DefaultTitle = dto.DefaultTitle,
                DefaultMetaDescription = dto.DefaultMetaDescription,
                DefaultMetaKeywords = dto.DefaultMetaKeywords,
                DefaultOgImagePath = dto.DefaultOgImagePath,
                RobotsTxtContent = dto.RobotsTxtContent,
                GoogleAnalyticsId = dto.GoogleAnalyticsId,
                GoogleTagManagerId = dto.GoogleTagManagerId,
                FacebookPixelId = dto.FacebookPixelId
            };
        }
        #endregion
    }
}
