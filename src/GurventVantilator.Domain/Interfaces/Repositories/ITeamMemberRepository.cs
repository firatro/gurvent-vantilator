using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface ITeamMemberRepository
    {
        Task<List<TeamMember>> GetAllAsync();
        Task<TeamMember?> GetByIdAsync(int teamMemberId);
        Task AddAsync(TeamMember teamMember);
        Task UpdateAsync(TeamMember teamMember);
        Task DeleteAsync(TeamMember teamMember);
    }
}
