using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Genel" },
                new Category { Id = 2, Name = "Yapay Zeka" },
                new Category { Id = 3, Name = "Mobil Geliştirme" },
                new Category { Id = 4, Name = "Siber Güvenlik" },
                new Category { Id = 5, Name = "Bulut ve DevOps" },
                new Category { Id = 6, Name = "Tasarım Kalıpları" }
            );
        }
    }
}
