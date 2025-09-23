using GurventVantilator.AdminUI.Models.BeforeAfter;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class BeforeAfterMappings
    {
        public static BeforeAfterDto ToDto(this BeforeAfterCreateViewModel vm, string? beforeImagePath, string? afterImagePath)
        {
            return new BeforeAfterDto
            {
                Title = vm.Title,
                Description = vm.Description,
                Subtitle = vm.Subtitle,
                BeforeImagePath = beforeImagePath,
                AfterImagePath = afterImagePath
            };
        }

        public static BeforeAfterEditViewModel ToEditViewModel(this BeforeAfterDto dto)
        {
            return new BeforeAfterEditViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Subtitle = dto.Subtitle,
                AfterImagePath = dto.AfterImagePath,
                BeforeImagePath = dto.BeforeImagePath
            };
        }

        public static BeforeAfterDto ToDto(this BeforeAfterEditViewModel vm, string? beforeImagePath, string? afterImagePath)
        {
            return new BeforeAfterDto
            {
                Id = vm.Id,
                Title = vm.Title,
                Description = vm.Description,
                Subtitle = vm.Subtitle,
                BeforeImagePath = beforeImagePath,
                AfterImagePath = afterImagePath
            };
        }
    }
}
