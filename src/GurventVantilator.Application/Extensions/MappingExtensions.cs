using GurventVantilator.Application.DTOs;
using GurventVantilator.Domain.Entities;

namespace GurventVantilator.Application.Extensions
{
    public static class MappingExtensions
    {
        public static ProductDto MapToDto(this Product entity)
        {
            return new ProductDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Code = entity.Code,
                Description = entity.Description,

                ProductModelId = entity.ProductModelId,
                ProductModelName = entity.ProductModel?.Name,
                ProductSeriesId = entity.ProductSeriesId,
                ProductSeriesName = entity.ProductSeries?.Name,

                ProductModelCode = entity.ProductModel?.Code,

                ProductTestName = entity.TestData
                    .OrderByDescending(x => x.CreatedAt) // istersen
                    .Select(x => x.TestName)
                    .FirstOrDefault(),

                UsageTypeIds = entity.UsageTypes.Select(u => u.Id).ToList(),
                UsageTypeNames = entity.UsageTypes.Select(u => u.Name).ToList(),
                WorkingConditionIds = entity.WorkingConditions.Select(w => w.Id).ToList(),
                WorkingConditionNames = entity.WorkingConditions.Select(w => w.Name).ToList(),

                ContentTitle = entity.ContentTitle,
                ContentDescription = entity.ContentDescription,

                AirFlow = entity.AirFlow,
                AirFlowUnit = entity.AirFlowUnit,
                TotalPressure = entity.TotalPressure,
                TotalPressureUnit = entity.TotalPressureUnit,
                Power = entity.Power,
                Voltage = entity.Voltage,
                Frequency = entity.Frequency,
                SpeedControl = entity.SpeedControl,
                Temperature = entity.Temperature,
                ContentFeatures = entity.ContentFeatures?
    .Select(x => new ProductContentFeatureDto
    {
        Key = x.Key,
        Value = x.Value
    })
    .ToList() ?? new List<ProductContentFeatureDto>(),

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
                UpdatedAt = entity.UpdatedAt
            };
        }

        public static Product MapToEntity(this ProductDto dto, Product? existing = null)
        {
            var entity = existing ?? new Product();

            entity.Name = dto.Name;
            entity.Code = dto.Code;
            entity.Description = dto.Description;

            entity.ProductModelId = dto.ProductModelId;
            entity.ProductSeriesId = dto.ProductSeriesId;

            entity.ContentTitle = dto.ContentTitle;
            entity.ContentDescription = dto.ContentDescription;

            entity.AirFlow = dto.AirFlow;
            entity.AirFlowUnit = dto.AirFlowUnit;
            entity.TotalPressure = dto.TotalPressure;
            entity.TotalPressureUnit = dto.TotalPressureUnit;
            entity.Power = dto.Power;
            entity.Voltage = dto.Voltage;
            entity.Frequency = dto.Frequency;
            entity.SpeedControl = dto.SpeedControl;
            entity.Temperature = dto.Temperature;
            entity.ContentFeatures = dto.ContentFeatures?
                .Select(x => new ProductContentFeature
                {
                    Key = x.Key,
                    Value = x.Value,
                    ProductId = entity.Id
                }).ToList() ?? new List<ProductContentFeature>();

            entity.Image1Path = dto.Image1Path;
            entity.Image2Path = dto.Image2Path;
            entity.Image3Path = dto.Image3Path;
            entity.Image4Path = dto.Image4Path;
            entity.Image5Path = dto.Image5Path;
            entity.DataSheetPath = dto.DataSheetPath;
            entity.Model3DPath = dto.Model3DPath;
            entity.TestDataPath = dto.TestDataPath;
            entity.ScaleImagePath = dto.ScaleImagePath;

            entity.IsActive = dto.IsActive;
            entity.Order = dto.Order;
            entity.UpdatedAt = DateTime.UtcNow;

            return entity;
        }
    }
}
