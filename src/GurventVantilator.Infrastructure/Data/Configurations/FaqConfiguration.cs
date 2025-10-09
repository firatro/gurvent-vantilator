using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class FaqConfiguration : IEntityTypeConfiguration<Faq>
    {
        public void Configure(EntityTypeBuilder<Faq> builder)
        {
            builder.HasData(
                new Faq { Id = 1, Question = "Hangi tür fanları üretiyorsunuz?", Answer = "Santrifüj, aksiyel, çatı tipi, kanal tipi ve özel proje fanları üretiyoruz.", CreatedAt = new DateTime(2025, 9, 5, 9, 0, 0) },
                new Faq { Id = 2, Question = "Fan seçimi nasıl yapılır?", Answer = "Alan ölçüsü, debi ihtiyacı, statik basınç ve kullanım amacına göre mühendis ekibimiz fan seçimini yapmaktadır.", CreatedAt = new DateTime(2025, 9, 5, 9, 0, 0) },
                new Faq { Id = 3, Question = "ATEX sertifikalı fanlarınız var mı?", Answer = "Evet, patlayıcı ortamlarda kullanılmak üzere ATEX standartlarına uygun fan üretimi yapıyoruz.", CreatedAt = new DateTime(2025, 9, 5, 9, 0, 0) },
                new Faq { Id = 4, Question = "Fan bakımı ne sıklıkla yapılmalı?", Answer = "Kullanım yoğunluğuna göre yılda en az bir kez periyodik bakım öneriyoruz.", CreatedAt = new DateTime(2025, 9, 5, 9, 0, 0) },
                new Faq { Id = 5, Question = "Teslimat süreniz ne kadar?", Answer = "Standart ürünlerde 10-15 iş günü, özel üretimlerde 20-30 iş günü aralığındadır.", CreatedAt = new DateTime(2025, 9, 5, 9, 0, 0) }
            );
        }
    }
}
