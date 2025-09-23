namespace GurventVantilator.Application.DTOs
{
    public class ChatBotQADto
    {
        public int Id { get; set; }
        public string LanguageCode { get; set; } = "tr";
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
