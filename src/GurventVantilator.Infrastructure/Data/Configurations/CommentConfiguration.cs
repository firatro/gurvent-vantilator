using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(
                new Comment
                {
                    Id = 1,
                    BlogId = 1, // Modern Yazılım Yaklaşımları
                    FullName = "Ahmet Yılmaz",
                    Text = "Çok faydalı bir yazı olmuş, mikroservisler ve temiz kod bölümleri özellikle dikkat çekiciydi.",
                    CreatedAt = new DateTime(2025, 9, 5, 10, 0, 0),
                    IsApproved = true
                },
                new Comment
                {
                    Id = 2,
                    BlogId = 1, // Modern Yazılım Yaklaşımları
                    FullName = "Ayşe Demir",
                    Text = "Agile metodolojiler konusunda kafamda soru işaretleri vardı, yazı çok net bir şekilde açıklamış.",
                    CreatedAt = new DateTime(2025, 9, 5, 11, 0, 0),
                    IsApproved = true
                },
                new Comment
                {
                    Id = 3,
                    BlogId = 2, // Yapay Zeka & Makine Öğrenmesi
                    FullName = "Mehmet Aksoy",
                    Text = "Makine öğrenmesi örnekleri çok açıklayıcı olmuş, özellikle öneri sistemleri kısmı ilgimi çekti.",
                    CreatedAt = new DateTime(2025, 9, 6, 9, 30, 0),
                    IsApproved = false
                },
                new Comment
                {
                    Id = 4,
                    BlogId = 3, // Mobil Geliştirme Trendleri
                    FullName = "Zeynep Kaya",
                    Text = "React Native ve Flutter karşılaştırması çok işime yaradı, teşekkürler.",
                    CreatedAt = new DateTime(2025, 9, 7, 14, 15, 0),
                    IsApproved = true
                },
                new Comment
                {
                    Id = 5,
                    BlogId = 4, // Siber Güvenlik
                    FullName = "Selin Arslan",
                    Text = "Zero Trust yaklaşımı hakkında bu kadar detaylı bilgi bulmak çok güzel. Gerçekten açıklayıcı.",
                    CreatedAt = new DateTime(2025, 9, 8, 18, 45, 0),
                    IsApproved = true
                },
                new Comment
                {
                    Id = 6,
                    BlogId = 5, // Bulut & DevOps
                    FullName = "Can Demirtaş",
                    Text = "CI/CD süreci hakkında yanlış bildiklerim varmış, bu yazı gerçekten aydınlatıcı oldu.",
                    CreatedAt = new DateTime(2025, 9, 9, 12, 20, 0),
                    IsApproved = false
                },
                new Comment
                {
                    Id = 7,
                    BlogId = 6, // Tasarım Kalıpları
                    FullName = "Murat Özkan",
                    Text = "Observer ve Singleton örnekleri çok açıklayıcı, uygulamamda hemen deneyeceğim.",
                    CreatedAt = new DateTime(2025, 9, 10, 15, 10, 0),
                    IsApproved = true
                }
            );
        }
    }
}
