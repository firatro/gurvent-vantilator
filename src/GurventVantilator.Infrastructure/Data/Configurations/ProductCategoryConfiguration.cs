using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(
                new ProductCategory
                {
                    Id = 1,
                    Name = "Radyal Fanlar",
                    Description = "Yüksek basınç ve verimlilik gerektiren endüstriyel uygulamalar için radyal fanlar.",
                    ImagePath = "/uploads/categories/radyal-fanlar.webp",
                    IsActive = true,
                    Order = 1,
                    CreatedAt = new DateTime(2025, 9, 10, 14, 30, 0),
                }
            );
        }
    }
}
