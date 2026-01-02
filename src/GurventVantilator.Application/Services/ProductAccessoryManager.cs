using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class ProductAccessoryManager : IProductAccessoryService
    {
        private readonly IProductAccessoryRepository _repository;
        private readonly ILogger<ProductAccessoryManager> _logger;

        public ProductAccessoryManager(
            IProductAccessoryRepository repository,
            ILogger<ProductAccessoryManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // ===========================================================
        // 🔹 GET BY PRODUCT
        // ===========================================================
        public async Task<Result<IEnumerable<ProductAccessoryDto>>> GetByProductIdAsync(int productId)
        {
            try
            {
                var list = await _repository.GetByProductIdAsync(productId);
                var dtos = list.Select(MapToDto).ToList();

                return Result<IEnumerable<ProductAccessoryDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürüne ait aksesuarlar alınırken hata oluştu. ProductId={ProductId}", productId);
                return Result<IEnumerable<ProductAccessoryDto>>.Fail("Aksesuarlar getirilemedi.");
            }
        }

        // ===========================================================
        // 🔹 GET BY ID
        // ===========================================================
        public async Task<Result<ProductAccessoryDto>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    return Result<ProductAccessoryDto>.Fail("Aksesuar bulunamadı.");

                return Result<ProductAccessoryDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Aksesuar getirilirken hata oluştu. Id={Id}", id);
                return Result<ProductAccessoryDto>.Fail("Aksesuar getirilemedi.");
            }
        }

        // ===========================================================
        // 🔹 ADD
        // ===========================================================
        public async Task<Result<ProductAccessoryDto>> AddAsync(ProductAccessoryDto dto)
        {
            try
            {
                if (dto.ProductId <= 0)
                    return Result<ProductAccessoryDto>.Fail("ProductId zorunludur.");

                if (string.IsNullOrWhiteSpace(dto.AccessoryName))
                    return Result<ProductAccessoryDto>.Fail("AccessoryName boş olamaz.");

                var entity = MapToEntity(dto);
                await _repository.AddAsync(entity);

                return Result<ProductAccessoryDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Aksesuar eklenirken hata oluştu. ProductId={ProductId}", dto.ProductId);
                return Result<ProductAccessoryDto>.Fail("Aksesuar eklenemedi.");
            }
        }

        // ===========================================================
        // 🔹 UPDATE
        // ===========================================================
        public async Task<Result<ProductAccessoryDto>> UpdateAsync(ProductAccessoryDto dto)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(dto.Id);
                if (entity == null)
                    return Result<ProductAccessoryDto>.Fail("Güncellenecek aksesuar bulunamadı.");

                entity.AccessoryName = dto.AccessoryName;
                entity.Type = dto.Type;
                entity.ArticleNumber = dto.ArticleNumber;
                entity.ImagePath = dto.ImagePath;

                await _repository.UpdateAsync(entity);

                return Result<ProductAccessoryDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Aksesuar güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<ProductAccessoryDto>.Fail("Aksesuar güncellenemedi.");
            }
        }

        // ===========================================================
        // 🔹 DELETE
        // ===========================================================
        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek aksesuar bulunamadı.");

                await _repository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Aksesuar silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Aksesuar silinemedi.");
            }
        }

        #region Mapping

        private static ProductAccessoryDto MapToDto(ProductAccessory entity)
        {
            return new ProductAccessoryDto
            {
                Id = entity.Id,
                ProductId = entity.ProductId,
                AccessoryName = entity.AccessoryName,
                ArticleNumber = entity.ArticleNumber,
                Type = entity.Type,
                ImagePath = entity.ImagePath
            };
        }

        private static ProductAccessory MapToEntity(ProductAccessoryDto dto)
        {
            return new ProductAccessory
            {
                Id = dto.Id,
                ProductId = dto.ProductId,
                AccessoryName = dto.AccessoryName,
                ArticleNumber = dto.ArticleNumber,
                Type = dto.Type,
                ImagePath = dto.ImagePath,
                IsActive = true
            };
        }

        #endregion
    }
}
