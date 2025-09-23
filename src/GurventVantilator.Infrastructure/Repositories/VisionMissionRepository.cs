using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class VisionMissionRepository : IVisionMissionRepository
    {
        private readonly AppDbContext _context;

        public VisionMissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<VisionMission?> GetAsync()
        {
            return await _context.VisionMission
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync();
        }


        public async Task UpdateAsync(VisionMission visionMission)
        {
            _context.VisionMission.Update(visionMission);
            await _context.SaveChangesAsync();
        }

    }
}
