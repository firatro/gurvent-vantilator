using GurventVantilator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GurventVantilator.Infrastructure.Data.Configurations
{
    public class ChatBotQAConfiguration : IEntityTypeConfiguration<ChatBotQA>
    {
        public void Configure(EntityTypeBuilder<ChatBotQA> builder)
        {
            builder.HasData(
                new ChatBotQA
                {
                    Id = 1,
                    LanguageCode = "tr",
                    Question = "Merhaba",
                    Answer = "Merhaba, size nasıl yardımcı olabilirim?",
                    IsActive = true
                },
                new ChatBotQA
                {
                    Id = 2,
                    LanguageCode = "tr",
                    Question = "Randevu almak istiyorum",
                    Answer = "Randevu almak için iletişim sayfamızdan form doldurabilir veya bizi arayabilirsiniz.",
                    IsActive = true
                },
                new ChatBotQA
                {
                    Id = 3,
                    LanguageCode = "en",
                    Question = "Hello",
                    Answer = "Hello, how can I help you?",
                    IsActive = true
                },
                new ChatBotQA
                {
                    Id = 4,
                    LanguageCode = "en",
                    Question = "I want to make an appointment",
                    Answer = "You can book an appointment via our contact page or by calling us.",
                    IsActive = true
                }
            );
        }
    }
}
