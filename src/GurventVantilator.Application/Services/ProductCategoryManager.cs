using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class ProductCategoryManager : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ILogger<ProductCategoryManager> _logger;

        public ProductCategoryManager(IProductCategoryRepository productCategoryRepository, ILogger<ProductCategoryManager> logger)
        {
            _productCategoryRepository = productCategoryRepository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<ProductCategoryDto>>> GetAllAsync()
        {
            try
            {
                var productCategories = await _productCategoryRepository.GetAllAsync();
                var dtos = productCategories.Select(MapToDto).ToList();

                return Result<IEnumerable<ProductCategoryDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kategori listesi alınırken hata oluştu.");
                return Result<IEnumerable<ProductCategoryDto>>.Fail("Kategori listesi getirilemedi.");
            }
        }

        public async Task<Result<ProductCategoryDto>> GetByIdAsync(int id)
        {
            try
            {
                var productCategory = await _productCategoryRepository.GetByIdAsync(id);
                if (productCategory == null)
                    return Result<ProductCategoryDto>.Fail("Kategori bulunamadı.");

                return Result<ProductCategoryDto>.Ok(MapToDto(productCategory));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kategori getirilirken hata oluştu. Id={Id}", id);
                return Result<ProductCategoryDto>.Fail("Kategori getirilemedi.");
            }
        }

        public async Task<Result<ProductCategoryDto>> AddAsync(ProductCategoryDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Name))
                    return Result<ProductCategoryDto>.Fail("Kategori adı boş olamaz.");

                var entity = MapToEntity(dto);
                await _productCategoryRepository.AddAsync(entity);

                return Result<ProductCategoryDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kategori eklenirken hata oluştu.");
                return Result<ProductCategoryDto>.Fail("Kategori eklenemedi.");
            }
        }

        public async Task<Result<ProductCategoryDto>> UpdateAsync(ProductCategoryDto dto)
        {
            try
            {
                var entity = MapToEntity(dto);

                await _productCategoryRepository.UpdateAsync(entity);

                return Result<ProductCategoryDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün kategori güncelleme sırasında hata oluştu. Id={Id}", dto.Id);
                return Result<ProductCategoryDto>.Fail("Ürün kategori güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var productCategory = await _productCategoryRepository.GetByIdAsync(id);
                if (productCategory == null)
                    return Result<bool>.Fail("Silinecek kategori bulunamadı.");

                await _productCategoryRepository.DeleteAsync(productCategory);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kategori silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Kategori silinemedi.");
            }
        }

        #region Mapping
        public static ProductCategoryDto MapToDto(ProductCategory entity)
        {
            return new ProductCategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ImagePath = entity.ImagePath,
                IsActive = entity.IsActive,
                Order = entity.Order,

                // Ürün sayısını hesaplamak istiyorsan:
                ProductCount = entity.Products?.Count ?? 0
            };
        }

        public static ProductCategory MapToEntity(ProductCategoryDto dto)
        {
            return new ProductCategory
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                ImagePath = dto.ImagePath,
                IsActive = dto.IsActive,
                Order = dto.Order,
                UpdatedAt = DateTime.UtcNow
            };
        }
        #endregion
    }
}
