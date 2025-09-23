using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface ICommentService
    {
        Task<Result<IEnumerable<CommentDto>>> GetAllAsync();
        Task<Result<bool>> ToggleApprovalAsync(int id);
        Task<Result<IEnumerable<CommentDto>>> GetByBlogIdAsync(int blogId);
        Task<Result<CommentDto>> GetByIdAsync(int id);
        Task<Result<CommentDto>> AddAsync(CommentDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
