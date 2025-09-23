using GurventVantilator.AdminUI.Models.AboutUs;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class AboutUsMappings
    {
        public static AboutUsEditViewModel ToEditViewModel(this AboutUsDto dto)
        {
            return new AboutUsEditViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                ExtraTitle = dto.ExtraTitle,
                Description = dto.Description,
                ExtraDescription = dto.ExtraDescription,
                ImagePath = dto.ImagePath,
                ExperienceYear = dto.ExperienceYear,
                HappyClients = dto.HappyClients,
                CompletedProjects = dto.CompletedProjects,
                Awards = dto.Awards,
                YoutubeVideoUrl = dto.YoutubeVideoUrl
            };
        }

        public static AboutUsDto ToDto(this AboutUsEditViewModel vm, string? imagePath)
        {
            return new AboutUsDto
            {
                Id = vm.Id,
                Title = vm.Title,
                ExtraTitle = vm.ExtraTitle,
                Description = vm.Description,
                ExtraDescription = vm.ExtraDescription,
                ImagePath = imagePath,
                ExperienceYear = vm.ExperienceYear,
                HappyClients = vm.HappyClients,
                CompletedProjects = vm.CompletedProjects,
                Awards = vm.Awards,
                YoutubeVideoUrl = vm.YoutubeVideoUrl
            };
        }
    }
}
