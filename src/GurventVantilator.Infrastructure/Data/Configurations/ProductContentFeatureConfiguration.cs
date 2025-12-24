using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ProductContentFeatureConfiguration : IEntityTypeConfiguration<ProductContentFeature>
    {
        public void Configure(EntityTypeBuilder<ProductContentFeature> builder)
        {
            builder.ToTable("ProductContentFeatures");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Key)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Value)
                .HasMaxLength(500)
                .IsRequired();

            // Product
            builder.HasOne(x => x.Product)
                .WithMany(p => p.ContentFeatures)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // ProductModel
            builder.HasOne(x => x.ProductModel)
                .WithMany(m => m.ContentFeatures)
                .HasForeignKey(x => x.ProductModelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
