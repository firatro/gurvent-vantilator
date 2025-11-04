using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
       public class ProductConfiguration : IEntityTypeConfiguration<Product>
       {
              public void Configure(EntityTypeBuilder<Product> builder)
              {
                     // 🔹 Tablo adı
                     builder.ToTable("Products");

                     // 🔹 Temel alanlar
                     builder.Property(p => p.Name)
                            .IsRequired()
                            .HasMaxLength(150);

                     builder.Property(p => p.Code)
                            .IsRequired()
                            .HasMaxLength(50);

                     builder.Property(p => p.Description)
                            .HasMaxLength(1000);

                     // 🔹 Boyut
                     builder.Property(p => p.Diameter)
                            .HasPrecision(10, 2); // 99999999.99 gibi
                     builder.Property(p => p.DiameterUnit)
                            .HasMaxLength(10);

                     // 🔹 Hava debisi
                     builder.Property(p => p.AirFlow)
                            .HasPrecision(10, 2);
                     builder.Property(p => p.AirFlowUnit)
                            .HasMaxLength(10);

                     // 🔹 Basınç
                     builder.Property(p => p.Pressure)
                            .HasPrecision(10, 2);
                     builder.Property(p => p.PressureUnit)
                            .HasMaxLength(10);

                     // 🔹 Elektriksel
                     builder.Property(p => p.Power)
                            .HasPrecision(10, 3);
                     builder.Property(p => p.PowerUnit)
                            .HasMaxLength(10);
                     builder.Property(p => p.Voltage)
                            .HasPrecision(10, 2);
                     builder.Property(p => p.Frequency)
                            .HasPrecision(10, 2);

                     // 🔹 Performans
                     builder.Property(p => p.Speed)
                            .HasPrecision(10, 2);
                     builder.Property(p => p.SpeedUnit)
                            .HasMaxLength(10);
                     builder.Property(p => p.NoiseLevel)
                            .HasPrecision(10, 2);
                     builder.Property(p => p.NoiseLevelUnit)
                            .HasMaxLength(10);

                     // 🔹 Dosya yolları
                     builder.Property(p => p.Image1Path).HasMaxLength(300);
                     builder.Property(p => p.DataSheetPath).HasMaxLength(300);
                     builder.Property(p => p.Model3DPath).HasMaxLength(300);

                     // 🔹 İlişki: Product ↔ ProductCategory
                     builder.HasOne(p => p.ProductCategory)
                            .WithMany(c => c.Products)
                            .HasForeignKey(p => p.ProductCategoryId)
                            .OnDelete(DeleteBehavior.Restrict);

                     // 🔹 İlişki: Product ↔ ProductApplication (Many-to-Many)
                     builder.HasMany(p => p.Applications)
                            .WithMany(a => a.Products)
                            .UsingEntity(j =>
                            {
                                   j.ToTable("ProductProductApplications");
                            });

                     builder.HasMany(p => p.TestData)
                            .WithOne(t => t.Product)
                            .HasForeignKey(t => t.ProductId)
                            .OnDelete(DeleteBehavior.Cascade);

                     // 🔹 Varsayılan veri (Seed)
                     builder.HasData(
                         new Product
                         {
                                Id = 1,
                                Name = "RSD25",
                                Code = "25",
                                Description = "Tek emişli Santrifuj gövdeye direk akuple bağlanmış geriye eğik seyrek aerofoil kanatlıdır. 80⁰C de daimi çalışmaya uygundur. Hafif hizmet modelidir. Gövde 4 değişik açıda çalışmaya uygun yapıya sahiptir ( 90⁰ - 180⁰ – 270 ⁰ – 360⁰ ). Detaylar Data-sheet sayfasında belirtilmiştir.",
                                Diameter = 100,
                                DiameterUnit = "mm",
                                AirFlow = 200,
                                AirFlowUnit = "m³/h",
                                Pressure = 50,
                                PressureUnit = "Pa",
                                Power = 0.25,
                                PowerUnit = "kW",
                                Voltage = 220,
                                Frequency = 50,
                                Speed = 2800,
                                SpeedUnit = "rpm",
                                NoiseLevel = 65,
                                NoiseLevelUnit = "dB(A)",
                                SpeedControl = "Hz - Frequency",
                                ContentTitle = "Yüksek Verimli Fan Teknolojisi",
                                ContentDescription = "RSD serisi fanlar, gelişmiş kanat geometrisi sayesinde düşük enerji tüketimiyle maksimum hava debisi sağlar. Bu tasarım, sessiz ve verimli çalışma performansı sunar.",
                                Image1Path = "/img/product/product1.webp",
                                Image2Path = "/img/product/product1.webp",
                                Image3Path = "/img/product/product1.webp",
                                Image4Path = "/img/product/product1.webp",
                                Image5Path = "/img/product/product1.webp",
                                DataSheetPath = "/datasheet/product/RSD25.pdf",
                                Model3DPath = "/model/product/RSD25.glb",
                                TestDataPath = "/test-data/product/RSD25.xslx",
                                ScaleImagePath = "img/product/product1.webp",
                                ProductCategoryId = 2,
                                IsActive = true,
                                Order = 1,
                                CreatedAt = new DateTime(2025, 9, 10, 14, 30, 0),
                         },
                         new Product
                         {
                                Id = 2,
                                Name = "RSD 22P2",
                                Code = "22P2",
                                Description = "Tek emişli Santrifuj gövdeye direk akuple bağlanmış geriye eğik seyrek aerofoil kanatlıdır. 80⁰C de daimi çalışmaya uygundur. Hafif hizmet modelidir. Gövde 4 değişik açıda çalışmaya uygun yapıya sahiptir ( 90⁰ - 180⁰ – 270 ⁰ – 360⁰ ). Detaylar Data-sheet sayfasında belirtilmiştir.",
                                Diameter = 100,
                                DiameterUnit = "mm",
                                AirFlow = 200,
                                AirFlowUnit = "m³/h",
                                Pressure = 50,
                                PressureUnit = "Pa",
                                Power = 0.25,
                                PowerUnit = "kW",
                                Voltage = 220,
                                Frequency = 50,
                                Speed = 2800,
                                SpeedUnit = "rpm",
                                NoiseLevel = 65,
                                NoiseLevelUnit = "dB(A)",
                                SpeedControl = "Hz - Frequency",
                                ContentTitle = "Dayanıklı Gövde Yapısı",
                                ContentDescription = "Galvaniz kaplama çelik gövde yapısı sayesinde uzun ömürlü kullanım sunar. Korozyon ve dış etkenlere karşı yüksek direnç gösterir, bakım ihtiyacını en aza indirir.",
                                Image1Path = "/img/product/product2.webp",
                                Image2Path = "/img/product/product2.webp",
                                Image3Path = "/img/product/product2.webp",
                                Image4Path = "/img/product/product2.webp",
                                Image5Path = "/img/product/product2.webp",
                                DataSheetPath = "/datasheet/product/RSD22P2.pdf",
                                Model3DPath = "/model/product/RSD22P2.glb",
                                TestDataPath = "/test-data/product/RSD22P2.xslx",
                                ScaleImagePath = "img/product/product1.webp",
                                ProductCategoryId = 3,
                                IsActive = true,
                                Order = 2,
                                CreatedAt = new DateTime(2025, 9, 10, 14, 30, 0),
                         },
                         new Product
                         {
                                Id = 3,
                                Name = "RSD 20B2",
                                Code = "20B2",
                                Description = "Tek emişli Santrifuj gövdeye direk akuple bağlanmış geriye eğik seyrek aerofoil kanatlıdır. 80⁰C de daimi çalışmaya uygundur. Hafif hizmet modelidir. Gövde 4 değişik açıda çalışmaya uygun yapıya sahiptir ( 90⁰ - 180⁰ – 270 ⁰ – 360⁰ ). Detaylar Data-sheet sayfasında belirtilmiştir.",
                                Diameter = 100,
                                DiameterUnit = "mm",
                                AirFlow = 200,
                                AirFlowUnit = "m³/h",
                                Pressure = 50,
                                PressureUnit = "Pa",
                                Power = 0.25,
                                PowerUnit = "kW",
                                Voltage = 220,
                                Frequency = 50,
                                Speed = 2800,
                                SpeedUnit = "rpm",
                                NoiseLevel = 65,
                                NoiseLevelUnit = "dB(A)",
                                SpeedControl = "Hz - Frequency",
                                ContentTitle = "Motor Performansı ve Güvenilirlik",
                                ContentDescription = "IE2 verimlilik sınıfına sahip motor, 80°C’de sürekli çalışmaya uygundur. Titreşim seviyesi minimize edilmiştir ve sessiz çalışma için özel dengeleme sistemi bulunur.",
                                Image1Path = "/img/product/product3.webp",
                                Image2Path = "/img/product/product3.webp",
                                Image3Path = "/img/product/product3.webp",
                                Image4Path = "/img/product/product3.webp",
                                Image5Path = "/img/product/product3.webp",
                                DataSheetPath = "/datasheet/product/RSD20B2.pdf",
                                Model3DPath = "/model/product/RSD20B2.glb",
                                TestDataPath = "/test-data/product/RSD20B2.xslx",
                                ScaleImagePath = "img/product/product1.webp",
                                ProductCategoryId = 3,
                                IsActive = true,
                                Order = 3,
                                CreatedAt = new DateTime(2025, 9, 10, 14, 30, 0),
                         },
                         new Product
                         {
                                Id = 4,
                                Name = "RSD 18B2",
                                Code = "18B2",
                                Description = "Tek emişli Santrifuj gövdeye direk akuple bağlanmış geriye eğik seyrek aerofoil kanatlıdır. 80⁰C de daimi çalışmaya uygundur. Hafif hizmet modelidir. Gövde 4 değişik açıda çalışmaya uygun yapıya sahiptir ( 90⁰ - 180⁰ – 270 ⁰ – 360⁰ ). Detaylar Data-sheet sayfasında belirtilmiştir.",
                                Diameter = 100,
                                DiameterUnit = "mm",
                                AirFlow = 200,
                                AirFlowUnit = "m³/h",
                                Pressure = 50,
                                PressureUnit = "Pa",
                                Power = 0.25,
                                PowerUnit = "kW",
                                Voltage = 220,
                                Frequency = 50,
                                Speed = 2800,
                                SpeedUnit = "rpm",
                                NoiseLevel = 65,
                                NoiseLevelUnit = "dB(A)",
                                SpeedControl = "Hz - Frequency",
                                ContentTitle = "Kolay Montaj ve Esnek Kullanım",
                                ContentDescription = "Fan gövdesi, 90°, 180°, 270° ve 360° açılarda çalışmaya uygun şekilde tasarlanmıştır. Bu özellik, farklı uygulama senaryolarında kolay montaj ve kurulum avantajı sağlar.",
                                Image1Path = "/img/product/product4.webp",
                                Image2Path = "/img/product/product4.webp",
                                Image3Path = "/img/product/product4.webp",
                                Image4Path = "/img/product/product4.webp",
                                Image5Path = "/img/product/product4.webp",
                                DataSheetPath = "/datasheet/product/RSD18B2.pdf",
                                Model3DPath = "/model/product/RSD18B2.glb",
                                TestDataPath = "/test-data/product/RSD18B2.xslx",
                                ScaleImagePath = "img/product/product1.webp",
                                ProductCategoryId = 3,
                                IsActive = true,
                                Order = 4,
                                CreatedAt = new DateTime(2025, 9, 10, 14, 30, 0),
                         }
                     );
              }
       }
}
