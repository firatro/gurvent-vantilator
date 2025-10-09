using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class SocialMediaInfoConfiguration : IEntityTypeConfiguration<SocialMediaInfo>
    {
        public void Configure(EntityTypeBuilder<SocialMediaInfo> builder)
        {
            builder.HasData(
                 new SocialMediaInfo
                 {
                     Id = 1,
                     Facebook = "https://facebook.com/gurventvantilator",
                     Instagram = "https://instagram.com/gurventvantilator",
                     Youtube = "https://youtube.com/@gurventvantilator",
                     X = "https://x.com/gurventfan",
                     Tiktok = "https://tiktok.com/@gurventvantilator",
                 }
            );
        }
    }
}
