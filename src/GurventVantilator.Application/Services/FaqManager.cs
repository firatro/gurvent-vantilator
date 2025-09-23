using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class FaqManager : IFaqService
    {
        private readonly IFaqRepository _faqRepository;
        private readonly ILogger<FaqManager> _logger;

        public FaqManager(IFaqRepository faqRepository, ILogger<FaqManager> logger)
        {
            _faqRepository = faqRepository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<FaqDto>>> GetAllAsync()
        {
            try
            {
                var faqs = await _faqRepository.GetAllAsync();
                var dtos = faqs.Select(MapToDto).ToList();

                return Result<IEnumerable<FaqDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sıkça Sorulan Sorular listesi alınırken hata oluştu.");
                return Result<IEnumerable<FaqDto>>.Fail("SSS listesi getirilemedi.");
            }
        }

        public async Task<Result<FaqDto>> GetByIdAsync(int id)
        {
            try
            {
                var faq = await _faqRepository.GetByIdAsync(id);
                if (faq == null)
                    return Result<FaqDto>.Fail("SSS bulunamadı.");

                return Result<FaqDto>.Ok(MapToDto(faq));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SSS getirilirken hata oluştu. Id={Id}", id);
                return Result<FaqDto>.Fail("SSS getirilemedi.");
            }
        }

        public async Task<Result<FaqDto>> AddAsync(FaqDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Question))
                    return Result<FaqDto>.Fail("Soru boş olamaz.");
                if (string.IsNullOrWhiteSpace(dto.Answer))
                    return Result<FaqDto>.Fail("Cevap boş olamaz.");

                var entity = MapToEntity(dto);
                entity.CreatedAt = DateTime.Now;

                await _faqRepository.AddAsync(entity);

                return Result<FaqDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SSS eklenirken hata oluştu.");
                return Result<FaqDto>.Fail("SSS eklenemedi.");
            }
        }

        public async Task<Result<FaqDto>> UpdateAsync(FaqDto dto)
        {
            try
            {
                var entity = await _faqRepository.GetByIdAsync(dto.Id);
                if (entity == null)
                    return Result<FaqDto>.Fail("Güncellenecek SSS bulunamadı.");

                entity.Question = dto.Question;
                entity.Answer = dto.Answer;

                await _faqRepository.UpdateAsync(entity);

                return Result<FaqDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SSS güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<FaqDto>.Fail("SSS güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _faqRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek SSS bulunamadı.");

                await _faqRepository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SSS silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("SSS silinemedi.");
            }
        }

        #region Mapping
        private static FaqDto MapToDto(Faq entity)
        {
            return new FaqDto
            {
                Id = entity.Id,
                Answer = entity.Answer,
                Question = entity.Question,
                CreatedAt = entity.CreatedAt
            };
        }

        private static Faq MapToEntity(FaqDto dto)
        {
            return new Faq
            {
                Id = dto.Id,
                Answer = dto.Answer,
                Question = dto.Question,
                CreatedAt = dto.CreatedAt
            };
        }
        #endregion
    }
}
