using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface ISeoSettingRepository
    {
        Task<SeoSetting?> GetAsync();
        Task UpdateAsync(SeoSetting seoSetting);
    }
}