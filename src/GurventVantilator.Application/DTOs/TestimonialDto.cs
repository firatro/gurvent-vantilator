namespace GurventVantilator.Application.DTOs
{
    public class TestimonialDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public string? ImagePath { get; set; }
        public int? Rating { get; set; }
    }
}
