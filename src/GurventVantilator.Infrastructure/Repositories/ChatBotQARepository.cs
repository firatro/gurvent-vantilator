using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GurventVantilator.Infrastructure.Repositories
{
    public class ChatBotQARepository : IChatBotQARepository
    {
        private readonly AppDbContext _context;

        public ChatBotQARepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ChatBotQA>> GetAllAsync()
        {
            return await _context.ChatBotQAs
                                 .ToListAsync();
        }

        public async Task<List<ChatBotQA>> GetAllByIdAsync()
        {
            return await _context.ChatBotQAs
                                 .ToListAsync();
        }

        public async Task<ChatBotQA?> GetByIdAsync(int id)
        {
            return await _context.ChatBotQAs.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(ChatBotQA chatBotQA)
        {
            await _context.ChatBotQAs.AddAsync(chatBotQA);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ChatBotQA chatBotQA)
        {
            _context.ChatBotQAs.Update(chatBotQA);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ChatBotQA chatBotQA)
        {
            _context.ChatBotQAs.Remove(chatBotQA);
            await _context.SaveChangesAsync();
        }

    }
}
