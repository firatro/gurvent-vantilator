using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IProjectService
    {
        Task<Result<ProjectDto>> GetByIdAsync(int id);
        Task<Result<IEnumerable<ProjectDto>>> GetAllAsync();
        Task<Result<ProjectDto>> AddAsync(ProjectDto dto);
        Task<Result<ProjectDto>> UpdateAsync(ProjectDto dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<PagedResult<ProjectDto>>> GetPagedAsync(int pageNumber, int pageSize);

    }

}
