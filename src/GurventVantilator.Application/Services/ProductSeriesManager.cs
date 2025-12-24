using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class ProductSeriesManager : IProductSeriesService
    {
        private readonly IProductSeriesRepository _seriesRepository;
        private readonly ILogger<ProductSeriesManager> _logger;

        public ProductSeriesManager(IProductSeriesRepository seriesRepository, ILogger<ProductSeriesManager> logger)
        {
            _seriesRepository = seriesRepository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<ProductSeriesDto>>> GetAllAsync()
        {
            try
            {
                var list = (await _seriesRepository.GetAllAsync())
                            .Where(x => x.IsActive)
                            .ToList();
                var dtos = list.Where(x => x.IsActive).Select(MapToDto);
                return Result<IEnumerable<ProductSeriesDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Seri listesi alınırken hata oluştu.");
                return Result<IEnumerable<ProductSeriesDto>>.Fail("Seri listesi alınamadı.");
            }
        }

        public async Task<Result<ProductSeriesDto>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _seriesRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<ProductSeriesDto>.Fail("Seri bulunamadı.");

                return Result<ProductSeriesDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Seri getirilemedi. Id={Id}", id);
                return Result<ProductSeriesDto>.Fail("Seri getirilemedi.");
            }
        }

        public async Task<Result<List<ProductSeriesDto>>> GetByFilterAsync(int? usageTypeId, int? workingConditionId)
        {
            try
            {
                // Repo'dan veri çek
                var list = (await _seriesRepository.GetByUsageOrWorkingAsync(usageTypeId, workingConditionId))
                            .Where(x => x.IsActive)
                            .ToList();

                if (list == null || !list.Any())
                    return Result<List<ProductSeriesDto>>.Fail("Herhangi bir ürün serisi bulunamadı.");

                // DTO map
                var data = list.Select(x => new ProductSeriesDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImagePath = x.ImagePath
                }).ToList();

                return Result<List<ProductSeriesDto>>.Ok(data);
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                return Result<List<ProductSeriesDto>>.Fail("Seri filtreleme sırasında bir hata oluştu: " + ex.Message);
            }
        }


        public async Task<Result<ProductSeriesDto>> AddAsync(ProductSeriesDto dto)
        {
            try
            {
                var entity = MapToEntity(dto);
                await _seriesRepository.AddAsync(entity);
                return Result<ProductSeriesDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Seri eklenemedi: {Name}", dto.Name);
                return Result<ProductSeriesDto>.Fail("Seri eklenemedi.");
            }
        }

        public async Task<Result<ProductSeriesDto>> UpdateAsync(ProductSeriesDto dto)
        {
            try
            {
                var existing = await _seriesRepository.GetByIdAsync(dto.Id);
                if (existing == null)
                    return Result<ProductSeriesDto>.Fail("Seri bulunamadı.");

                existing.Name = dto.Name;
                existing.Description = dto.Description;
                existing.ImagePath = dto.ImagePath;
                existing.IsActive = dto.IsActive;

                await _seriesRepository.UpdateAsync(existing);
                return Result<ProductSeriesDto>.Ok(MapToDto(existing));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Seri güncellenemedi. Id={Id}", dto.Id);
                return Result<ProductSeriesDto>.Fail("Seri güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _seriesRepository.GetByIdAsync(id);
                if (existing == null)
                    return Result<bool>.Fail("Seri bulunamadı.");

                await _seriesRepository.DeleteAsync(existing);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Seri silinemedi. Id={Id}", id);
                return Result<bool>.Fail("Seri silinemedi.");
            }
        }

        public async Task<Result<bool>> ToggleStatusAsync(int id)
        {
            var entity = await _seriesRepository.GetByIdAsync(id);
            if (entity == null)
                return Result<bool>.Fail("Seri bulunamadı.");

            entity.IsActive = !entity.IsActive;

            await _seriesRepository.UpdateAsync(entity);

            return Result<bool>.Ok(entity.IsActive);
        }


        private static ProductSeriesDto MapToDto(ProductSeries entity)
        {
            return new ProductSeriesDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ImagePath = entity.ImagePath,
                IsActive = entity.IsActive,
                Models = entity.Models?.Select(m => new ProductModelDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Code = m.Code,
                    Description = m.Description,

                    ProductSeriesId = m.ProductSeriesId,
                    ProductSeriesName = entity.Name,

                    UsageTypeIds = m.UsageTypes?.Select(u => u.Id).ToList() ?? new(),
                    UsageTypeNames = m.UsageTypes?.Select(u => u.Name).ToList(),

                    WorkingConditionIds = m.WorkingConditions?.Select(w => w.Id).ToList() ?? new(),
                    WorkingConditionNames = m.WorkingConditions?.Select(w => w.Name).ToList(),

                    ContentTitle = m.ContentTitle,
                    ContentDescription = m.ContentDescription,

                    ContentFeatures = m.ContentFeatures?.Select(cf => new ProductContentFeatureDto
                    {
                        Id = cf.Id,
                        ProductId = cf.ProductId,
                        Key = cf.Key,
                        Value = cf.Value,
                        Order = cf.Order
                    }).ToList() ?? new(),

                    AirFlow = m.AirFlow,
                    AirFlowUnit = m.AirFlowUnit,
                    TotalPressure = m.TotalPressure,
                    TotalPressureUnit = m.TotalPressureUnit,
                    Power = m.Power,
                    Voltage = m.Voltage,
                    Frequency = m.Frequency,
                    SpeedControl = m.SpeedControl,
                    Temperature = m.Temperature,

                    Image1Path = m.Image1Path,
                    Image2Path = m.Image2Path,
                    Image3Path = m.Image3Path,
                    Image4Path = m.Image4Path,
                    Image5Path = m.Image5Path,

                    DataSheetPath = m.DataSheetPath,
                    Model3DPath = m.Model3DPath,
                    TestDataPath = m.TestDataPath,
                    ScaleImagePath = m.ScaleImagePath,

                    IsActive = m.IsActive,
                    Order = m.Order,
                    CreatedAt = m.CreatedAt,
                    UpdatedAt = m.UpdatedAt

                }).ToList()
            };
        }



        private static ProductSeries MapToEntity(ProductSeriesDto dto)
        {
            return new ProductSeries
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                ImagePath = dto.ImagePath,
                IsActive = dto.IsActive         // 🔥 EKLENECEK
            };
        }

        public async Task<Result<bool>> CloneAsync(int id)
        {
            var existing = await _seriesRepository.GetByIdAsync(id);
            if (existing == null)
                return Result<bool>.Fail("Seri bulunamadı.");

            // Yeni entity oluştur
            var clone = new ProductSeries
            {
                Name = existing.Name,
                Description = existing.Description,
                ImagePath = existing.ImagePath,
                IsActive = existing.IsActive,
            };

            // Kaydet
            await _seriesRepository.AddAsync(clone);

            return Result<bool>.Ok(true);
        }


    }
}
