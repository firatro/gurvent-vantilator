using GurventVantilator.Application.DTOs;
using GurventVantilator.AdminUI.Models.Product;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class ProductMappings
    {
        #region CreateViewModel → DTO
        public static ProductDto ToDto(this ProductCreateViewModel vm,
                                       string? imagePath,
                                       string? dataSheetPath = null,
                                       string? model3DPath = null)
        {
            return new ProductDto
            {
                Name = vm.Name,
                Code = vm.Code,
                Description = vm.Description,
                CreatedAt = DateTime.Now,

                Diameter = vm.Diameter,
                AirFlowMin = vm.AirFlowMin,
                AirFlowMax = vm.AirFlowMax,
                PressureMin = vm.PressureMin,
                PressureMax = vm.PressureMax,
                Power = vm.Power,
                Voltage = vm.Voltage,
                Frequency = vm.Frequency,
                Speed = vm.Speed,
                NoiseLevel = vm.NoiseLevel,

                ImagePath = imagePath,
                DataSheetPath = dataSheetPath,
                Model3DPath = model3DPath,

                ProductCategoryId = vm.ProductCategoryId,
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
                Order = dto.Order ?? 0
            };
        }
        #endregion

        #region EditViewModel → DTO
        public static ProductDto ToDto(this ProductEditViewModel vm,
                                       string? imagePath,
                                       string? dataSheetPath,
                                       string? model3DPath, DateTime createdAt)
        {
            return new ProductDto
            {
                Id = vm.Id,
                Name = vm.Name,
                Code = vm.Code,
                Description = vm.Description,
                CreatedAt = createdAt,

                Diameter = vm.Diameter,
                AirFlowMin = vm.AirFlowMin,
                AirFlowMax = vm.AirFlowMax,
                PressureMin = vm.PressureMin,
                PressureMax = vm.PressureMax,
                Power = vm.Power,
                Voltage = vm.Voltage,
                Frequency = vm.Frequency,
                Speed = vm.Speed,
                NoiseLevel = vm.NoiseLevel,

                ImagePath = imagePath,
                DataSheetPath = dataSheetPath,
                Model3DPath = model3DPath,

                ProductCategoryId = vm.ProductCategoryId,
                IsActive = vm.IsActive,
                Order = vm.Order ?? 0
            };
        }
        #endregion
    }
}
