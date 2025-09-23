
using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ProjectFeatureConfiguration : IEntityTypeConfiguration<ProjectFeature>
    {
        public void Configure(EntityTypeBuilder<ProjectFeature> builder)
        {
            builder.HasData(
                new ProjectFeature { Id = 1, ProjectId = 1, Name = "Ölçeklenebilir mimari" },
                new ProjectFeature { Id = 2, ProjectId = 1, Name = "Güvenli ödeme altyapısı" },
                new ProjectFeature { Id = 3, ProjectId = 1, Name = "Kullanıcı dostu arayüz" },
                new ProjectFeature { Id = 4, ProjectId = 1, Name = "Mikroservis tabanlı yapı" },
                new ProjectFeature { Id = 5, ProjectId = 2, Name = "Çift platform desteği (iOS & Android)" },
                new ProjectFeature { Id = 6, ProjectId = 2, Name = "Yüksek güvenlik (2FA, SSL)" },
                new ProjectFeature { Id = 7, ProjectId = 2, Name = "Gerçek zamanlı bildirimler" },
                new ProjectFeature { Id = 8, ProjectId = 2, Name = "Kolay para transferi ve fatura ödeme" },
                new ProjectFeature { Id = 9, ProjectId = 3, Name = "Yapay zeka destekli tahminleme" },
                new ProjectFeature { Id = 10, ProjectId = 3, Name = "Müşteri segmentasyonu" },
                new ProjectFeature { Id = 11, ProjectId = 3, Name = "Otomatik görev atama" },
                new ProjectFeature { Id = 12, ProjectId = 3, Name = "Satış ekibi verimliliğini artıran çözümler" }
            );
        }
    }
}