// using GurventVantilator.Domain.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;

// namespace GurventVantilator.Infrastructure.Data.Configurations
// {
//     public class ProjectFeatureConfiguration : IEntityTypeConfiguration<ProjectFeature>
//     {
//         public void Configure(EntityTypeBuilder<ProjectFeature> builder)
//         {
//             builder.HasData(
//                 // 1️⃣ Otomotiv Fabrikası
//                 new ProjectFeature { Id = 1, ProjectId = 1, Name = "Yüksek debili santrifüj fanlar" },
//                 new ProjectFeature { Id = 2, ProjectId = 1, Name = "Enerji verimli motor sistemi" },
//                 new ProjectFeature { Id = 3, ProjectId = 1, Name = "Otomasyon kontrol paneli" },
//                 new ProjectFeature { Id = 4, ProjectId = 1, Name = "Sessiz çalışma standardı" },

//                 // 2️⃣ Hastane Projesi
//                 new ProjectFeature { Id = 5, ProjectId = 2, Name = "HEPA filtre entegrasyonu" },
//                 new ProjectFeature { Id = 6, ProjectId = 2, Name = "Hijyenik paslanmaz fan gövdesi" },
//                 new ProjectFeature { Id = 7, ProjectId = 2, Name = "Sürekli çalışma için optimize motor" },
//                 new ProjectFeature { Id = 8, ProjectId = 2, Name = "Düşük gürültü seviyesi (<45 dB)" },

//                 // 3️⃣ Maden Ocağı Projesi
//                 new ProjectFeature { Id = 9, ProjectId = 3, Name = "ATEX sertifikalı fan üretimi" },
//                 new ProjectFeature { Id = 10, ProjectId = 3, Name = "Korozyona dayanıklı malzeme" },
//                 new ProjectFeature { Id = 11, ProjectId = 3, Name = "Yüksek sıcaklığa dayanıklı yataklama" },
//                 new ProjectFeature { Id = 12, ProjectId = 3, Name = "Basınç kontrollü hava akışı" }
//             );
//         }
//     }
// }
