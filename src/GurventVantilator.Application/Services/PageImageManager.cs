using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class PageImageManager : IPageImageService
    {
        private readonly IPageImageRepository _repository;
        private readonly ILogger<PageImageManager> _logger;

        public PageImageManager(IPageImageRepository repository, ILogger<PageImageManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Result<PageImageDto>> GetImageAsync(string pageKey, string imageType)
        {
            try
            {
                var entity = await _repository.GetByPageAndTypeAsync(pageKey, imageType);
                if (entity == null)
                    return Result<PageImageDto>.Fail("Sayfa görseli bulunamadı.");

                return Result<PageImageDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sayfa görseli alınırken hata oluştu. PageKey={PageKey}, ImageType={ImageType}", pageKey, imageType);
                return Result<PageImageDto>.Fail("Sayfa görseli getirilemedi.");
            }
        }

        public async Task<Result<IEnumerable<PageImageDto>>> GetAllAsync()
        {
            try
            {
                var list = await _repository.GetAllAsync();
                var dtos = list.Select(MapToDto).ToList();

                return Result<IEnumerable<PageImageDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sayfa görselleri alınırken hata oluştu.");
                return Result<IEnumerable<PageImageDto>>.Fail("Sayfa görselleri getirilemedi.");
            }
        }

        public async Task<Result<PageImageDto>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    return Result<PageImageDto>.Fail("Sayfa görseli bulunamadı.");

                return Result<PageImageDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sayfa görseli getirilirken hata oluştu. Id={Id}", id);
                return Result<PageImageDto>.Fail("Sayfa görseli getirilemedi.");
            }
        }

        public async Task<Result<PageImageDto>> AddAsync(PageImageDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.PageKey))
                    return Result<PageImageDto>.Fail("PageKey boş olamaz.");
                if (string.IsNullOrWhiteSpace(dto.ImageType))
                    return Result<PageImageDto>.Fail("ImageType boş olamaz.");

                var entity = MapToEntity(dto);
                await _repository.AddAsync(entity);

                return Result<PageImageDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sayfa görseli eklenirken hata oluştu.");
                return Result<PageImageDto>.Fail("Sayfa görseli eklenemedi.");
            }
        }

        public async Task<Result<PageImageDto>> UpdateAsync(PageImageDto dto)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(dto.Id);
                if (entity == null)
                    return Result<PageImageDto>.Fail("Güncellenecek sayfa görseli bulunamadı.");

                entity.ImagePath = dto.ImagePath;
                entity.ImageType = dto.ImageType;
                entity.PageKey = dto.PageKey;

                await _repository.UpdateAsync(entity);

                return Result<PageImageDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sayfa görseli güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<PageImageDto>.Fail("Sayfa görseli güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek sayfa görseli bulunamadı.");

                await _repository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sayfa görseli silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Sayfa görseli silinemedi.");
            }
        }

        #region Mapping
        private static PageImageDto MapToDto(PageImage entity)
        {
            return new PageImageDto
            {
                Id = entity.Id,
                ImagePath = entity.ImagePath,
                ImageType = entity.ImageType,
                PageKey = entity.PageKey
            };
        }

        private static PageImage MapToEntity(PageImageDto dto)
        {
            return new PageImage
            {
                Id = dto.Id,
                ImagePath = dto.ImagePath,
                ImageType = dto.ImageType,
                PageKey = dto.PageKey
            };
        }
        #endregion
    }
}
