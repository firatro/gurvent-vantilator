using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IChatBotQAService
    {
        Task<Result<ChatBotQADto>> GetByIdAsync(int id);
        Task<Result<IEnumerable<ChatBotQADto>>> GetAllAsync();
        Task<Result<ChatBotQADto>> AddAsync(ChatBotQADto dto);
        Task<Result<ChatBotQADto>> UpdateAsync(ChatBotQADto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
