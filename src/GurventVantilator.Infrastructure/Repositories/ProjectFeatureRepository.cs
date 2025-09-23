using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class ProjectFeatureRepository : IProjectFeatureRepository
    {
        private readonly AppDbContext _context;

        public ProjectFeatureRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjectFeature>> GetAllAsync()
        {
            return await _context.ProjectFeatures
                                 .Include(f => f.Project)
                                 .ToListAsync();
        }

        public async Task<List<ProjectFeature>> GetAllByIdAsync(int id)
        {
            return await _context.ProjectFeatures
                                 .Include(f => f.Project)
                                 .Where(f => f.ProjectId == id)
                                 .ToListAsync();
        }

        public async Task<ProjectFeature?> GetByIdAsync(int id)
        {
            return await _context.ProjectFeatures
                                 .Include(f => f.Project)
                                 .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddAsync(ProjectFeature projectFeature)
        {
            await _context.ProjectFeatures.AddAsync(projectFeature);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProjectFeature projectFeature)
        {
            _context.ProjectFeatures.Update(projectFeature);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProjectFeature projectFeature)
        {
            _context.ProjectFeatures.Remove(projectFeature);
            await _context.SaveChangesAsync();
        }
    }
}
