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
                     Facebook = "https://facebook.com/firatro",
                     Instagram = "https://instagram.com/firatro",
                     Youtube = "https://youtube.com/firatro",
                     X = "https://x.com/_firatro",
                     Tiktok = "https://tiktok.com/"
                 }
            );
        }
    }
}
