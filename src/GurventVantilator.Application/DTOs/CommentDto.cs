namespace GurventVantilator.Application.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string BlogTitle { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsApproved { get; set; }
    }
}