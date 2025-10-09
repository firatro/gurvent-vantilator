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
                new Tag { Id = 1, Name = "Enerji Verimli Fan" },
                new Tag { Id = 2, Name = "ATEX Sertifikalı" },
                new Tag { Id = 3, Name = "Santrifüj Fan" },
                new Tag { Id = 4, Name = "Filtrasyon" },
                new Tag { Id = 5, Name = "Hava Kalitesi" },
                new Tag { Id = 6, Name = "Bakım ve Servis" }
            );
        }
    }
}
