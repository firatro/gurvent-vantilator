using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ProductApplicationConfiguration : IEntityTypeConfiguration<ProductApplication>
    {
        public void Configure(EntityTypeBuilder<ProductApplication> builder)
        {
            builder.HasData(
                new ProductApplication { Id = 1, Name = "Endüstriyel Havalandırma" },
                new ProductApplication { Id = 2, Name = "Tarım ve Seracılık" },
                new ProductApplication { Id = 3, Name = "Gıda Üretimi" },
                new ProductApplication { Id = 4, Name = "Tünel ve Otopark Havalandırma" },
                new ProductApplication { Id = 5, Name = "Laboratuvar ve Kimya" }
            );
        }
    }
}
