
using GurventVantilator.AdminUI.Models.VisionMission;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class VisionMissionMappings
    {
        // DTO -> Edit VM
        public static VisionMissionEditViewModel ToEditViewModel(this VisionMissionDto dto)
        {
            return new VisionMissionEditViewModel
            {
                Id = dto.Id,
                VisionTitle = dto.VisionTitle,
                VisionDescription = dto.VisionDescription,
                MissionTitle = dto.MissionTitle,
                MissionDescription = dto.MissionDescription,
                VisionImagePath = dto.VisionImagePath,
                MissionImagePath = dto.MissionImagePath
            };
        }

        // Edit VM -> DTO
        public static VisionMissionDto ToDto(this VisionMissionEditViewModel vm, string visionImagePath, string missionImagePath)
        {
            return new VisionMissionDto
            {
                Id = vm.Id,
                VisionTitle = vm.VisionTitle,
                VisionDescription = vm.VisionDescription,
                MissionTitle = vm.MissionTitle,
                MissionDescription = vm.MissionDescription,
                VisionImagePath = visionImagePath,
                MissionImagePath = missionImagePath
            };
        }
    }
}
