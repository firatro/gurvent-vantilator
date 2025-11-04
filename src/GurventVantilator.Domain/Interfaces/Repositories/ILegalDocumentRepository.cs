using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface ILegalDocumentRepository
    {
        Task<IEnumerable<LegalDocument>> GetAllAsync();
        Task<LegalDocument?> GetByIdAsync(int legalDocumentId);
        Task AddAsync(LegalDocument legalDocument);
        Task UpdateAsync(LegalDocument legalDocument);
        Task DeleteAsync(LegalDocument legalDocument);
    }
}

