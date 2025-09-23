using GurventVantilator.AdminUI.Models.PageImage;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class PageImageMappings
    {
        public static PageImageDto ToDto(this PageImageCreateViewModel vm, string? logoPath)
        {
            return new PageImageDto
            {
                ImagePath = logoPath,
                ImageType = vm.ImageType,
                PageKey = vm.PageKey,
            };
        }

        public static PageImageEditViewModel ToEditViewModel(this PageImageDto dto)
        {
            return new PageImageEditViewModel
            {
                Id = dto.Id,
                ImageType = dto.ImageType,
                PageKey = dto.PageKey,
                ImagePath = dto.ImagePath
            };
        }

        public static PageImageDto ToDto(this PageImageEditViewModel vm, string logoPath)
        {
            return new PageImageDto
            {
                Id = vm.Id,
                PageKey = vm.PageKey,
                ImageType = vm.ImageType,
                ImagePath = logoPath
            };
        }
    }
}
