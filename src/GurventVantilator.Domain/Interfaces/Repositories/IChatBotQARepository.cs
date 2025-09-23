using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IChatBotQARepository
    {
        Task<List<ChatBotQA>> GetAllAsync();
        Task<ChatBotQA?> GetByIdAsync(int chatBotQAId);
        Task AddAsync(ChatBotQA chatBotQA);
        Task UpdateAsync(ChatBotQA chatBotQA);
        Task DeleteAsync(ChatBotQA chatBotQA);
    }
}
