

using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class SiteInfoManager : ISiteInfoService
    {
        private readonly ISiteInfoRepository _siteInfoRepository;
        private readonly ILogger<SiteInfoManager> _logger;

        public SiteInfoManager(ISiteInfoRepository siteInfoRepository, ILogger<SiteInfoManager> logger)
        {
            _siteInfoRepository = siteInfoRepository;
            _logger = logger;
        }

        public async Task<Result<SiteInfoDto>> GetAsync()
        {
            try
            {
                var entity = await _siteInfoRepository.GetAsync();
                if (entity == null)
                    return Result<SiteInfoDto>.Fail("Site bilgisi bulunamadı.");

                return Result<SiteInfoDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Site bilgisi getirilirken hata oluştu.");
                return Result<SiteInfoDto>.Fail("Site bilgisi getirilemedi.");
            }
        }

        public async Task<Result<bool>> UpdateAsync(SiteInfoDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.SiteName))
                    return Result<bool>.Fail("Site adı boş olamaz.");

                var entity = MapToEntity(dto);
                await _siteInfoRepository.UpdateAsync(entity);

                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Site bilgisi güncellenirken hata oluştu.");
                return Result<bool>.Fail("Site bilgisi güncellenemedi.");
            }
        }

        #region Mapping
        public static SiteInfoDto MapToDto(SiteInfo entity)
        {
            return new SiteInfoDto
            {
                Id = entity.Id,
                Phone1 = entity.Phone1,
                Phone2 = entity.Phone2,
                Fax1 = entity.Fax1,
                Fax2 = entity.Fax2,
                Email1 = entity.Email1,
                Email2 = entity.Email2,
                SiteName = entity.SiteName,
                SiteInformation = entity.SiteInformation,
                SiteOwner = entity.SiteOwner,
                CompanyName = entity.CompanyName,
                CompanyOwner = entity.CompanyOwner,
                GoogleMapsApi = entity.GoogleMapsApi,
                Address = entity.Address,
                WorkingHours = entity.WorkingHours,
                TaxNumber = entity.TaxNumber,
                TaxOffice = entity.TaxOffice,
                WaNumber = entity.WaNumber,
                TNumber = entity.TNumber,
                LogoPath = entity.LogoPath
            };
        }

        public static SiteInfo MapToEntity(SiteInfoDto dto)
        {
            return new SiteInfo
            {
                Id = dto.Id,
                Phone1 = dto.Phone1,
                Phone2 = dto.Phone2,
                Fax1 = dto.Fax1,
                Fax2 = dto.Fax2,
                Email1 = dto.Email1,
                Email2 = dto.Email2,
                SiteName = dto.SiteName,
                SiteInformation = dto.SiteInformation,
                SiteOwner = dto.SiteOwner,
                CompanyName = dto.CompanyName,
                CompanyOwner = dto.CompanyOwner,
                GoogleMapsApi = dto.GoogleMapsApi,
                Address = dto.Address,
                WorkingHours = dto.WorkingHours,
                TaxNumber = dto.TaxNumber,
                TaxOffice = dto.TaxOffice,
                WaNumber = dto.WaNumber,
                TNumber = dto.TNumber,
                LogoPath = dto.LogoPath
            };
        }
        #endregion
    }

}
