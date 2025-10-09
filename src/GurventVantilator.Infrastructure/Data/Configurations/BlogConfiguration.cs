using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasData(
                new Blog
                {
                    Id = 1,
                    CreatedAt = new DateTime(2025, 9, 5, 9, 0, 0),
                    FullName = "Gurvent Editör",
                    Title = "Endüstriyel Fanlarda Enerji Verimliliği",
                    Subtitle = "Daha az enerjiyle daha fazla performans",
                    Description = "Enerji verimliliği, modern fan sistemlerinin en kritik tasarım kriterlerinden biridir. Gurvent olarak yüksek verimli motorlar, optimize edilmiş fan kanatları ve akıllı kontrol sistemleri kullanıyoruz.",
                    EntryTitle = "Enerji Verimli Fan Nedir?",
                    EntryDescription = "Yüksek verimli fan sistemleri, düşük enerji tüketimiyle maksimum hava debisi sağlar.",
                    ExtraTitle = "Verimliliği Artıran Faktörler",
                    ExtraDescription = "Motor verimi, aerodinamik kanat tasarımı ve frekans invertörü kullanımı ile sistemlerde %30’a kadar enerji tasarrufu sağlanabilir.",
                    Quote = "Verimlilik, sürdürülebilir üretimin temelidir.",
                    QuoteSource = "Gürbüz Yılmaz",
                    MainImagePath = "/img/blog/energy1.jpg",
                    ContentImage1Path = "/img/blog/energy2.jpg",
                    ContentImage2Path = "/img/blog/energy3.jpg",
                    YoutubeVideoUrl = "https://www.youtube.com/watch?v=aKx3Wxz3E5M",
                    CategoryId = 1
                },
                new Blog
                {
                    Id = 2,
                    CreatedAt = new DateTime(2025, 9, 10, 11, 30, 0),
                    FullName = "Gurvent Editör",
                    Title = "ATEX Sertifikalı Fanlar Hakkında Bilmeniz Gerekenler",
                    Subtitle = "Patlayıcı ortamlarda güvenli hava akışı",
                    Description = "ATEX standartları, yanıcı ve patlayıcı gazların bulunduğu ortamlarda fanların güvenli çalışmasını sağlar. Gurvent, ATEX direktiflerine uygun fan üretiminde uzmanlaşmıştır.",
                    EntryTitle = "ATEX Standardı Nedir?",
                    EntryDescription = "Avrupa Birliği tarafından belirlenen ATEX standardı, patlayıcı ortamlarda kullanılan ekipmanların güvenliğini tanımlar.",
                    ExtraTitle = "ATEX Fanların Avantajları",
                    ExtraDescription = "Yüksek güvenlik seviyesi, uzun ömür ve uluslararası uyumluluk sağlar.",
                    Quote = "Güvenlik, verimlilik kadar önemlidir.",
                    QuoteSource = "Gurvent Ar-Ge Ekibi",
                    MainImagePath = "/img/blog/atex1.jpg",
                    ContentImage1Path = "/img/blog/atex2.jpg",
                    ContentImage2Path = "/img/blog/atex3.jpg",
                    YoutubeVideoUrl = "https://www.youtube.com/watch?v=r9C6n3lM1Ck",
                    CategoryId = 2
                },
                new Blog
                {
                    Id = 3,
                    CreatedAt = new DateTime(2025, 9, 15, 14, 15, 0),
                    FullName = "Gurvent Editör",
                    Title = "Filtrasyon Sistemlerinde Toz Kontrolü",
                    Subtitle = "Sağlıklı çalışma alanları için etkili çözümler",
                    Description = "Toz toplama ve filtrasyon sistemleri, endüstriyel tesislerde hava kalitesini korur. Gurvent, kompakt ve yüksek verimli sistemlerle çevre dostu çözümler sunar.",
                    EntryTitle = "Toz Kontrolünün Önemi",
                    EntryDescription = "Üretim alanında toz yoğunluğu, çalışan sağlığı ve ekipman ömrünü doğrudan etkiler.",
                    ExtraTitle = "Filtrasyon Verimini Artırma Yöntemleri",
                    ExtraDescription = "Yüksek kaliteli filtre malzemeleri ve doğru sistem tasarımı ile %99’a varan filtrasyon oranı elde edilir.",
                    Quote = "Temiz hava, üretkenliğin temelidir.",
                    QuoteSource = "Gurvent Filtrasyon Ekibi",
                    MainImagePath = "/img/blog/filter1.jpg",
                    ContentImage1Path = "/img/blog/filter2.jpg",
                    ContentImage2Path = "/img/blog/filter3.jpg",
                    YoutubeVideoUrl = "https://www.youtube.com/watch?v=yPD7kBfxEZM",
                    CategoryId = 3
                }
            );
        }
    }
}
