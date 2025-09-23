

using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly ILogger<TestimonialManager> _logger;

        public TestimonialManager(ITestimonialRepository testimonialRepository, ILogger<TestimonialManager> logger)
        {
            _testimonialRepository = testimonialRepository;
            _logger = logger;
        }

        public async Task<Result<TestimonialDto>> GetByIdAsync(int id)
        {
            try
            {
                var testimonial = await _testimonialRepository.GetByIdAsync(id);
                if (testimonial == null)
                    return Result<TestimonialDto>.Fail("Referans bulunamadı.");

                return Result<TestimonialDto>.Ok(MapToDto(testimonial));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Referans getirilirken hata oluştu. Id={Id}", id);
                return Result<TestimonialDto>.Fail("Referans getirilemedi.");
            }
        }

        public async Task<Result<IReadOnlyList<TestimonialDto>>> GetAllAsync()
        {
            try
            {
                var testimonials = await _testimonialRepository.GetAllAsync();
                var dtos = testimonials.Select(MapToDto).ToList();
                return Result<IReadOnlyList<TestimonialDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Referans listesi alınırken hata oluştu.");
                return Result<IReadOnlyList<TestimonialDto>>.Fail("Referanslar getirilemedi.");
            }
        }

        public async Task<Result<TestimonialDto>> AddAsync(TestimonialDto dto)
        {
            try
            {
                var entity = MapToEntity(dto);
                await _testimonialRepository.AddAsync(entity);
                return Result<TestimonialDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Referans eklenirken hata oluştu.");
                return Result<TestimonialDto>.Fail("Referans eklenemedi.");
            }
        }

        public async Task<Result<bool>> UpdateAsync(TestimonialDto dto)
        {
            try
            {
                var entity = MapToEntity(dto);
                await _testimonialRepository.UpdateAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Referans güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<bool>.Fail("Referans güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _testimonialRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek referans bulunamadı.");

                await _testimonialRepository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Referans silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Referans silinemedi.");
            }
        }

        #region Mapping
        private static TestimonialDto MapToDto(Testimonial entity)
        {
            return new TestimonialDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Comment = entity.Comment,
                FullName = entity.FullName,
                ImagePath = entity.ImagePath,
                Rating = entity.Rating
            };
        }

        private static Testimonial MapToEntity(TestimonialDto dto)
        {
            return new Testimonial
            {
                Id = dto.Id,
                Title = dto.Title,
                Comment = dto.Comment,
                FullName = dto.FullName,
                ImagePath = dto.ImagePath,
                Rating = dto.Rating
            };
        }
        #endregion
    }

}
