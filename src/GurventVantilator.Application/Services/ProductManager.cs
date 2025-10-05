
using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductManager> _logger;

        public ProductManager(IProductRepository productRepository, ILogger<ProductManager> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<ProductDto>>> GetAllAsync()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
                var dtos = products.Select(b => MapToDto(b));
                return Result<IEnumerable<ProductDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün listesi alınırken hata oluştu");
                return Result<IEnumerable<ProductDto>>.Fail("Ürün listesi alınamadı.");
            }
        }

        public async Task<Result<ProductDto>> GetByIdAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                    return Result<ProductDto>.Fail("Ürün bulunamadı.");

                return Result<ProductDto>.Ok(MapToDto(product));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün bulunurken hata oluştu. Id={Id}", id);
                return Result<ProductDto>.Fail("Ürün getirilemedi.");
            }
        }

        public async Task<Result<ProductDto>> AddAsync(ProductDto dto)
        {
            try
            {
                var entity = MapToEntity(dto);

                await _productRepository.AddAsync(entity);

                return Result<ProductDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün ekleme sırasında hata oluştu");
                return Result<ProductDto>.Fail("Ürün eklenemedi.");
            }
        }

        public async Task<Result<ProductDto>> UpdateAsync(ProductDto dto)
        {
            try
            {
                var entity = MapToEntity(dto);

                await _productRepository.UpdateAsync(entity);

                return Result<ProductDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün güncelleme sırasında hata oluştu. Id={Id}", dto.Id);
                return Result<ProductDto>.Fail("Ürün güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                    return Result<bool>.Fail("Silinecek ürün bulunamadı.");

                await _productRepository.DeleteAsync(product);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün silme sırasında hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Ürün silinemedi.");
            }
        }


        #region Mapping
        private static ProductDto MapToDto(Product entity)
        {
            var dto = new ProductDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code,
                Description = entity.Description,
                CreatedAt = entity.CreatedAt,

                Diameter = entity.Diameter,
                AirFlowMin = entity.AirFlowMin,
                AirFlowMax = entity.AirFlowMax,
                PressureMin = entity.PressureMin,
                PressureMax = entity.PressureMax,
                Power = entity.Power,
                Voltage = entity.Voltage,
                Frequency = entity.Frequency,
                Speed = entity.Speed,
                NoiseLevel = entity.NoiseLevel,

                ImagePath = entity.ImagePath,
                DataSheetPath = entity.DataSheetPath,
                Model3DPath = entity.Model3DPath,

                ProductCategoryId = entity.ProductCategoryId,
                ProductCategoryName = entity.ProductCategory?.Name ?? string.Empty,

                IsActive = entity.IsActive,
                Order = entity.Order
            };

            return dto;
        }

        private static Product MapToEntity(ProductDto dto)
        {
            var entity = new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
                CreatedAt = dto.CreatedAt,

                Diameter = dto.Diameter,
                AirFlowMin = dto.AirFlowMin,
                AirFlowMax = dto.AirFlowMax,
                PressureMin = dto.PressureMin,
                PressureMax = dto.PressureMax,
                Power = dto.Power,
                Voltage = dto.Voltage,
                Frequency = dto.Frequency,
                Speed = dto.Speed,
                NoiseLevel = dto.NoiseLevel,

                ImagePath = dto.ImagePath,
                DataSheetPath = dto.DataSheetPath,
                Model3DPath = dto.Model3DPath,

                ProductCategoryId = dto.ProductCategoryId,
                IsActive = dto.IsActive,
                Order = dto.Order
            };

            return entity;
        }

        public async Task<Result<PagedResult<ProductDto>>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var (items, totalCount) = await _productRepository.GetPagedAsync(pageNumber, pageSize);

            var dto = new PagedResult<ProductDto>
            {
                Items = items.Select(b => MapToDto(b)).ToList(),
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Result<PagedResult<ProductDto>>.Ok(dto);
        }

        public async Task<Result<PagedResult<ProductDto>>> GetPagedAsync(int? productCategoryId, int pageNumber, int pageSize)
        {
            try
            {
                var products = await _productRepository.GetAllAsync();

                if (products == null || !products.Any())
                    return Result<PagedResult<ProductDto>>.Fail("Ürün bulunamadı.");

                var query = products.AsQueryable();

                // --- Category filtresi ---
                if (productCategoryId.HasValue)
                    query = query.Where(b => b.ProductCategoryId == productCategoryId.Value);

                // --- Total Count ---
                var totalCount = query.Count();

                // --- Sayfalama ---
                var pagedProducts = query
                    .OrderByDescending(b => b.CreatedAt)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                // --- DTO Map ---
                var dtoList = pagedProducts.Select(MapToDto).ToList();

                var pagedResult = new PagedResult<ProductDto>
                {
                    Items = dtoList,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                return Result<PagedResult<ProductDto>>.Ok(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün listesi çekilirken hata oluştu.");
                return Result<PagedResult<ProductDto>>.Fail("Ürünler yüklenirken bir hata oluştu.");
            }
        }
        #endregion
    }
}
