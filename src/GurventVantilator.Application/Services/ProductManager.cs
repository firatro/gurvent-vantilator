using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Extensions;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductUsageTypeRepository _usageTypeRepository;
        private readonly IProductWorkingConditionRepository _workingConditionRepository;
        private readonly IProductModelRepository _productModelRepository;
        private readonly IProductSeriesRepository _productSeriesRepository;
        private readonly ILogger<ProductManager> _logger;

        public ProductManager(
            IProductRepository productRepository,
            IProductUsageTypeRepository usageTypeRepository,
            IProductWorkingConditionRepository workingConditionRepository,
            IProductModelRepository productModelRepository,
            IProductSeriesRepository productSeriesRepository,
            ILogger<ProductManager> logger)
        {
            _productRepository = productRepository;
            _usageTypeRepository = usageTypeRepository;
            _workingConditionRepository = workingConditionRepository;
            _productModelRepository = productModelRepository;
            _productSeriesRepository = productSeriesRepository;
            _logger = logger;
        }

        // ===========================================================
        // 🔹 GET ALL
        // ===========================================================
        public async Task<Result<IEnumerable<ProductDto>>> GetAllAsync()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
                var dtos = products.Select(p => p.MapToDto());
                return Result<IEnumerable<ProductDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün listesi alınırken hata oluştu.");
                return Result<IEnumerable<ProductDto>>.Fail("Ürün listesi alınamadı.");
            }
        }

        // ===========================================================
        // 🔹 GET BY ID
        // ===========================================================
        public async Task<Result<ProductDto>> GetByIdAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdWithIncludesAsync(id);
                if (product == null)
                    return Result<ProductDto>.Fail("Ürün bulunamadı.");

                return Result<ProductDto>.Ok(product.MapToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün getirilemedi. Id={Id}", id);
                return Result<ProductDto>.Fail("Ürün getirilemedi.");
            }
        }

        public async Task<Result<List<ProductDto>>> GetByModelIdAsync(int modelId)
        {
            try
            {
                var products = await _productRepository.GetByModelIdAsync(modelId);

                if (products == null || !products.Any())
                    return Result<List<ProductDto>>.Fail("Bu modele ait ürün bulunamadı.");

                var dtoList = products.Select(p => p.MapToDto()).ToList();

                return Result<List<ProductDto>>.Ok(dtoList);
            }
            catch (Exception ex)
            {
                return Result<List<ProductDto>>.Fail(ex.Message);
            }
        }


        // ===========================================================
        // 🔹 ADD
        // ===========================================================
        public async Task<Result<ProductDto>> AddAsync(ProductDto dto)
        {
            try
            {
                var entity = dto.MapToEntity();

                // Series & Model
                if (dto.ProductModelId.HasValue)
                    entity.ProductModelId = dto.ProductModelId;
                if (dto.ProductSeriesId.HasValue)
                    entity.ProductSeriesId = dto.ProductSeriesId;

                // UsageTypes
                if (dto.UsageTypeIds != null && dto.UsageTypeIds.Any())
                {
                    var usageTypes = await _usageTypeRepository.GetByIdsAsync(dto.UsageTypeIds);
                    foreach (var ut in usageTypes)
                        entity.UsageTypes.Add(ut);
                }

                // WorkingConditions
                if (dto.WorkingConditionIds != null && dto.WorkingConditionIds.Any())
                {
                    var workingConditions = await _workingConditionRepository.GetByIdsAsync(dto.WorkingConditionIds);
                    foreach (var wc in workingConditions)
                        entity.WorkingConditions.Add(wc);
                }

                await _productRepository.AddAsync(entity);
                return Result<ProductDto>.Ok(entity.MapToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün eklenemedi: {Name}", dto.Name);
                return Result<ProductDto>.Fail("Ürün eklenemedi.");
            }
        }

        // ===========================================================
        // 🔹 UPDATE
        // ===========================================================
        public async Task<Result<ProductDto>> UpdateAsync(ProductDto dto)
        {
            try
            {
                var existing = await _productRepository.GetByIdWithIncludesAsync(dto.Id);
                if (existing == null)
                    return Result<ProductDto>.Fail("Güncellenecek ürün bulunamadı.");

                existing = dto.MapToEntity(existing);

                // --- UsageTypes güncelle ---
                existing.UsageTypes.Clear();
                if (dto.UsageTypeIds != null && dto.UsageTypeIds.Any())
                {
                    var usageTypes = await _usageTypeRepository.GetByIdsAsync(dto.UsageTypeIds);
                    foreach (var ut in usageTypes)
                        existing.UsageTypes.Add(ut);
                }

                // --- WorkingConditions güncelle ---
                existing.WorkingConditions.Clear();
                if (dto.WorkingConditionIds != null && dto.WorkingConditionIds.Any())
                {
                    var workingConditions = await _workingConditionRepository.GetByIdsAsync(dto.WorkingConditionIds);
                    foreach (var wc in workingConditions)
                        existing.WorkingConditions.Add(wc);
                }

                existing.UpdatedAt = DateTime.UtcNow;

                await _productRepository.UpdateAsync(existing);
                return Result<ProductDto>.Ok(existing.MapToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürün güncellenemedi. Id={Id}", dto.Id);
                return Result<ProductDto>.Fail("Ürün güncellenemedi.");
            }
        }

        // ===========================================================
        // 🔹 DELETE
        // ===========================================================
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
                _logger.LogError(ex, "Ürün silinemedi. Id={Id}", id);
                return Result<bool>.Fail("Ürün silinemedi.");
            }
        }

        // ===========================================================
        // 🔹 FILTRELEME
        // ===========================================================
        public async Task<Result<List<ProductDto>>> FilterAsync(ProductFilterRequest request)
        {
            try
            {
                var allProducts = await _productRepository.GetAllAsync();

                if (allProducts == null || !allProducts.Any())
                    return Result<List<ProductDto>>.Fail("Ürün bulunamadı.");

                var query = allProducts.AsQueryable();

                // 🔹 Hava Debisi toleranslı filtre
                double tol = (request.TolerancePercent ?? 0) / 100.0;
                tol = Math.Clamp(tol, 0, 1);

                if (request.AirFlow.HasValue)
                {
                    double airFlow = request.AirFlow.Value;
                    double min = airFlow * (1 - tol);
                    double max = airFlow * (1 + tol);

                    query = query.Where(p => p.AirFlow >= min && p.AirFlow <= max);
                }

                if (request.TotalPressure.HasValue)
                {
                    double totalPressure = request.TotalPressure.Value;
                    double min = totalPressure * (1 - tol);
                    double max = totalPressure * (1 + tol);

                    query = query.Where(p => p.TotalPressure >= min && p.TotalPressure <= max);
                }

                query = query.Where(p => p.IsActive);

                var list = query.OrderBy(p => p.Order).ThenBy(p => p.Name).ToList();
                var dtoList = list.Select(p => p.MapToDto()).ToList();

                return Result<List<ProductDto>>.Ok(dtoList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Filtreli ürün listesi alınamadı.");
                return Result<List<ProductDto>>.Fail("Ürünler filtrelenirken hata oluştu.");
            }
        }

        // ===========================================================
        // 🔹 PAGED LIST
        // ===========================================================
        public async Task<Result<PagedResult<ProductDto>>> GetPagedAsync(int pageNumber, int pageSize)
        {
            try
            {
                var (items, totalCount) = await _productRepository.GetPagedAsync(pageNumber, pageSize);

                var dto = new PagedResult<ProductDto>
                {
                    Items = items.Select(i => i.MapToDto()).ToList(),
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                return Result<PagedResult<ProductDto>>.Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sayfalı ürün listesi alınamadı.");
                return Result<PagedResult<ProductDto>>.Fail("Ürünler yüklenirken hata oluştu.");
            }
        }
    }
}
