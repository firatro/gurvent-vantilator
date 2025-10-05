using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "RSD 12F",
                    Code = "12F",
                    Description = "Ø100mm fan, yüksek verimli kompakt tasarım. Orta debili sistemler için uygundur.",

                    Diameter = "Ø100mm",
                    AirFlowMin = "200 m³/h",
                    AirFlowMax = "550 m³/h",
                    PressureMin = "50 Pa",
                    PressureMax = "600 Pa",
                    Power = "0.25 kW",
                    Voltage = "220V / 380V",
                    Frequency = "50Hz",
                    Speed = "2800 RPM",
                    NoiseLevel = "65 dB(A)",

                    ImagePath = "/uploads/products/rsd12f.webp",
                    DataSheetPath = "/uploads/datasheets/rsd12f.pdf",
                    Model3DPath = "/uploads/models/rsd12f.glb",

                    ProductCategoryId = 1,
                    IsActive = true,
                    Order = 1,
                    CreatedAt = new DateTime(2025, 9, 10, 14, 30, 0),
                },
                new Product
                {
                    Id = 2,
                    Name = "RSD 9F",
                    Code = "9F",
                    Description = "Ø80mm fan, küçük hacimli sistemler için ideal.",
                    Diameter = "Ø80mm",
                    AirFlowMin = "150 m³/h",
                    AirFlowMax = "400 m³/h",
                    PressureMin = "40 Pa",
                    PressureMax = "500 Pa",
                    Power = "0.18 kW",
                    Voltage = "220V",
                    Frequency = "50Hz",
                    Speed = "2800 RPM",
                    NoiseLevel = "62 dB(A)",
                    ImagePath = "/uploads/products/rsd9f.webp",
                    DataSheetPath = "/uploads/datasheets/rsd9f.pdf",
                    Model3DPath = "/uploads/models/rsd9f.glb",
                    ProductCategoryId = 1,
                    IsActive = true,
                    Order = 2,
                    CreatedAt = new DateTime(2025, 9, 10, 14, 30, 0),
                }
            );
        }
    }
}
