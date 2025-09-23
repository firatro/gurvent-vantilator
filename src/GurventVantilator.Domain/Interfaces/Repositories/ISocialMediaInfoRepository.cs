using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Domain.Interfaces.Repositories
{
    public interface ISocialMediaInfoRepository
    {
        Task<SocialMediaInfo?> GetAsync();
        Task UpdateAsync(SocialMediaInfo socialMediaInfo);
    }
}