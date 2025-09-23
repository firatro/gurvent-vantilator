using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface ITeamMemberService
    {
        Task<Result<IEnumerable<TeamMemberDto>>> GetAllAsync();
        Task<Result<TeamMemberDto>> GetByIdAsync(int id);
        Task<Result<TeamMemberDto>> AddAsync(TeamMemberDto dto);
        Task<Result<TeamMemberDto>> UpdateAsync(TeamMemberDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
