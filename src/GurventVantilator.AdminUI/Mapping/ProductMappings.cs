using GurventVantilator.Application.DTOs;
using GurventVantilator.AdminUI.Models.Product;
using System.Globalization;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class ProductMappings
    {
        #region CreateViewModel → DTO
        public static ProductDto ToDto(this ProductCreateViewModel vm,
            string? image1Path, string? image2Path, string? image3Path, string? image4Path, string? image5Path,
            string? dataSheetPath = null,
            string? model3DPath = null,
            string? testDataPath = null,
            string? scaleImagePath = null)
        {
            return new ProductDto
            {
                // Temel Bilgiler
                Name = vm.Name,
                Code = vm.Code,
                Description = vm.Description,
                CreatedAt = DateTime.UtcNow,

                // İlişkiler
                ProductModelId = vm.ProductModelId,
                ProductSeriesId = vm.ProductSeriesId,
                UsageTypeIds = vm.SelectedUsageTypeIds,
                WorkingConditionIds = vm.SelectedWorkingConditionIds,

                // Performans
                AirFlow = vm.AirFlow,
                AirFlowUnit = vm.AirFlowUnit,
                TotalPressure = vm.TotalPressure,
                TotalPressureUnit = vm.TotalPressureUnit,
                Power = vm.Power,
                Voltage = vm.Voltage,
                Frequency = vm.Frequency,
                SpeedControl = vm.SpeedControl,
                Temperature = vm.Temperature,

                // Dosyalar
                Image1Path = image1Path,
                Image2Path = image2Path,
                Image3Path = image3Path,
                Image4Path = image4Path,
                Image5Path = image5Path,
                DataSheetPath = dataSheetPath,
                Model3DPath = model3DPath,
                TestDataPath = testDataPath,
                ScaleImagePath = scaleImagePath,

                // İçerik Alanları
                ContentTitle = vm.ContentTitle,
                ContentDescription = vm.ContentDescription,
                ContentFeatures = vm.ContentFeatures.Select(f => new ProductContentFeatureDto
                {
                    Key = f.Key,
                    Value = f.Value
                }).ToList(),

                // Ortak
                IsActive = vm.IsActive,
                Order = vm.Order
            };
        }
        #endregion


        #region DTO → EditViewModel
        public static ProductEditViewModel ToEditViewModel(this ProductDto dto)
        {
            return new ProductEditViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,

                // İlişkiler
                ProductModelId = dto.ProductModelId,
                ProductSeriesId = dto.ProductSeriesId,
                SelectedUsageTypeIds = dto.UsageTypeIds,
                SelectedWorkingConditionIds = dto.WorkingConditionIds,

                // Performans
                AirFlow = dto.AirFlow?.ToString(CultureInfo.InvariantCulture),
                AirFlowUnit = dto.AirFlowUnit,
                TotalPressure = dto.TotalPressure?.ToString(CultureInfo.InvariantCulture),
                TotalPressureUnit = dto.TotalPressureUnit,
                Power = dto.Power,
                Voltage = dto.Voltage,
                Frequency = dto.Frequency?.ToString(CultureInfo.InvariantCulture),
                SpeedControl = dto.SpeedControl,
                Temperature = dto.Temperature,

                // Dosya Yolları
                Image1Path = dto.Image1Path,
                Image2Path = dto.Image2Path,
                Image3Path = dto.Image3Path,
                Image4Path = dto.Image4Path,
                Image5Path = dto.Image5Path,
                DataSheetPath = dto.DataSheetPath,
                Model3DPath = dto.Model3DPath,
                TestDataPath = dto.TestDataPath,
                ScaleImagePath = dto.ScaleImagePath,

                // İçerik
                ContentTitle = dto.ContentTitle,
                ContentDescription = dto.ContentDescription,
                ContentFeatures = dto.ContentFeatures.Select(f => new ProductContentFeatureViewModel
                {
                    Key = f.Key,
                    Value = f.Value
                }).ToList(),

                // Ortak
                IsActive = dto.IsActive,
                Order = dto.Order ?? 0
            };
        }
        #endregion


        #region EditViewModel → DTO
        public static ProductDto ToDto(this ProductEditViewModel vm,
            string? image1Path, string? image2Path, string? image3Path, string? image4Path, string? image5Path,
            string? dataSheetPath,
            string? model3DPath,
            string? testDataPath,
            string? scaleImagePath,
            DateTime createdAt)
        {
            return new ProductDto
            {
                Id = vm.Id,
                Name = vm.Name,
                Code = vm.Code,
                Description = vm.Description,
                CreatedAt = createdAt,
                UpdatedAt = DateTime.UtcNow,

                // İlişkiler
                ProductModelId = vm.ProductModelId,
                ProductSeriesId = vm.ProductSeriesId,
                UsageTypeIds = vm.SelectedUsageTypeIds,
                WorkingConditionIds = vm.SelectedWorkingConditionIds,

                // Performans
                AirFlow = ParseDouble(vm.AirFlow),
                AirFlowUnit = vm.AirFlowUnit,
                TotalPressure = ParseDouble(vm.TotalPressure),
                TotalPressureUnit = vm.TotalPressureUnit,
                Power = vm.Power,
                Voltage = vm.Voltage,
                Frequency = ParseDouble(vm.Frequency),
                SpeedControl = vm.SpeedControl,
                Temperature = vm.Temperature,

                // Dosyalar
                Image1Path = image1Path,
                Image2Path = image2Path,
                Image3Path = image3Path,
                Image4Path = image4Path,
                Image5Path = image5Path,
                DataSheetPath = dataSheetPath,
                Model3DPath = model3DPath,
                TestDataPath = testDataPath,
                ScaleImagePath = scaleImagePath,

                // İçerik
                ContentTitle = vm.ContentTitle,
                ContentDescription = vm.ContentDescription,
                ContentFeatures = vm.ContentFeatures.Select(f => new ProductContentFeatureDto
                {
                    Key = f.Key,
                    Value = f.Value
                }).ToList(),

                // Ortak
                IsActive = vm.IsActive,
                Order = vm.Order
            };
        }
        #endregion


        #region Helper
        private static double? ParseDouble(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            if (double.TryParse(value.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
                return result;

            return null;
        }
        #endregion
    }
}
