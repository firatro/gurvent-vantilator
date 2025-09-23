using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData(
                new Contact
                {
                    Id = 1,
                    FullName = "Ahmet Yılmaz",
                    Email = "ahmet.yilmaz@example.com",
                    Phone = "+90 532 111 22 33",
                    Subject = "Yazılım geliştirme hizmetleri hakkında bilgi",
                    Message = "Merhaba, web tabanlı bir proje geliştirmeyi planlıyorum. Proje süresi, teknoloji seçimi ve maliyetlendirme hakkında detaylı bilgi verebilir misiniz?",
                    Notes = "İlk kez iletişime geçti.",
                    CreatedAt = new DateTime(2025, 9, 5, 10, 0, 0)
                }
            );
        }
    }
}
