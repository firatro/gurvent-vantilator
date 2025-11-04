using GurventVantilator.Application.DTOs;
using GurventVantilator.AdminUI.Models.Product;
using System.Globalization;
using GurventVantilator.AdminUI.Models.ProductContentFeature;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class ProductMappings
    {
        #region CreateViewModel → DTO
        public static ProductDto ToDto(this ProductCreateViewModel vm,
                                       string? image1Path, string? image2Path, string? image3Path, string? image4Path, string? image5Path,
                                       string? dataSheetPath = null,
                                       string? model3DPath = null, string? testDataPath = null, string? scaleImagePath = null)
        {
            return new ProductDto
            {
                Name = vm.Name,
                Code = vm.Code,
                Description = vm.Description,
                CreatedAt = DateTime.Now,

                // Boyut
                Diameter = ParseDouble(vm.Diameter),
                DiameterUnit = vm.DiameterUnit,

                // Hava debisi
                AirFlow = ParseDouble(vm.AirFlow),
                AirFlowUnit = vm.AirFlowUnit,

                // Basınç
                Pressure = ParseDouble(vm.Pressure),
                PressureUnit = vm.PressureUnit,

                // Güç
                Power = ParseDouble(vm.Power),
                PowerUnit = vm.PowerUnit,

                // Elektriksel
                Voltage = ParseDouble(vm.Voltage),
                Frequency = ParseDouble(vm.Frequency),

                // Performans
                Speed = ParseDouble(vm.Speed),
                SpeedUnit = vm.SpeedUnit,
                NoiseLevel = ParseDouble(vm.NoiseLevel),
                NoiseLevelUnit = vm.NoiseLevelUnit,
                SpeedControl = vm.SpeedControl,

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

                ProductCategoryId = vm.ProductCategoryId,
                IsActive = vm.IsActive,
                Order = vm.Order,

                // Uygulama alanı ID'leri
                SelectedApplicationIds = vm.SelectedApplicationIds ?? new List<int>(),
                ContentTitle = vm.ContentTitle,
                ContentDescription = vm.ContentDescription,
                ContentFeatures = vm.ContentFeatures.Select(f => new ProductContentFeatureDto
                {
                    Key = f.Key,
                    Value = f.Value
                }).ToList(),

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

                // Boyut
                Diameter = dto.Diameter?.ToString(CultureInfo.InvariantCulture),
                DiameterUnit = dto.DiameterUnit,

                // Hava debisi
                AirFlow = dto.AirFlow?.ToString(CultureInfo.InvariantCulture),
                AirFlowUnit = dto.AirFlowUnit,

                // Basınç
                Pressure = dto.Pressure?.ToString(CultureInfo.InvariantCulture),
                PressureUnit = dto.PressureUnit,

                // Güç
                Power = dto.Power?.ToString(CultureInfo.InvariantCulture),
                PowerUnit = dto.PowerUnit,

                // Elektriksel
                Voltage = dto.Voltage?.ToString(CultureInfo.InvariantCulture),
                Frequency = dto.Frequency?.ToString(CultureInfo.InvariantCulture),

                // Performans
                Speed = dto.Speed?.ToString(CultureInfo.InvariantCulture),
                NoiseLevel = dto.NoiseLevel?.ToString(CultureInfo.InvariantCulture),
                NoiseLevelUnit = dto.NoiseLevelUnit,
                SpeedControl = dto.SpeedControl,
                SpeedUnit = dto.SpeedUnit,

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

                ProductCategoryId = dto.ProductCategoryId,
                IsActive = dto.IsActive,
                Order = dto.Order ?? 0,

                // Seçili uygulama alanları
                SelectedApplicationIds = dto.SelectedApplicationIds ?? new List<int>(),
                ContentTitle = dto.ContentTitle,
                ContentDescription = dto.ContentDescription,
                ContentFeatures = dto.ContentFeatures.Select(f => new ProductContentFeatureViewModel
                {
                    Key = f.Key,
                    Value = f.Value
                }).ToList(),

            };
        }
        #endregion

        #region EditViewModel → DTO
        public static ProductDto ToDto(this ProductEditViewModel vm,
                                       string? image1Path, string? image2Path, string? image3Path, string? image4Path, string? image5Path,
                                       string? dataSheetPath,
                                       string? model3DPath,
                                       string? testDataPath, string? scaleImagePath,
                                       DateTime createdAt)
        {
            return new ProductDto
            {
                Id = vm.Id,
                Name = vm.Name,
                Code = vm.Code,
                Description = vm.Description,
                CreatedAt = createdAt,

                // Boyut
                Diameter = ParseDouble(vm.Diameter),
                DiameterUnit = vm.DiameterUnit,

                // Hava debisi
                AirFlow = ParseDouble(vm.AirFlow),
                AirFlowUnit = vm.AirFlowUnit,

                // Basınç
                Pressure = ParseDouble(vm.Pressure),
                PressureUnit = vm.PressureUnit,

                // Güç
                Power = ParseDouble(vm.Power),
                PowerUnit = vm.PowerUnit,

                // Elektriksel
                Voltage = ParseDouble(vm.Voltage),
                Frequency = ParseDouble(vm.Frequency),

                // Performans
                Speed = ParseDouble(vm.Speed),
                SpeedUnit = vm.SpeedUnit,
                NoiseLevel = ParseDouble(vm.NoiseLevel),
                NoiseLevelUnit = vm.NoiseLevelUnit,
                ContentDescription = vm.ContentDescription,
                ContentTitle = vm.ContentTitle,
                SpeedControl = vm.SpeedControl,

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

                ProductCategoryId = vm.ProductCategoryId,
                IsActive = vm.IsActive,
                Order = vm.Order ?? 0,

                SelectedApplicationIds = vm.SelectedApplicationIds ?? new List<int>()
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
