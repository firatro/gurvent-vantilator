namespace GurventVantilator.AdminUI.Models.Testimonial
{
    public class TestimonialEditViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public int? Rating { get; set; }
        public string? ImagePath { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; }
    }
}