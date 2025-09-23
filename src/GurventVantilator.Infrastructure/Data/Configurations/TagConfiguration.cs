using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasData(
                new Tag { Id = 1, Name = "Web Geliştirme" },
                new Tag { Id = 2, Name = "Mobil Uygulama" },
                new Tag { Id = 3, Name = "Yapay Zeka" },
                new Tag { Id = 4, Name = "Siber Güvenlik" },
                new Tag { Id = 5, Name = "E-Ticaret" },
                new Tag { Id = 6, Name = "SEO ve Dijital Pazarlama" }
            );
        }
    }
}
