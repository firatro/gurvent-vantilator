using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface ISiteInfoRepository
    {
        Task<SiteInfo?> GetAsync();
        Task UpdateAsync(SiteInfo siteInfo);
    }
}