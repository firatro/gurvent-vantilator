using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Extensions;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class ProductModelManager : IProductModelService
    {
        private readonly IProductModelRepository _modelRepository;
        private readonly IProductUsageTypeRepository _usageTypeRepository;
        private readonly IProductWorkingConditionRepository _workingRepository;
        private readonly IProductContentFeatureRepository _contentFeatureRepository;
        private readonly IProductTestDataRepository _testDataRepository;
        private readonly ILogger<ProductModelManager> _logger;

        public ProductModelManager(
            IProductModelRepository modelRepository,
            IProductUsageTypeRepository usageTypeRepository,
            IProductWorkingConditionRepository workingRepository,
            IProductContentFeatureRepository contentFeatureRepository,
            IProductTestDataRepository testDataRepository,
            ILogger<ProductModelManager> logger)
        {
            _modelRepository = modelRepository;
            _usageTypeRepository = usageTypeRepository;
            _workingRepository = workingRepository;
            _contentFeatureRepository = contentFeatureRepository;
            _testDataRepository = testDataRepository;
            _logger = logger;
        }


        // ======================================================
        // 📌 LIST
        // ======================================================
        public async Task<Result<IEnumerable<ProductModelDto>>> GetAllAsync()
        {
            try
            {
                var list = await _modelRepository.GetAllAsync();
                var dtos = list.Select(MapToDto);
                return Result<IEnumerable<ProductModelDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Model listesi alınırken hata oluştu.");
                return Result<IEnumerable<ProductModelDto>>.Fail("Model listesi alınamadı.");
            }
        }


        // ======================================================
        // 🔍 GET BY ID (INCLUDES)
        // ======================================================
        public async Task<Result<ProductModelDto>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _modelRepository.GetByIdWithIncludesAsync(id);
                if (entity == null)
                    return Result<ProductModelDto>.Fail("Model bulunamadı.");

                return Result<ProductModelDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Model getirilemedi. Id={Id}", id);
                return Result<ProductModelDto>.Fail("Model getirilemedi.");
            }
        }


        // ======================================================
        // ➕ CREATE
        // ======================================================
        public async Task<Result<ProductModelDto>> AddAsync(ProductModelDto dto)
        {
            try
            {
                var entity = MapToEntity(dto);

                // 🔹 Usage Types
                if (dto.UsageTypeIds.Any())
                {
                    var items = await _usageTypeRepository.GetByIdsAsync(dto.UsageTypeIds);
                    foreach (var ut in items)
                        entity.UsageTypes.Add(ut);
                }

                // 🔹 Working Conditions
                if (dto.WorkingConditionIds.Any())
                {
                    var items = await _workingRepository.GetByIdsAsync(dto.WorkingConditionIds);
                    foreach (var wc in items)
                        entity.WorkingConditions.Add(wc);
                }

                // 🔹 Content Features
                if (dto.ContentFeatures.Any())
                {
                    foreach (var cf in dto.ContentFeatures)
                    {
                        entity.ContentFeatures.Add(new ProductContentFeature
                        {
                            Key = cf.Key,
                            Value = cf.Value,
                            Order = cf.Order,
                        });
                    }
                }

                await _modelRepository.AddAsync(entity);

                return Result<ProductModelDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Model eklenemedi. {Name}", dto.Name);
                return Result<ProductModelDto>.Fail("Model eklenemedi.");
            }
        }


        public async Task<Result<ProductModelDto>> UpdateAsync(ProductModelDto dto)
        {
            try
            {
                var existing = await _modelRepository.GetByIdWithIncludesAsync(dto.Id);
                if (existing == null)
                    return Result<ProductModelDto>.Fail("Model bulunamadı.");

                // ================================================================
                // 1) TEMEL ALANLARI GÜNCELLE
                // ================================================================
                existing.Name = dto.Name;
                existing.Description = dto.Description;
                existing.Code = dto.Code;
                existing.ProductSeriesId = dto.ProductSeriesId;

                existing.Image1Path = dto.Image1Path;
                existing.Image2Path = dto.Image2Path;
                existing.Image3Path = dto.Image3Path;
                existing.Image4Path = dto.Image4Path;
                existing.Image5Path = dto.Image5Path;

                existing.DataSheetPath = dto.DataSheetPath;
                existing.Model3DPath = dto.Model3DPath;
                existing.TestDataPath = dto.TestDataPath;
                existing.ScaleImagePath = dto.ScaleImagePath;

                existing.AirFlow = dto.AirFlow;
                existing.AirFlowUnit = dto.AirFlowUnit;
                existing.TotalPressure = dto.TotalPressure;
                existing.TotalPressureUnit = dto.TotalPressureUnit;
                existing.Power = dto.Power;
                existing.Voltage = dto.Voltage;
                existing.Frequency = dto.Frequency;
                existing.SpeedControl = dto.SpeedControl;
                existing.Temperature = dto.Temperature;

                existing.ContentTitle = dto.ContentTitle;
                existing.ContentDescription = dto.ContentDescription;

                existing.BodyMaterialStandard = dto.BodyMaterialStandard;
                existing.ColdResistanceStandard = dto.ColdResistanceStandard;
                existing.HeatResistanceStandard = dto.HeatResistanceStandard;
                existing.CarryingBracketStandard = dto.CarryingBracketStandard;
                existing.ImpellerMaterialStandard = dto.ImpellerMaterialStandard;
                existing.MotorProtectionCapStandard = dto.MotorProtectionCapStandard;

                existing.BodyMaterialOptional = dto.BodyMaterialOptional;
                existing.ColdResistanceOptional = dto.ColdResistanceOptional;
                existing.HeatResistanceOptional = dto.HeatResistanceOptional;
                existing.CarryingBracketOptional = dto.CarryingBracketOptional;
                existing.ImpellerMaterialOptional = dto.ImpellerMaterialOptional;
                existing.MotorProtectionCapOptional = dto.MotorProtectionCapOptional;

                // ================================================================
                // 2) KULLANIM TIPLERI
                // ================================================================
                existing.UsageTypes.Clear();
                if (dto.UsageTypeIds.Any())
                {
                    var items = await _usageTypeRepository.GetByIdsAsync(dto.UsageTypeIds);
                    foreach (var ut in items)
                        existing.UsageTypes.Add(ut);
                }

                // ================================================================
                // 3) ÇALIŞMA KOŞULLARI
                // ================================================================
                existing.WorkingConditions.Clear();
                if (dto.WorkingConditionIds.Any())
                {
                    var items = await _workingRepository.GetByIdsAsync(dto.WorkingConditionIds);
                    foreach (var wc in items)
                        existing.WorkingConditions.Add(wc);
                }

                // ================================================================
                // 4) CONTENT FEATURES güncelleme
                // ================================================================
                existing.ContentFeatures.Clear();
                foreach (var cf in dto.ContentFeatures)
                {
                    existing.ContentFeatures.Add(new ProductContentFeature
                    {
                        Key = cf.Key,
                        Value = cf.Value,
                        Order = cf.Order,
                    });
                }

                // ================================================================
                // 5) MODEL FEATURES: Sil, Güncelle, Ekle
                // ================================================================

                // --- 5.1 Silinecekler ---
                if (dto.DeletedFeatureIds != null)
                {
                    foreach (var id in dto.DeletedFeatureIds)
                    {
                        var f = existing.ModelFeatures.FirstOrDefault(x => x.Id == id);
                        if (f != null)
                            existing.ModelFeatures.Remove(f); // EF bunu siler
                    }
                }

                // --- 5.2 Güncellenecek (Id > 0) ---
                foreach (var fDto in dto.ModelFeatures.Where(x => x.Id > 0))
                {
                    var feature = existing.ModelFeatures.FirstOrDefault(x => x.Id == fDto.Id);
                    if (feature != null)
                    {
                        feature.FeatureName = fDto.FeatureName;
                        feature.StandardValue = fDto.StandardValue;
                        feature.OptionalValue = fDto.OptionalValue;
                        feature.Order = fDto.Order;
                    }
                }

                // --- 5.3 Yeni eklenenler (Id = 0) ---
                foreach (var fDto in dto.ModelFeatures.Where(x => x.Id == 0))
                {
                    existing.ModelFeatures.Add(new ProductModelFeature
                    {
                        FeatureName = fDto.FeatureName,
                        StandardValue = fDto.StandardValue,
                        OptionalValue = fDto.OptionalValue,
                        Order = fDto.Order,
                        ProductModelId = existing.Id
                    });
                }

                // ================================================================
                // 6) KAYDET
                // ================================================================
                existing.UpdatedAt = DateTime.UtcNow;
                await _modelRepository.UpdateAsync(existing);

                return Result<ProductModelDto>.Ok(MapToDto(existing));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Model güncellenemedi. Id={Id}", dto.Id);
                return Result<ProductModelDto>.Fail("Model güncellenemedi.");
            }
        }



        // ======================================================
        // 🗑 DELETE
        // ======================================================
        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _modelRepository.GetByIdWithDeleteIncludesAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Model bulunamadı.");

                // ❗ Ürün varsa silme
                if (entity.Products.Any())
                {
                    return Result<bool>.Fail(
                        "Bu modele bağlı ürünler var. Önce ürünleri silmelisiniz."
                    );
                }

                // 🔹 Many-to-Many temizle
                entity.UsageTypes.Clear();
                entity.WorkingConditions.Clear();

                // 🔹 Child tablolar
                _modelRepository.RemoveContentFeatures(entity.ContentFeatures);
                _modelRepository.RemoveModelFeatures(entity.ModelFeatures);
                _modelRepository.RemoveDocuments(entity.Documents);

                await _modelRepository.DeleteAsync(entity);

                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Model silinemedi. Id={Id}", id);
                return Result<bool>.Fail("Model silinemedi. İlişkili kayıtlar mevcut.");
            }
        }



        // ======================================================
        // 🔍 GET MODELS BY SERIES
        // ======================================================
        public async Task<Result<List<ProductModelDto>>> GetBySeriesIdAsync(int seriesId)
        {
            try
            {
                var list = await _modelRepository.GetBySeriesIdAsync(seriesId);
                return Result<List<ProductModelDto>>.Ok(list.Select(MapToDto).ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Seriye göre modeller getirilemedi. SeriesId={Id}", seriesId);
                return Result<List<ProductModelDto>>.Fail("Modeller yüklenemedi.");
            }
        }


        // ======================================================
        // 🔍 PAGED (Product ile birebir)
        // ======================================================
        public async Task<Result<PagedResult<ProductModelDto>>> GetPagedAsync(int pageNumber, int pageSize)
        {
            try
            {
                var (items, totalCount) = await _modelRepository.GetPagedAsync(pageNumber, pageSize);

                var dto = new PagedResult<ProductModelDto>
                {
                    Items = items.Select(MapToDto).ToList(),
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                return Result<PagedResult<ProductModelDto>>.Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sayfalı model listesi alınamadı.");
                return Result<PagedResult<ProductModelDto>>.Fail("Modeller yüklenirken hata oluştu.");
            }
        }


        // ======================================================
        // 🔍 FILTER
        // ======================================================
        public async Task<Result<List<ProductModelDto>>> FilterAsync(ProductModelFilterRequest request)
        {
            try
            {
                var all = await _modelRepository.GetAllAsync();

                var query = all.AsQueryable();

                if (request.SeriesId.HasValue)
                    query = query.Where(m => m.ProductSeriesId == request.SeriesId);

                if (!string.IsNullOrWhiteSpace(request.Name))
                    query = query.Where(m => m.Name.Contains(request.Name));

                if (request.IsActive.HasValue)
                    query = query.Where(m => m.IsActive == request.IsActive.Value);

                var list = query.OrderBy(m => m.Order).ToList();
                var dtoList = list.Select(MapToDto).ToList();

                return Result<List<ProductModelDto>>.Ok(dtoList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Model filtrelemesi başarısız.");
                return Result<List<ProductModelDto>>.Fail("Model filtrelenemedi.");
            }
        }


        // ======================================================
        // 🔄 MAPPERS
        // ======================================================
        private static ProductModelDto MapToDto(ProductModel entity)
        {
            return new ProductModelDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code,
                Description = entity.Description,

                ProductSeriesId = entity.ProductSeriesId,
                ProductSeriesName = entity.ProductSeries?.Name,

                UsageTypeIds = entity.UsageTypes.Select(u => u.Id).ToList(),
                UsageTypeNames = entity.UsageTypes.Select(u => u.Name).ToList(),

                WorkingConditionIds = entity.WorkingConditions.Select(w => w.Id).ToList(),
                WorkingConditionNames = entity.WorkingConditions.Select(w => w.Name).ToList(),

                ContentTitle = entity.ContentTitle,
                ContentDescription = entity.ContentDescription,
                ContentFeatures = entity.ContentFeatures
                    .Select(cf => new ProductContentFeatureDto
                    {
                        Key = cf.Key,
                        Value = cf.Value,
                        Order = cf.Order
                    }).ToList(),

                AirFlow = entity.AirFlow,
                AirFlowUnit = entity.AirFlowUnit,
                TotalPressure = entity.TotalPressure,
                TotalPressureUnit = entity.TotalPressureUnit,
                Power = entity.Power,
                Voltage = entity.Voltage,
                Frequency = entity.Frequency,
                SpeedControl = entity.SpeedControl,
                Temperature = entity.Temperature,

                Image1Path = entity.Image1Path,
                Image2Path = entity.Image2Path,
                Image3Path = entity.Image3Path,
                Image4Path = entity.Image4Path,
                Image5Path = entity.Image5Path,

                DataSheetPath = entity.DataSheetPath,
                Model3DPath = entity.Model3DPath,
                TestDataPath = entity.TestDataPath,
                ScaleImagePath = entity.ScaleImagePath,

                IsActive = entity.IsActive,
                Order = entity.Order,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,

                // 🔥🔥🔥 EN ÖNEMLİ EKLEME — DOCUMENTS ARTIK DTO’YA AKTARILIYOR
                Documents = entity.Documents?
                    .Select(d => new ProductModelDocumentDto
                    {
                        Id = d.Id,
                        ProductModelId = d.ProductModelId,
                        Title = d.Title,
                        FilePath = d.FilePath
                    }).ToList() ?? new(),
                BodyMaterialStandard = entity.BodyMaterialStandard,
                ImpellerMaterialStandard = entity.ImpellerMaterialStandard,
                CarryingBracketStandard = entity.CarryingBracketStandard,
                HeatResistanceStandard = entity.HeatResistanceStandard,
                ColdResistanceStandard = entity.ColdResistanceStandard,
                MotorProtectionCapStandard = entity.MotorProtectionCapStandard,
                BodyMaterialOptional = entity.BodyMaterialOptional,
                ImpellerMaterialOptional = entity.ImpellerMaterialOptional,
                CarryingBracketOptional = entity.CarryingBracketOptional,
                HeatResistanceOptional = entity.HeatResistanceOptional,
                ColdResistanceOptional = entity.ColdResistanceOptional,
                MotorProtectionCapOptional = entity.MotorProtectionCapOptional,
                ModelFeatures = entity.ModelFeatures?
            .Select(f => new ProductModelFeatureDto
            {
                Id = f.Id,
                FeatureName = f.FeatureName,
                StandardValue = f.StandardValue,
                OptionalValue = f.OptionalValue,
                Order = f.Order
            })
            .OrderBy(f => f.Order)
            .ToList() ?? new()
            };
        }


        private static ProductModel MapToEntity(ProductModelDto dto)
        {
            return new ProductModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
                ProductSeriesId = dto.ProductSeriesId,
                ContentTitle = dto.ContentTitle,
                ContentDescription = dto.ContentDescription,
                AirFlow = dto.AirFlow,
                AirFlowUnit = dto.AirFlowUnit,
                TotalPressure = dto.TotalPressure,
                TotalPressureUnit = dto.TotalPressureUnit,
                Power = dto.Power,
                Voltage = dto.Voltage,
                Frequency = dto.Frequency,
                SpeedControl = dto.SpeedControl,
                Temperature = dto.Temperature,
                Image1Path = dto.Image1Path,
                Image2Path = dto.Image2Path,
                Image3Path = dto.Image3Path,
                Image4Path = dto.Image4Path,
                Image5Path = dto.Image5Path,
                DataSheetPath = dto.DataSheetPath,
                Model3DPath = dto.Model3DPath,
                TestDataPath = dto.TestDataPath,
                ScaleImagePath = dto.ScaleImagePath,
                IsActive = dto.IsActive,
                Order = dto.Order,
                BodyMaterialStandard = dto.BodyMaterialStandard,
                ImpellerMaterialStandard = dto.ImpellerMaterialStandard,
                CarryingBracketStandard = dto.CarryingBracketStandard,
                HeatResistanceStandard = dto.HeatResistanceStandard,
                ColdResistanceStandard = dto.ColdResistanceStandard,
                MotorProtectionCapStandard = dto.MotorProtectionCapStandard,
                BodyMaterialOptional = dto.BodyMaterialStandard,
                ImpellerMaterialOptional = dto.ImpellerMaterialStandard,
                CarryingBracketOptional = dto.CarryingBracketStandard,
                HeatResistanceOptional = dto.HeatResistanceStandard,
                ColdResistanceOptional = dto.ColdResistanceStandard,
                MotorProtectionCapOptional = dto.MotorProtectionCapStandard,
                ModelFeatures = dto.ModelFeatures
    .Select(f => new ProductModelFeature
    {
        FeatureName = f.FeatureName,
        StandardValue = f.StandardValue,
        OptionalValue = f.OptionalValue,
        Order = f.Order
    }).ToList(),

            };
        }
    }
}
