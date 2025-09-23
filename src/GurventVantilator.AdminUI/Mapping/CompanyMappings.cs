using GurventVantilator.AdminUI.Models.Company;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class CompanyMappings
    {
        public static CompanyDto ToDto(this CompanyCreateViewModel vm, string? logoPath)
        {
            return new CompanyDto
            {
                Name = vm.Name,
                LogoPath = logoPath
            };
        }

        public static CompanyEditViewModel ToEditViewModel(this CompanyDto dto)
        {
            return new CompanyEditViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                LogoPath = dto.LogoPath
            };
        }

        public static CompanyDto ToDto(this CompanyEditViewModel vm, string logoPath)
        {
            return new CompanyDto
            {
                Id = vm.Id,
                Name = vm.Name,
                LogoPath = logoPath
            };
        }
    }
}
