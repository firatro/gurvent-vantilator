

using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class TagManager : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly ILogger<TagManager> _logger;

        public TagManager(ITagRepository tagRepository, ILogger<TagManager> logger)
        {
            _tagRepository = tagRepository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<TagDto>>> GetAllAsync()
        {
            try
            {
                var tags = await _tagRepository.GetAllAsync();
                var dtos = tags.Select(MapToDto).ToList();
                return Result<IEnumerable<TagDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Etiketler listelenirken hata oluştu.");
                return Result<IEnumerable<TagDto>>.Fail("Etiketler getirilemedi.");
            }
        }

        public async Task<Result<TagDto>> GetByIdAsync(int id)
        {
            try
            {
                var tag = await _tagRepository.GetByIdAsync(id);
                if (tag == null)
                    return Result<TagDto>.Fail("Etiket bulunamadı.");

                return Result<TagDto>.Ok(MapToDto(tag));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Etiket getirilirken hata oluştu. Id={Id}", id);
                return Result<TagDto>.Fail("Etiket getirilemedi.");
            }
        }

        public async Task<Result<TagDto>> AddAsync(TagDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Name))
                    return Result<TagDto>.Fail("Etiket adı boş olamaz.");

                var entity = MapToEntity(dto);
                await _tagRepository.AddAsync(entity);

                return Result<TagDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Etiket eklenirken hata oluştu.");
                return Result<TagDto>.Fail("Etiket eklenemedi.");
            }
        }

        public async Task<Result<bool>> UpdateAsync(TagDto dto)
        {
            try
            {
                var entity = await _tagRepository.GetByIdAsync(dto.Id);
                if (entity == null)
                    return Result<bool>.Fail("Güncellenecek etiket bulunamadı.");

                entity.Name = dto.Name;
                await _tagRepository.UpdateAsync(entity);

                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Etiket güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<bool>.Fail("Etiket güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _tagRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek etiket bulunamadı.");

                await _tagRepository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Etiket silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Etiket silinemedi.");
            }
        }

        #region Mapping
        private static TagDto MapToDto(Tag entity)
        {
            return new TagDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        private static Tag MapToEntity(TagDto dto)
        {
            return new Tag
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
        #endregion
    }

}
