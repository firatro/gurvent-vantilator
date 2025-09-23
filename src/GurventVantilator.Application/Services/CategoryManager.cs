using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryManager> _logger;

        public CategoryManager(ICategoryRepository categoryRepository, ILogger<CategoryManager> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<CategoryDto>>> GetAllAsync()
        {
            try
            {
                var categories = await _categoryRepository.GetAllAsync();
                var dtos = categories.Select(MapToDto).ToList();

                return Result<IEnumerable<CategoryDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kategori listesi alınırken hata oluştu.");
                return Result<IEnumerable<CategoryDto>>.Fail("Kategori listesi getirilemedi.");
            }
        }

        public async Task<Result<CategoryDto>> GetByIdAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                if (category == null)
                    return Result<CategoryDto>.Fail("Kategori bulunamadı.");

                return Result<CategoryDto>.Ok(MapToDto(category));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kategori getirilirken hata oluştu. Id={Id}", id);
                return Result<CategoryDto>.Fail("Kategori getirilemedi.");
            }
        }

        public async Task<Result<CategoryDto>> AddAsync(CategoryDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Name))
                    return Result<CategoryDto>.Fail("Kategori adı boş olamaz.");

                var entity = MapToEntity(dto);
                await _categoryRepository.AddAsync(entity);

                return Result<CategoryDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kategori eklenirken hata oluştu.");
                return Result<CategoryDto>.Fail("Kategori eklenemedi.");
            }
        }

        public async Task<Result<CategoryDto>> UpdateAsync(CategoryDto dto)
        {
            try
            {
                var existing = await _categoryRepository.GetByIdAsync(dto.Id);
                if (existing == null)
                    return Result<CategoryDto>.Fail("Güncellenecek kategori bulunamadı.");

                existing.Name = dto.Name;

                await _categoryRepository.UpdateAsync(existing);

                return Result<CategoryDto>.Ok(MapToDto(existing));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kategori güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<CategoryDto>.Fail("Kategori güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                if (category == null)
                    return Result<bool>.Fail("Silinecek kategori bulunamadı.");

                await _categoryRepository.DeleteAsync(category);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kategori silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Kategori silinemedi.");
            }
        }

        #region Mapping
        public static CategoryDto MapToDto(Category entity)
        {
            return new CategoryDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static Category MapToEntity(CategoryDto dto)
        {
            return new Category
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
        #endregion
    }
}
