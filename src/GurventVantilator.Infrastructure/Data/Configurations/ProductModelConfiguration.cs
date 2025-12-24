using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ProductModelConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.ToTable("ProductModels");

            // Temel alanlar
            builder.Property(pm => pm.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(pm => pm.Code)
                .HasMaxLength(50);

            builder.Property(pm => pm.Description)
                .HasMaxLength(1000);

            builder.Property(pm => pm.AirFlow).HasPrecision(10, 2);
            builder.Property(pm => pm.AirFlowUnit).HasMaxLength(10);

            builder.Property(pm => pm.TotalPressure).HasPrecision(10, 2);
            builder.Property(pm => pm.TotalPressureUnit).HasMaxLength(10);

            builder.Property(pm => pm.Voltage).HasPrecision(10, 2);
            builder.Property(pm => pm.Frequency).HasPrecision(10, 2);

            // Görsel alanlar
            builder.Property(pm => pm.Image1Path).HasMaxLength(300);
            builder.Property(pm => pm.Image2Path).HasMaxLength(300);
            builder.Property(pm => pm.Image3Path).HasMaxLength(300);
            builder.Property(pm => pm.Image4Path).HasMaxLength(300);
            builder.Property(pm => pm.Image5Path).HasMaxLength(300);
            builder.Property(pm => pm.DataSheetPath).HasMaxLength(300);
            builder.Property(pm => pm.Model3DPath).HasMaxLength(300);
            builder.Property(pm => pm.TestDataPath).HasMaxLength(300);
            builder.Property(pm => pm.ScaleImagePath).HasMaxLength(300);

            // 🔹 ProductSeries ilişkisi
            builder.HasOne(pm => pm.ProductSeries)
                .WithMany(ps => ps.Models)
                .HasForeignKey(pm => pm.ProductSeriesId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 Product relations (1 → n)
            builder.HasMany(pm => pm.Products)
                .WithOne(p => p.ProductModel)
                .HasForeignKey(p => p.ProductModelId)
                .OnDelete(DeleteBehavior.SetNull);


            // ========================================================
            // 🔥 Many-to-Many: UsageTypes (tıpki Product’daki gibi)
            // ========================================================
            builder.HasMany(pm => pm.UsageTypes)
                .WithMany(ut => ut.ProductModels)
                .UsingEntity(j => j.ToTable("ProductModelUsageType"));

            // ========================================================
            // 🔥 Many-to-Many: WorkingConditions (Product ile birebir aynı)
            // ========================================================
            builder.HasMany(pm => pm.WorkingConditions)
                .WithMany(wc => wc.ProductModels)
                .UsingEntity(j => j.ToTable("ProductModelWorkingCondition"));

            // Tarih alanları
            builder.Property(pm => pm.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
