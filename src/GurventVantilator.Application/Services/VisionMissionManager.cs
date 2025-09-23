

using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;

namespace GurventVantilator.Application.Services
{
    using global::GurventVantilator.Application.Common;
    using Microsoft.Extensions.Logging;

    namespace GurventVantilator.Application.Services
    {
        public class VisionMissionManager : IVisionMissionService
        {
            private readonly IVisionMissionRepository _visionMissionRepository;
            private readonly ILogger<VisionMissionManager> _logger;

            public VisionMissionManager(
                IVisionMissionRepository visionMissionRepository,
                ILogger<VisionMissionManager> logger)
            {
                _visionMissionRepository = visionMissionRepository;
                _logger = logger;
            }

            public async Task<Result<VisionMissionDto>> GetAsync()
            {
                try
                {
                    var entity = await _visionMissionRepository.GetAsync();
                    if (entity == null)
                        return Result<VisionMissionDto>.Fail("Vizyon & Misyon bilgisi bulunamadı.");

                    return Result<VisionMissionDto>.Ok(MapToDto(entity));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Vizyon & Misyon bilgisi alınırken hata oluştu.");
                    return Result<VisionMissionDto>.Fail("Vizyon & Misyon bilgisi getirilemedi.");
                }
            }

            public async Task<Result<bool>> UpdateAsync(VisionMissionDto dto)
            {
                try
                {
                    var entity = MapToEntity(dto);
                    await _visionMissionRepository.UpdateAsync(entity);
                    return Result<bool>.Ok(true);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Vizyon & Misyon güncellenirken hata oluştu.");
                    return Result<bool>.Fail("Vizyon & Misyon güncellenemedi.");
                }
            }

            #region Mapping
            public static VisionMissionDto MapToDto(VisionMission entity)
            {
                return new VisionMissionDto
                {
                    Id = entity.Id,
                    VisionTitle = entity.VisionTitle,
                    VisionDescription = entity.VisionDescription,
                    MissionTitle = entity.MissionTitle,
                    MissionDescription = entity.MissionDescription,
                    VisionImagePath = entity.VisionImagePath,
                    MissionImagePath = entity.MissionImagePath
                };
            }

            public static VisionMission MapToEntity(VisionMissionDto dto)
            {
                return new VisionMission
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
            #endregion
        }
    }

}
