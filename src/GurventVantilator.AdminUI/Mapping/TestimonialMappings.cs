using GurventVantilator.AdminUI.Models.Testimonial;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class TestimonialMappings
    {
        // Create VM -> DTO
        public static TestimonialDto ToDto(this TestimonialCreateViewModel vm, string? imagePath)
        {
            return new TestimonialDto
            {
                Title = vm.Title,
                FullName = vm.FullName,
                Comment = vm.Comment,
                Rating = vm.Rating,
                ImagePath = imagePath
            };
        }

        // DTO -> Edit VM
        public static TestimonialEditViewModel ToEditViewModel(this TestimonialDto dto)
        {
            return new TestimonialEditViewModel
            {
                Id = dto.Id,
                Title = dto.Title,
                FullName = dto.FullName,
                Comment = dto.Comment,
                Rating = dto.Rating,
                ImagePath = dto.ImagePath
            };
        }

        // Edit VM -> DTO
        public static TestimonialDto ToDto(this TestimonialEditViewModel vm, string imagePath)
        {
            return new TestimonialDto
            {
                Id = vm.Id,
                Title = vm.Title,
                FullName = vm.FullName,
                Comment = vm.Comment,
                Rating = vm.Rating,
                ImagePath = imagePath
            };
        }
    }
}
