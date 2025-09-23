using GurventVantilator.AdminUI.Models.Project;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class ProjectMappings
    {
        public static ProjectDto ToDto(this ProjectCreateViewModel vm,
                                       string? mainImagePath,
                                       string? contentImage1Path,
                                       string? contentImage2Path)
        {
            return new ProjectDto
            {
                Title = vm.Title ?? string.Empty,
                Subtitle = vm.Subtitle,
                Description = vm.Description,
                IntroText = vm.IntroText,
                CustomerInfo = vm.CustomerInfo,
                ExtraTitle = vm.ExtraTitle,
                ExtraDescription = vm.ExtraDescription,
                ProjectDate = vm.ProjectDate,
                CreatedAt = DateTime.Now,
                MainImagePath = mainImagePath ?? string.Empty,
                ContentImage1Path = contentImage1Path ?? string.Empty,
                ContentImage2Path = contentImage2Path ?? string.Empty
            };
        }

        public static ProjectEditViewModel ToEditViewModel(this ProjectDto dto)
        {
            return new ProjectEditViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                Subtitle = dto.Subtitle,
                CreatedAt = dto.CreatedAt,
                IntroText = dto.IntroText,
                Description = dto.Description,
                ProjectDate = dto.ProjectDate,
                CustomerInfo = dto.CustomerInfo,
                ExtraTitle = dto.ExtraTitle,
                ExtraDescription = dto.ExtraDescription,
                MainImagePath = dto.MainImagePath,
                ContentImage1Path = dto.ContentImage1Path,
                ContentImage2Path = dto.ContentImage2Path
            };
        }

        public static ProjectDto ToDto(this ProjectEditViewModel vm,
                                       string mainImagePath,
                                       string contentImage1Path,
                                       string contentImage2Path,
                                       DateTime createdAt)
        {
            return new ProjectDto
            {
                Id = vm.Id,
                Title = vm.Title,
                Subtitle = vm.Subtitle,
                IntroText = vm.IntroText,
                Description = vm.Description,
                ProjectDate = vm.ProjectDate,
                CustomerInfo = vm.CustomerInfo,
                ExtraTitle = vm.ExtraTitle,
                ExtraDescription = vm.ExtraDescription,
                MainImagePath = mainImagePath,
                ContentImage1Path = contentImage1Path,
                ContentImage2Path = contentImage2Path,
                CreatedAt = createdAt
            };
        }
    }
}
