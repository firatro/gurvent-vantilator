using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
       public class ProductConfiguration : IEntityTypeConfiguration<Product>
       {
              public void Configure(EntityTypeBuilder<Product> builder)
              {
                     builder.ToTable("Products");

                     // Temel alanlar
                     builder.Property(p => p.Name)
                            .IsRequired()
                            .HasMaxLength(150);

                     builder.Property(p => p.Code)
                            .IsRequired()
                            .HasMaxLength(50);

                     builder.Property(p => p.Description)
                            .HasMaxLength(1000);

                     builder.Property(p => p.AirFlow).HasPrecision(10, 2);
                     builder.Property(p => p.AirFlowUnit).HasMaxLength(10);

                     builder.Property(p => p.TotalPressure).HasPrecision(10, 2);
                     builder.Property(p => p.TotalPressureUnit).HasMaxLength(10);

                     builder.Property(p => p.Voltage).HasPrecision(10, 2);
                     builder.Property(p => p.Frequency).HasPrecision(10, 2);

                     // Dosya yolları
                     builder.Property(p => p.Image1Path).HasMaxLength(300);
                     builder.Property(p => p.Image2Path).HasMaxLength(300);
                     builder.Property(p => p.Image3Path).HasMaxLength(300);
                     builder.Property(p => p.Image4Path).HasMaxLength(300);
                     builder.Property(p => p.Image5Path).HasMaxLength(300);
                     builder.Property(p => p.DataSheetPath).HasMaxLength(300);
                     builder.Property(p => p.Model3DPath).HasMaxLength(300);
                     builder.Property(p => p.ScaleImagePath).HasMaxLength(300);

                     // 🔹 ProductModel ilişkisi
                     builder.HasOne(p => p.ProductModel)
                            .WithMany(m => m.Products)
                            .HasForeignKey(p => p.ProductModelId)
                            .OnDelete(DeleteBehavior.SetNull);

                     // 🔹 ProductSeries ilişkisi
                     builder.HasOne(p => p.ProductSeries)
                            .WithMany()
                            .HasForeignKey(p => p.ProductSeriesId)
                            .OnDelete(DeleteBehavior.SetNull);

                     // 🔹 TestData ilişkisi
                     builder.HasMany(p => p.TestData)
                            .WithOne(t => t.Product)
                            .HasForeignKey(t => t.ProductId)
                            .OnDelete(DeleteBehavior.Cascade);

                     // 🔹 Many-to-Many: UsageTypes
                     builder.HasMany(p => p.UsageTypes)
                            .WithMany(u => u.Products)
                            .UsingEntity(j => j.ToTable("ProductUsageTypeProducts"));

                     // 🔹 Many-to-Many: WorkingConditions
                     builder.HasMany(p => p.WorkingConditions)
                            .WithMany(w => w.Products)
                            .UsingEntity(j => j.ToTable("ProductWorkingConditionProducts"));
              }
       }
}
