using GurventVantilator.Application.DTOs;
using GurventVantilator.AdminUI.Models.Slider;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class SlideMappings
    {
        // Create VM -> DTO
        public static SliderDto ToDto(this SliderCreateViewModel vm, string? imagePath)
        {
            return new SliderDto
            {
                Title = vm.Title ?? string.Empty,
                Subtitle = vm.Subtitle,
                Tag = vm.Tag,
                ImagePath = imagePath ?? string.Empty
            };
        }

        // DTO -> Edit VM
        public static SliderEditViewModel ToEditViewModel(this SliderDto dto)
        {
            return new SliderEditViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                Subtitle = dto.Subtitle,
                Tag = dto.Tag,
                ImagePath = dto.ImagePath
            };
        }

        // Edit VM -> DTO
        public static SliderDto ToDto(this SliderEditViewModel vm, string imagePath)
        {
            return new SliderDto
            {
                Id = vm.Id,
                Title = vm.Title,
                Subtitle = vm.Subtitle,
                Tag = vm.Tag,
                ImagePath = imagePath
            };
        }
    }
}
