
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
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductApplicationRepository _productApplicationRepository;
        private readonly ILogger<ProductManager> _logger;

        public ProductManager(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository, IProductApplicationRepository productApplicationRepository, ILogger<ProductManager> logger)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _productApplicationRepository = productApplicationRepository;
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

                if (dto.SelectedApplicationIds != null && dto.SelectedApplicationIds.Any())
                {
                    var allApplications = await _productApplicationRepository.GetAllAsync();
                    var selectedApplications = allApplications
                        .Where(a => dto.SelectedApplicationIds.Contains(a.Id))
                        .ToList();

                    entity.Applications = selectedApplications;
                }

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
                var existing = await _productRepository.GetByIdAsync(dto.Id);
                if (existing == null)
                    return Result<ProductDto>.Fail("Güncellenecek ürün bulunamadı.");

                var updatedEntity = MapToEntity(dto);

                if (dto.SelectedApplicationIds != null && dto.SelectedApplicationIds.Any())
                {
                    var allApplications = await _productApplicationRepository.GetAllAsync();
                    var selectedApplications = allApplications
                        .Where(a => dto.SelectedApplicationIds.Contains(a.Id))
                        .ToList();

                    updatedEntity.Applications = selectedApplications;
                }
                else
                {
                    updatedEntity.Applications = new List<ProductApplication>();
                }

                updatedEntity.UpdatedAt = DateTime.UtcNow;

                await _productRepository.UpdateAsync(updatedEntity);

                return Result<ProductDto>.Ok(MapToDto(updatedEntity));
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

        public async Task<Result<List<ProductDto>>> GetProductsByCategoryAsync(int categoryId, bool includeSubCategories)
        {
            try
            {
                var allProducts = await _productRepository.GetAllAsync();

                if (allProducts == null)
                    return Result<List<ProductDto>>.Fail("Ürün bulunamadı.");

                IEnumerable<Product> filteredProducts;

                if (includeSubCategories)
                {
                    var allCategoryIds = await GetAllSubCategoryIdsAsync(categoryId);
                    allCategoryIds.Add(categoryId);

                    filteredProducts = allProducts.Where(p => allCategoryIds.Contains(p.ProductCategoryId));
                }
                else
                {
                    filteredProducts = allProducts.Where(p => p.ProductCategoryId == categoryId);
                }

                var products = filteredProducts
                    .Select(MapToDto)
                    .ToList();

                return Result<List<ProductDto>>.Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ürünler listelenirken hata oluştu.");
                return Result<List<ProductDto>>.Fail("Ürünler yüklenemedi.");
            }
        }

        private async Task<List<int>> GetAllSubCategoryIdsAsync(int parentId)
        {
            var categories = await _productCategoryRepository.GetAllAsync();
            var subIds = new List<int>();

            void AddSubCategories(int parent)
            {
                var children = categories.Where(c => c.ParentCategoryId == parent).ToList();
                foreach (var child in children)
                {
                    subIds.Add(child.Id);
                    AddSubCategories(child.Id);
                }
            }

            AddSubCategories(parentId);
            return subIds;
        }

        public async Task<Result<List<ProductDto>>> FilterAsync(ProductFilterRequest request)
        {
            try
            {
                var allProducts = await _productRepository.GetAllAsync();

                if (allProducts == null || !allProducts.Any())
                    return Result<List<ProductDto>>.Fail("Ürün bulunamadı.");

                var query = allProducts.AsQueryable();

                // 🔹 Uygulama Alanı filtresi
                if (request.ApplicationId.HasValue && request.ApplicationId.Value > 0)
                {
                    query = query.Where(p =>
                        p.Applications != null &&
                        p.Applications.Any(a => a.Id == request.ApplicationId.Value));
                }

                // 🔹 Ürün Kategorisi filtresi
                if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
                    query = query.Where(p => p.ProductCategoryId == request.CategoryId.Value);

                // 🔹 Tolerans oranı (0–100 arası, default 0)
                double tol = (request.TolerancePercent ?? 0) / 100.0;
                tol = tol < 0 ? 0 : (tol > 1 ? 1 : tol); // güvenli sınır

                // 🔹 Hava Debisi (AirFlow) filtresi
                if (request.AirFlow.HasValue)
                {
                    double airFlow = request.AirFlow.Value;
                    double min = airFlow * (1 - tol);
                    double max = airFlow * (1 + tol);

                    query = query.Where(p =>
                        p.AirFlow.HasValue &&
                        p.AirFlow.Value >= min &&
                        p.AirFlow.Value <= max);
                }

                // 🔹 Statik Basınç (Pressure) filtresi
                if (request.Pressure.HasValue)
                {
                    double pressure = request.Pressure.Value;
                    double min = pressure * (1 - tol);
                    double max = pressure * (1 + tol);

                    query = query.Where(p =>
                        p.Pressure.HasValue &&
                        p.Pressure.Value >= min &&
                        p.Pressure.Value <= max);
                }

                // 🔹 Frekans filtresi
                if (request.Frequency.HasValue)
                    query = query.Where(p => p.Frequency.HasValue && p.Frequency.Value == request.Frequency.Value);

                // 🔹 Çap (Diameter)
                if (request.Diameter.HasValue)
                    query = query.Where(p => p.Diameter.HasValue && p.Diameter.Value >= request.Diameter.Value);

                // 🔹 Motor Gücü (Power)
                if (request.Power.HasValue)
                    query = query.Where(p => p.Power.HasValue && p.Power.Value >= request.Power.Value);

                // 🔹 Gerilim (Voltage)
                if (request.Voltage.HasValue)
                    query = query.Where(p => p.Voltage.HasValue && p.Voltage.Value == request.Voltage.Value);

                // 🔹 Dönüş Hızı (Speed)
                if (request.Speed.HasValue)
                    query = query.Where(p => p.Speed.HasValue && p.Speed.Value >= request.Speed.Value);

                // 🔹 Ses Seviyesi (NoiseLevel)
                if (request.NoiseLevel.HasValue)
                    query = query.Where(p => p.NoiseLevel.HasValue && p.NoiseLevel.Value <= request.NoiseLevel.Value);

                // 🔹 Sadece aktif ürünler
                query = query.Where(p => p.IsActive);

                // 🔹 Sonuçları sırala
                var filteredList = query
                    .OrderBy(p => p.Order)
                    .ThenBy(p => p.Name)
                    .ToList();

                // 🔹 DTO dönüşümü
                var dtoList = filteredList.Select(MapToDto).ToList();

                return Result<List<ProductDto>>.Ok(dtoList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Filtreli ürün listesi alınırken hata oluştu.");
                return Result<List<ProductDto>>.Fail("Filtreli ürün listesi alınamadı.");
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

                // Boyut
                Diameter = entity.Diameter,
                DiameterUnit = entity.DiameterUnit,

                // Hava debisi
                AirFlow = entity.AirFlow,
                AirFlowUnit = entity.AirFlowUnit,

                // Basınç
                Pressure = entity.Pressure,
                PressureUnit = entity.PressureUnit,

                // Güç
                Power = entity.Power,
                PowerUnit = entity.PowerUnit,

                // Elektriksel
                Voltage = entity.Voltage,
                Frequency = entity.Frequency,

                // Performans
                Speed = entity.Speed,
                NoiseLevel = entity.NoiseLevel,
                SpeedControl = entity.SpeedControl,

                // Dosyalar
                Image1Path = entity.Image1Path,
                Image2Path = entity.Image2Path,
                Image3Path = entity.Image3Path,
                Image4Path = entity.Image4Path,
                Image5Path = entity.Image5Path,
                DataSheetPath = entity.DataSheetPath,
                Model3DPath = entity.Model3DPath,
                TestDataPath = entity.TestDataPath,
                ScaleImagePath = entity.ScaleImagePath,

                // İlişkiler
                ProductCategoryId = entity.ProductCategoryId,
                ProductCategoryName = entity.ProductCategory?.Name ?? string.Empty,

                // Ortak alanlar
                IsActive = entity.IsActive,
                Order = entity.Order,
                ContentTitle = entity.ContentTitle,
                ContentDescription = entity.ContentDescription,
                ContentFeatures = entity.ContentFeatures.Select(cf => new ProductContentFeatureDto
                {
                    Id = cf.Id,
                    ProductId = cf.ProductId,
                    Key = cf.Key,
                    Value = cf.Value,
                    Order = cf.Order
                }).ToList(),
            };

            if (entity.Applications != null && entity.Applications.Any())
            {
                dto.Applications = entity.Applications
                    .Select(a => new ProductApplicationDto
                    {
                        Id = a.Id,
                        Name = a.Name
                    })
                    .ToList();

                dto.SelectedApplicationIds = entity.Applications
                    .Select(a => a.Id)
                    .ToList();
            }

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

                // Boyut
                Diameter = dto.Diameter,
                DiameterUnit = dto.DiameterUnit,

                // Hava debisi
                AirFlow = dto.AirFlow,
                AirFlowUnit = dto.AirFlowUnit,

                // Basınç
                Pressure = dto.Pressure,
                PressureUnit = dto.PressureUnit,

                // Güç
                Power = dto.Power,
                PowerUnit = dto.PowerUnit,

                // Elektriksel
                Voltage = dto.Voltage,
                Frequency = dto.Frequency,

                // Performans
                Speed = dto.Speed,
                SpeedUnit = dto.SpeedUnit,
                NoiseLevel = dto.NoiseLevel,
                NoiseLevelUnit = dto.NoiseLevelUnit,
                SpeedControl = dto.SpeedControl,

                // Dosyalar
                Image1Path = dto.Image1Path,
                Image2Path = dto.Image2Path,
                Image3Path = dto.Image3Path,
                Image4Path = dto.Image4Path,
                Image5Path = dto.Image5Path,
                DataSheetPath = dto.DataSheetPath,
                Model3DPath = dto.Model3DPath,
                TestDataPath = dto.TestDataPath,
                ScaleImagePath = dto.ScaleImagePath,

                // İlişkiler
                ProductCategoryId = dto.ProductCategoryId,
                IsActive = dto.IsActive,
                Order = dto.Order,

                Applications = new List<ProductApplication>(),
                ContentTitle = dto.ContentTitle,
                ContentDescription = dto.ContentDescription,
                ContentFeatures = dto.ContentFeatures.Select(cf => new ProductContentFeature
                {
                    Id = cf.Id,
                    ProductId = cf.ProductId,
                    Key = cf.Key,
                    Value = cf.Value,
                    Order = cf.Order
                }).ToList()
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

                if (productCategoryId.HasValue)
                    query = query.Where(b => b.ProductCategoryId == productCategoryId.Value);

                var totalCount = query.Count();

                var pagedProducts = query
                    .OrderByDescending(b => b.CreatedAt)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

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
