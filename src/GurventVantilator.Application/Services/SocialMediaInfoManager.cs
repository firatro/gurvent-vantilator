

using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class SocialMediaInfoManager : ISocialMediaInfoService
    {
        private readonly ISocialMediaInfoRepository _socialMediaInfoRepository;
        private readonly ILogger<SocialMediaInfoManager> _logger;

        public SocialMediaInfoManager(ISocialMediaInfoRepository socialMediaInfoRepository, ILogger<SocialMediaInfoManager> logger)
        {
            _socialMediaInfoRepository = socialMediaInfoRepository;
            _logger = logger;
        }

        public async Task<Result<SocialMediaInfoDto>> GetAsync()
        {
            try
            {
                var entity = await _socialMediaInfoRepository.GetAsync();
                if (entity == null)
                    return Result<SocialMediaInfoDto>.Fail("Sosyal medya bilgisi bulunamadı.");

                return Result<SocialMediaInfoDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sosyal medya bilgisi getirilirken hata oluştu.");
                return Result<SocialMediaInfoDto>.Fail("Bilgi getirilemedi.");
            }
        }

        public async Task<Result<bool>> UpdateAsync(SocialMediaInfoDto dto)
        {
            try
            {
                var entity = MapToEntity(dto);
                await _socialMediaInfoRepository.UpdateAsync(entity);

                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sosyal medya bilgisi güncellenirken hata oluştu.");
                return Result<bool>.Fail("Bilgi güncellenemedi.");
            }
        }

        #region Mapping
        private static SocialMediaInfoDto MapToDto(SocialMediaInfo entity)
        {
            return new SocialMediaInfoDto
            {
                Id = entity.Id,
                Facebook = entity.Facebook,
                Instagram = entity.Instagram,
                Youtube = entity.Youtube,
                Tiktok = entity.Tiktok,
                X = entity.X
            };
        }

        private static SocialMediaInfo MapToEntity(SocialMediaInfoDto dto)
        {
            return new SocialMediaInfo
            {
                Id = dto.Id,
                Facebook = dto.Facebook,
                Instagram = dto.Instagram,
                Youtube = dto.Youtube,
                Tiktok = dto.Tiktok,
                X = dto.X
            };
        }
        #endregion
    }

}
