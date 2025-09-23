using GurventVantilator.AdminUI.Models.SeoSetting;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class SeoSettingMappings
    {
        // DTO -> Edit VM
        public static SeoSettingEditViewModel ToEditViewModel(this SeoSettingDto dto)
        {
            return new SeoSettingEditViewModel
            {
                Id = dto.Id,
                SiteName = dto.SiteName,
                DefaultTitle = dto.DefaultTitle,
                DefaultMetaDescription = dto.DefaultMetaDescription,
                DefaultMetaKeywords = dto.DefaultMetaKeywords,
                RobotsTxtContent = dto.RobotsTxtContent,
                GoogleAnalyticsId = dto.GoogleAnalyticsId,
                GoogleTagManagerId = dto.GoogleTagManagerId,
                FacebookPixelId = dto.FacebookPixelId,
                DefaultOgImagePath = dto.DefaultOgImagePath
            };
        }

        // Edit VM -> DTO
        public static SeoSettingDto ToDto(this SeoSettingEditViewModel vm, string imagePath)
        {
            return new SeoSettingDto
            {
                Id = vm.Id,
                SiteName = vm.SiteName,
                DefaultTitle = vm.DefaultTitle,
                DefaultMetaDescription = vm.DefaultMetaDescription,
                DefaultMetaKeywords = vm.DefaultMetaKeywords,
                RobotsTxtContent = vm.RobotsTxtContent,
                GoogleAnalyticsId = vm.GoogleAnalyticsId,
                GoogleTagManagerId = vm.GoogleTagManagerId,
                FacebookPixelId = vm.FacebookPixelId,
                DefaultOgImagePath = imagePath
            };
        }
    }
}
