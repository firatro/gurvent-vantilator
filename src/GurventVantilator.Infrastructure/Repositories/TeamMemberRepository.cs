using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly AppDbContext _context;

        public TeamMemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TeamMember>> GetAllAsync()
        {
            return await _context.TeamMembers.ToListAsync();
        }

        public async Task<TeamMember?> GetByIdAsync(int teamMemberId)
        {
            return await _context.TeamMembers
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(s => s.Id == teamMemberId);
        }

        public async Task AddAsync(TeamMember teamMember)
        {
            await _context.TeamMembers.AddAsync(teamMember);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TeamMember teamMember)
        {
            _context.TeamMembers.Update(teamMember);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TeamMember teamMember)
        {
            _context.TeamMembers.Remove(teamMember);
            await _context.SaveChangesAsync();
        }
    }
}
