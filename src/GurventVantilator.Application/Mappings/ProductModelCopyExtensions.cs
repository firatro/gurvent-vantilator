using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Mappings
{
    public static class ProductModelCopyExtensions
    {
        public static ProductModelDto ToCopyDto(this ProductModelDto source)
        {
            return new ProductModelDto
            {
                // ==========================
                // TEMEL
                // ==========================
                Name = source.Name + " (Kopya)",
                Code = source.Code + "-COPY",
                Description = source.Description,

                ProductSeriesId = source.ProductSeriesId,

                // ==========================
                // MANY TO MANY
                // ==========================
                UsageTypeIds = source.UsageTypeIds?.ToList() ?? new(),
                WorkingConditionIds = source.WorkingConditionIds?.ToList() ?? new(),

                // ==========================
                // CONTENT
                // ==========================
                ContentTitle = source.ContentTitle,
                ContentDescription = source.ContentDescription,

                ContentFeatures = source.ContentFeatures?
                    .Select(f => new ProductContentFeatureDto
                    {
                        // ❌ Id
                        // ❌ ProductId
                        // ❌ ProductModelId
                        Key = f.Key,
                        Value = f.Value,
                        Order = f.Order
                    }).ToList() ?? new(),

                // ==========================
                // TECHNICAL
                // ==========================
                AirFlow = source.AirFlow,
                AirFlowUnit = source.AirFlowUnit,
                TotalPressure = source.TotalPressure,
                TotalPressureUnit = source.TotalPressureUnit,
                Power = source.Power,
                Voltage = source.Voltage,
                Frequency = source.Frequency,
                SpeedControl = source.SpeedControl,
                Temperature = source.Temperature,

                // ==========================
                // FILE PATHS
                // ==========================
                Image1Path = source.Image1Path,
                Image2Path = source.Image2Path,
                Image3Path = source.Image3Path,
                Image4Path = source.Image4Path,
                Image5Path = source.Image5Path,

                DataSheetPath = source.DataSheetPath,
                Model3DPath = source.Model3DPath,
                TestDataPath = source.TestDataPath,
                ScaleImagePath = source.ScaleImagePath,

                // ==========================
                // STANDARDS
                // ==========================
                BodyMaterialStandard = source.BodyMaterialStandard,
                ImpellerMaterialStandard = source.ImpellerMaterialStandard,
                CarryingBracketStandard = source.CarryingBracketStandard,
                HeatResistanceStandard = source.HeatResistanceStandard,
                ColdResistanceStandard = source.ColdResistanceStandard,
                MotorProtectionCapStandard = source.MotorProtectionCapStandard,

                // ==========================
                // OPTIONAL
                // ==========================
                BodyMaterialOptional = source.BodyMaterialOptional,
                ImpellerMaterialOptional = source.ImpellerMaterialOptional,
                CarryingBracketOptional = source.CarryingBracketOptional,
                HeatResistanceOptional = source.HeatResistanceOptional,
                ColdResistanceOptional = source.ColdResistanceOptional,
                MotorProtectionCapOptional = source.MotorProtectionCapOptional,

                // ==========================
                // MODEL FEATURES (GÜNCELLENDİ ✅)
                // ==========================
                ModelFeatures = source.ModelFeatures?
                    .Select(f => new ProductModelFeatureDto
                    {
                        // ❌ Id
                        // ❌ ProductModelId
                        FeatureName = f.FeatureName,
                        StandardValue = f.StandardValue,
                        OptionalValue = f.OptionalValue,
                        Order = f.Order
                    }).ToList() ?? new(),

                // ==========================
                // STATE
                // ==========================
                IsActive = false,
                Order = source.Order
            };
        }
    }
}
