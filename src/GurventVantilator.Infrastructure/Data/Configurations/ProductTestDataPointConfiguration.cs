using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductTestDataPointConfiguration
    : IEntityTypeConfiguration<ProductTestDataPoint>
{
    public void Configure(EntityTypeBuilder<ProductTestDataPoint> builder)
    {
        builder.ToTable("ProductTestDataPoints");

        // =============================
        // 🔑 PRIMARY KEY
        // =============================
        builder.HasKey(x => x.Id);

        // =============================
        // 🔗 RELATION
        // =============================
        builder.HasOne(x => x.ProductTestData)
            .WithMany(x => x.Points)
            .HasForeignKey(x => x.ProductTestDataId)
            .OnDelete(DeleteBehavior.Cascade);

        // =============================
        // 📊 CORE PROPERTIES
        // =============================
        builder.Property(x => x.RowNumber)
            .IsRequired();

        builder.Property(x => x.RPM)
            .HasPrecision(10, 2);

        builder.Property(x => x.Power)
            .HasPrecision(12, 4);

        // =============================
        // 📈 Q1–PT1 … Q12–PT12
        // =============================
        for (int i = 1; i <= 12; i++)
        {
            builder.Property(typeof(double?), $"Q{i}")
                .HasPrecision(14, 6);

            builder.Property(typeof(double?), $"Pt{i}")
                .HasPrecision(14, 6);
        }

        // =============================
        // 🔧 SANAL / HESAPLANAN DEĞERLER
        // =============================
        builder.Property(x => x.Ps)
            .HasPrecision(14, 6);

        builder.Property(x => x.Pd)
            .HasPrecision(14, 6);

        builder.Property(x => x.Current)
            .HasPrecision(10, 4);

        builder.Property(x => x.Speed)
            .HasPrecision(10, 2);

        builder.Property(x => x.AirPower)
            .HasPrecision(14, 6);

        builder.Property(x => x.TotalEfficiency)
            .HasPrecision(6, 2); // %

        builder.Property(x => x.MechanicalEfficiency)
            .HasPrecision(6, 2); // %

        // =============================
        // ⚡ PERFORMANCE INDEX
        // =============================
        builder.HasIndex(x => new
        {
            x.ProductTestDataId,
            x.RowNumber
        });
    }
}
