using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Persistence.Configurations;

public class ProductTestDataConfiguration : IEntityTypeConfiguration<ProductTestData>
{
    public void Configure(EntityTypeBuilder<ProductTestData> builder)
    {
        builder.ToTable("ProductTestData");
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.ProductId);

        // Sayısal kolonlar için precision (ör: 18,3)
        foreach (var p in typeof(ProductTestData).GetProperties()
                     .Where(pi => pi.PropertyType == typeof(decimal)))
        {
            builder.Property(p.Name).HasColumnType("decimal(18,3)");
        }
    }
}
