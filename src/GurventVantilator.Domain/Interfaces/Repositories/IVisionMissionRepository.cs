using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IVisionMissionRepository
    {
        Task<VisionMission?> GetAsync();
        Task UpdateAsync(VisionMission visionMission);
    }
}
