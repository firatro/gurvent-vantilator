using GurventVantilator.AdminUI.Models.SiteInfo;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class SiteInfoMappings
    {
        // DTO -> Edit VM
        public static SiteInfoEditViewModel ToEditViewModel(this SiteInfoDto dto)
        {
            return new SiteInfoEditViewModel
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

        // Edit VM -> DTO
        public static SiteInfoDto ToDto(this SiteInfoEditViewModel vm, string logoPath)
        {
            return new SiteInfoDto
            {
                Id = vm.Id,
                Phone1 = vm.Phone1,
                Phone2 = vm.Phone2,
                Fax1 = vm.Fax1,
                Fax2 = vm.Fax2,
                Email1 = vm.Email1,
                Email2 = vm.Email2,
                SiteName = vm.SiteName,
                SiteInformation = vm.SiteInformation,
                SiteOwner = vm.SiteOwner,
                CompanyName = vm.CompanyName,
                CompanyOwner = vm.CompanyOwner,
                GoogleMapsApi = vm.GoogleMapsApi,
                Address = vm.Address,
                WorkingHours = vm.WorkingHours,
                TaxNumber = vm.TaxNumber,
                TaxOffice = vm.TaxOffice,
                WaNumber = vm.WaNumber,
                TNumber = vm.TNumber,
                LogoPath = logoPath
            };
        }
    }
}
