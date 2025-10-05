using GurventVantilator.Application.DTOs;

namespace GurventVantilator.WebUI.Models
{
    public class HomeViewModel
    {
        public SliderDto Slider { get; set; } = new SliderDto();
        public IEnumerable<ServiceDto> Services { get; set; } = new List<ServiceDto>();
        public IEnumerable<CompanyDto> Companies { get; set; } = new List<CompanyDto>();
        public AboutUsDto AboutUs { get; set; } = new AboutUsDto();
        public IEnumerable<ProjectDto> Projects { get; set; } = new List<ProjectDto>();
        public IEnumerable<TestimonialDto> Testimonials { get; set; } = new List<TestimonialDto>();
        public IEnumerable<FaqDto> Faqs { get; set; } = new List<FaqDto>();
        public IEnumerable<BlogDto> Blogs { get; set; } = new List<BlogDto>();

    }
}
