using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class ChatBotQAManager : IChatBotQAService
    {
        private readonly IChatBotQARepository _chatBotQARepository;
        private readonly ILogger<ChatBotQAManager> _logger;

        public ChatBotQAManager(IChatBotQARepository chatBotQARepository, ILogger<ChatBotQAManager> logger)
        {
            _chatBotQARepository = chatBotQARepository;
            _logger = logger;
        }

        public async Task<Result<ChatBotQADto>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _chatBotQARepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<ChatBotQADto>.Fail("Soru-Cevap kaydı bulunamadı.");

                return Result<ChatBotQADto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ChatBotQA getirme sırasında hata oluştu. Id={Id}", id);
                return Result<ChatBotQADto>.Fail("Soru-Cevap kaydı getirilemedi.");
            }
        }

        public async Task<Result<IEnumerable<ChatBotQADto>>> GetAllAsync()
        {
            try
            {
                var entities = await _chatBotQARepository.GetAllAsync();
                var dtos = entities.Select(MapToDto).ToList();
                return Result<IEnumerable<ChatBotQADto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ChatBotQA listesi alınırken hata oluştu.");
                return Result<IEnumerable<ChatBotQADto>>.Fail("Soru-Cevap listesi getirilemedi.");
            }
        }

        public async Task<Result<ChatBotQADto>> AddAsync(ChatBotQADto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Question))
                    return Result<ChatBotQADto>.Fail("Soru boş olamaz.");

                var entity = MapToEntity(dto);
                await _chatBotQARepository.AddAsync(entity);

                return Result<ChatBotQADto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ChatBotQA ekleme sırasında hata oluştu.");
                return Result<ChatBotQADto>.Fail("Soru-Cevap eklenemedi.");
            }
        }

        public async Task<Result<ChatBotQADto>> UpdateAsync(ChatBotQADto dto)
        {
            try
            {
                var entity = await _chatBotQARepository.GetByIdAsync(dto.Id);
                if (entity == null)
                    return Result<ChatBotQADto>.Fail("Güncellenecek kayıt bulunamadı.");

                entity.LanguageCode = dto.LanguageCode;
                entity.Question = dto.Question;
                entity.Answer = dto.Answer;
                entity.IsActive = dto.IsActive;

                await _chatBotQARepository.UpdateAsync(entity);

                return Result<ChatBotQADto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ChatBotQA güncelleme sırasında hata oluştu. Id={Id}", dto.Id);
                return Result<ChatBotQADto>.Fail("Soru-Cevap güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _chatBotQARepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek kayıt bulunamadı.");

                await _chatBotQARepository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ChatBotQA silme sırasında hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Soru-Cevap silinemedi.");
            }
        }

        #region Mapping
        private static ChatBotQADto MapToDto(ChatBotQA entity)
        {
            return new ChatBotQADto
            {
                Id = entity.Id,
                LanguageCode = entity.LanguageCode,
                Question = entity.Question,
                Answer = entity.Answer,
                IsActive = entity.IsActive
            };
        }

        private static ChatBotQA MapToEntity(ChatBotQADto dto)
        {
            return new ChatBotQA
            {
                Id = dto.Id,
                LanguageCode = dto.LanguageCode,
                Question = dto.Question,
                Answer = dto.Answer,
                IsActive = dto.IsActive
            };
        }
        #endregion
    }
}
