using GurventVantilator.AdminUI.Models.TeamMember;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class TeamMemberViewModelMappings
    {
        // Create VM -> DTO
        public static TeamMemberDto ToDto(this TeamMemberCreateViewModel vm, string? imagePath)
        {
            return new TeamMemberDto
            {
                Title = vm.Title,
                FullName = vm.FullName,
                Biography = vm.Biography,
                Phone = vm.Phone,
                Email = vm.Email,
                Website = vm.Website,
                Facebook = vm.Facebook,
                Twitter = vm.Twitter,
                Youtube = vm.Youtube,
                Linkedin = vm.Linkedin,
                Instagram = vm.Instagram,
                Experience = vm.Experience,
                Skills = vm.Skills,
                ImagePath = imagePath
            };
        }

        // DTO -> Edit VM
        public static TeamMemberEditViewModel ToEditViewModel(this TeamMemberDto dto)
        {
            return new TeamMemberEditViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                FullName = dto.FullName,
                Biography = dto.Biography,
                Phone = dto.Phone,
                Email = dto.Email,
                Website = dto.Website,
                Facebook = dto.Facebook,
                Twitter = dto.Twitter,
                Youtube = dto.Youtube,
                Linkedin = dto.Linkedin,
                Instagram = dto.Instagram,
                Experience = dto.Experience,
                Skills = dto.Skills,
                ImagePath = dto.ImagePath
            };
        }

        // Edit VM -> DTO
        public static TeamMemberDto ToDto(this TeamMemberEditViewModel vm, string imagePath)
        {
            return new TeamMemberDto
            {
                Id = vm.Id,
                Title = vm.Title,
                FullName = vm.FullName,
                Biography = vm.Biography,
                Phone = vm.Phone,
                Email = vm.Email,
                Website = vm.Website,
                Facebook = vm.Facebook,
                Twitter = vm.Twitter,
                Youtube = vm.Youtube,
                Linkedin = vm.Linkedin,
                Instagram = vm.Instagram,
                Experience = vm.Experience,
                Skills = vm.Skills,
                ImagePath = imagePath
            };
        }
    }
}
