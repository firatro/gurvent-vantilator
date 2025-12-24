using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ProductSeriesConfiguration : IEntityTypeConfiguration<ProductSeries>
    {
        public void Configure(EntityTypeBuilder<ProductSeries> builder)
        {
            builder.ToTable("ProductSeries");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Description)
                .HasMaxLength(500);

            builder.HasMany(s => s.Models)
                .WithOne(m => m.ProductSeries)
                .HasForeignKey(m => m.ProductSeriesId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
