using GurventVantilator.AdminUI.Models.ProductModel;
using GurventVantilator.Application.DTOs;
using System.Linq;

public static class ProductModelMappings
{
    // =====================================================
    // CREATE → DTO
    // =====================================================
    public static ProductModelDto ToDto(
        this ProductModelCreateViewModel vm,
        string? image1Path,
        string? image2Path = null,
        string? image3Path = null,
        string? image4Path = null,
        string? image5Path = null,
        string? dataSheetPath = null,
        string? model3DPath = null,
        string? testDataPath = null,
        string? scaleImagePath = null)
    {
        return new ProductModelDto
        {
            Id = vm.Id,
            Name = vm.Name,
            Code = vm.Code,
            Description = vm.Description,

            ProductSeriesId = vm.ProductSeriesId,

            UsageTypeIds = vm.SelectedUsageTypeIds?.ToList() ?? new(),
            WorkingConditionIds = vm.SelectedWorkingConditionIds?.ToList() ?? new(),

            ContentTitle = vm.ContentTitle,
            ContentDescription = vm.ContentDescription,

            ContentFeatures = vm.ContentFeatures?.ToList() ?? new(),

            AirFlow = vm.AirFlow,
            AirFlowUnit = vm.AirFlowUnit,
            TotalPressure = vm.TotalPressure,
            TotalPressureUnit = vm.TotalPressureUnit,
            Power = vm.Power,
            Voltage = vm.Voltage,
            Frequency = vm.Frequency,
            SpeedControl = vm.SpeedControl,
            Temperature = vm.Temperature,

            Image1Path = image1Path,
            Image2Path = image2Path,
            Image3Path = image3Path,
            Image4Path = image4Path,
            Image5Path = image5Path,

            DataSheetPath = dataSheetPath,
            Model3DPath = model3DPath,
            TestDataPath = testDataPath,
            ScaleImagePath = scaleImagePath,

            Order = vm.Order,
            IsActive = vm.IsActive,

            // CREATE sırasında doküman yok
            Documents = new List<ProductModelDocumentDto>(),
            BodyMaterialStandard = vm.BodyMaterialStandard,
            ImpellerMaterialStandard = vm.ImpellerMaterialStandard,
            CarryingBracketStandard = vm.CarryingBracketStandard,
            HeatResistanceStandard = vm.HeatResistanceStandard,
            ColdResistanceStandard = vm.ColdResistanceStandard,
            MotorProtectionCapStandard = vm.MotorProtectionCapStandard,

            BodyMaterialOptional = vm.BodyMaterialOptional,
            ImpellerMaterialOptional = vm.ImpellerMaterialOptional,
            CarryingBracketOptional = vm.CarryingBracketOptional,
            HeatResistanceOptional = vm.HeatResistanceOptional,
            ColdResistanceOptional = vm.ColdResistanceOptional,
            MotorProtectionCapOptional = vm.MotorProtectionCapOptional,
            ModelFeatures = vm.ModelFeatures?
    .Select(f => new ProductModelFeatureDto
    {
        FeatureName = f.FeatureName,
        StandardValue = f.StandardValue,
        OptionalValue = f.OptionalValue,
        Order = f.Order
    }).ToList() ?? new()

        };
    }

    // =====================================================
    // DTO → EditViewModel (EDIT GET)
    // =====================================================
    public static ProductModelEditViewModel ToEditVm(this ProductModelDto dto)
    {
        return new ProductModelEditViewModel
        {
            Id = dto.Id,
            Name = dto.Name,
            Code = dto.Code,
            Description = dto.Description,

            ProductSeriesId = dto.ProductSeriesId,

            SelectedUsageTypeIds = dto.UsageTypeIds ?? new(),
            SelectedWorkingConditionIds = dto.WorkingConditionIds ?? new(),

            ContentTitle = dto.ContentTitle,
            ContentDescription = dto.ContentDescription,

            ContentFeatures = dto.ContentFeatures?
                .Select(cf => new ProductContentFeatureViewModel
                {
                    Id = cf.Id,
                    Key = cf.Key,
                    Value = cf.Value,
                    Order = cf.Order
                }).ToList() ?? new(),

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

            Order = dto.Order,
            IsActive = dto.IsActive,

            // 🔥 DOKÜMANLAR BURADA EKLENMELİ
            ExistingDocuments = dto.Documents?
                .Select(d => new ProductModelDocumentDto
                {
                    Id = d.Id,
                    ProductModelId = d.ProductModelId,
                    Title = d.Title,
                    FilePath = d.FilePath
                }).ToList() ?? new(),
            BodyMaterialStandard = dto.BodyMaterialStandard,
            ImpellerMaterialStandard = dto.ImpellerMaterialStandard,
            CarryingBracketStandard = dto.CarryingBracketStandard,
            HeatResistanceStandard = dto.HeatResistanceStandard,
            ColdResistanceStandard = dto.ColdResistanceStandard,
            MotorProtectionCapStandard = dto.MotorProtectionCapStandard,
            BodyMaterialOptional = dto.BodyMaterialOptional,
            ImpellerMaterialOptional = dto.ImpellerMaterialOptional,
            CarryingBracketOptional = dto.CarryingBracketOptional,
            HeatResistanceOptional = dto.HeatResistanceOptional,
            ColdResistanceOptional = dto.ColdResistanceOptional,
            MotorProtectionCapOptional = dto.MotorProtectionCapOptional,
            ModelFeatures = dto.ModelFeatures?
    .Select(f => new ProductModelFeatureViewModel
    {
        Id = f.Id,
        FeatureName = f.FeatureName,
        StandardValue = f.StandardValue,
        OptionalValue = f.OptionalValue,
        Order = f.Order
    }).ToList() ?? new()


        };
    }

    // =====================================================
    // EDIT → DTO (UPDATE)
    // =====================================================
    public static ProductModelDto ToUpdateDto(
        this ProductModelEditViewModel vm,
        ProductModelDto oldDto,
        string? image1Path = null,
        string? image2Path = null,
        string? image3Path = null,
        string? image4Path = null,
        string? image5Path = null,
        string? dataSheetPath = null,
        string? model3DPath = null,
        string? testDataPath = null,
        string? scaleImagePath = null)
    {
        return new ProductModelDto
        {
            Id = vm.Id,
            Name = vm.Name,
            Code = vm.Code,
            Description = vm.Description,

            ProductSeriesId = vm.ProductSeriesId,

            UsageTypeIds = vm.SelectedUsageTypeIds?.ToList() ?? new(),
            WorkingConditionIds = vm.SelectedWorkingConditionIds?.ToList() ?? new(),

            ContentTitle = vm.ContentTitle,
            ContentDescription = vm.ContentDescription,

            ContentFeatures = vm.ContentFeatures?
                .Select(cf => cf.ToDto())
                .ToList() ?? new(),

            AirFlow = vm.AirFlow,
            AirFlowUnit = vm.AirFlowUnit,
            TotalPressure = vm.TotalPressure,
            TotalPressureUnit = vm.TotalPressureUnit,
            Power = vm.Power,
            Voltage = vm.Voltage,
            Frequency = vm.Frequency,
            SpeedControl = vm.SpeedControl,
            Temperature = vm.Temperature,

            Image1Path = image1Path ?? oldDto.Image1Path,
            Image2Path = image2Path ?? oldDto.Image2Path,
            Image3Path = image3Path ?? oldDto.Image3Path,
            Image4Path = image4Path ?? oldDto.Image4Path,
            Image5Path = image5Path ?? oldDto.Image5Path,

            DataSheetPath = dataSheetPath ?? oldDto.DataSheetPath,
            Model3DPath = model3DPath ?? oldDto.Model3DPath,
            TestDataPath = testDataPath ?? oldDto.TestDataPath,
            ScaleImagePath = scaleImagePath ?? oldDto.ScaleImagePath,

            CreatedAt = oldDto.CreatedAt,
            UpdatedAt = DateTime.Now,

            Order = vm.Order,
            IsActive = vm.IsActive,

            // 🔥 VAR OLAN DOKÜMANLARI KORU
            Documents = oldDto.Documents?.ToList() ?? new(),
            BodyMaterialStandard = vm.BodyMaterialStandard,
            ImpellerMaterialStandard = vm.ImpellerMaterialStandard,
            CarryingBracketStandard = vm.CarryingBracketStandard,
            HeatResistanceStandard = vm.HeatResistanceStandard,
            ColdResistanceStandard = vm.ColdResistanceStandard,
            MotorProtectionCapStandard = vm.MotorProtectionCapStandard,
            BodyMaterialOptional = vm.BodyMaterialOptional,
            ImpellerMaterialOptional = vm.ImpellerMaterialOptional,
            CarryingBracketOptional = vm.CarryingBracketOptional,
            HeatResistanceOptional = vm.HeatResistanceOptional,
            ColdResistanceOptional = vm.ColdResistanceOptional,
            MotorProtectionCapOptional = vm.MotorProtectionCapOptional,

            ModelFeatures = vm.ModelFeatures?
                .Select(f => new ProductModelFeatureDto
                {
                    Id = f.Id,
                    FeatureName = f.FeatureName,
                    StandardValue = f.StandardValue,
                    OptionalValue = f.OptionalValue,
                    Order = f.Order
                }).ToList() ?? new()


        };
    }
}
