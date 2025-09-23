using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IBlogService
    {
        Task<Result<IEnumerable<BlogDto>>> GetAllAsync();
        Task<Result<BlogDto>> GetByIdAsync(int id);
        Task<Result<BlogDto>> AddAsync(BlogDto dto, List<int> tagIds);
        Task<Result<BlogDto>> UpdateAsync(BlogDto dto, List<int> tagIds);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<PagedResult<BlogDto>>> GetPagedAsync(int pageNumber, int pageSize);
        Task<Result<PagedResult<BlogDto>>> GetPagedAsync(int? categoryId, int? tagId, int pageNumber, int pageSize);

    }
}
