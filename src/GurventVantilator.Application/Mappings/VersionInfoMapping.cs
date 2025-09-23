using GurventVantilator.Application.DTOs;
using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Application.Mappings
{
    public static class VersionInfoMapping
    {
        public static VersionInfoDto ToDto(this VersionInfo entity)
        {
            return new VersionInfoDto
            {
                Id = entity.Id,
                VersionNumber = entity.VersionNumber,
                Title = entity.Title,
                Description = entity.Description,
                ReleaseDate = entity.ReleaseDate,
                IsActive = entity.IsActive
            };
        }

        public static VersionInfo ToEntity(this VersionInfoDto dto)
        {
            return new VersionInfo
            {
                Id = dto.Id,
                VersionNumber = dto.VersionNumber,
                Title = dto.Title,
                Description = dto.Description,
                ReleaseDate = dto.ReleaseDate,
                IsActive = dto.IsActive
            };
        }
    }
}
