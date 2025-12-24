using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ProductUsageTypeConfiguration : IEntityTypeConfiguration<ProductUsageType>
    {
        public void Configure(EntityTypeBuilder<ProductUsageType> builder)
        {
            builder.ToTable("ProductUsageTypes");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Description)
                .HasMaxLength(300);

            // 🔹 Many-to-Many ilişki
            builder.HasMany(u => u.Products)
                   .WithMany(p => p.UsageTypes)
                   .UsingEntity(j => j.ToTable("ProductUsageTypeProducts"));
        }
    }
}
