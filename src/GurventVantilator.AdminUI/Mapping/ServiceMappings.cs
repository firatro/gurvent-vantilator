using GurventVantilator.AdminUI.Models.Service;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class ServiceMappings
    {
        // Create VM -> DTO
        public static ServiceDto ToDto(this ServiceCreateViewModel vm,
                                       string? mainImagePath,
                                       string? contentImage1Path,
                                       string? contentImage2Path, string? logoPath)
        {
            return new ServiceDto
            {
                Name = vm.Name,
                Title = vm.Title,
                Description = vm.Description,
                ExtraTitle = vm.ExtraTitle,
                ExtraDescription = vm.ExtraDescription,
                MainImagePath = mainImagePath,
                ContentImage1Path = contentImage1Path,
                ContentImage2Path = contentImage2Path,
                LogoPath = logoPath
            };
        }

        // DTO -> Edit VM
        public static ServiceEditViewModel ToEditViewModel(this ServiceDto dto)
        {
            return new ServiceEditViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Title = dto.Title,
                Description = dto.Description,
                ExtraTitle = dto.ExtraTitle,
                ExtraDescription = dto.ExtraDescription,
                MainImagePath = dto.MainImagePath,
                ContentImage1Path = dto.ContentImage1Path,
                ContentImage2Path = dto.ContentImage2Path,
                LogoPath = dto.LogoPath
            };
        }

        // Edit VM -> DTO
        public static ServiceDto ToDto(this ServiceEditViewModel vm,
                                       string mainImagePath,
                                       string contentImage1Path,
                                       string contentImage2Path,
                                       string logoPath)
        {
            return new ServiceDto
            {
                Id = vm.Id,
                Name = vm.Name,
                Title = vm.Title,
                Description = vm.Description,
                ExtraTitle = vm.ExtraTitle,
                ExtraDescription = vm.ExtraDescription,
                MainImagePath = mainImagePath,
                ContentImage1Path = contentImage1Path,
                ContentImage2Path = contentImage2Path,
                LogoPath = logoPath
            };
        }
    }
}
