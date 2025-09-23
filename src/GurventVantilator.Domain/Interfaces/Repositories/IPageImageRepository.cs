using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface IPageImageRepository
    {
        Task<List<PageImage>> GetAllAsync();
        Task<PageImage?> GetByIdAsync(int pageImageId);
        Task AddAsync(PageImage pageImage);
        Task UpdateAsync(PageImage pageImage);
        Task DeleteAsync(PageImage pageImage);
        Task<PageImage?> GetByPageAndTypeAsync(string pageKey, string imageType);
    }
}
