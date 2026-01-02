using GurventVantilator.AdminUI.Models.ProductAccessory;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.AdminUI.Mappings
{
    public static class ProductAccessoryMappings
    {
        // ===============================
        // CREATE VM → DTO
        // ===============================
        public static ProductAccessoryDto ToDto(
            this ProductAccessoryCreateViewModel vm,
            string? imagePath)
        {
            return new ProductAccessoryDto
            {
                ProductId = vm.ProductId,
                AccessoryName = vm.AccessoryName,
                Type = vm.Type,
                ImagePath = imagePath,
                ArticleNumber = vm.ArticleNumber,
            };
        }

        // ===============================
        // EDIT VM → DTO
        // ===============================
        public static ProductAccessoryDto ToDto(
            this ProductAccessoryEditViewModel vm,
            string? imagePath)
        {
            return new ProductAccessoryDto
            {
                Id = vm.Id,
                ProductId = vm.ProductId,
                AccessoryName = vm.AccessoryName,
                Type = vm.Type,
                ArticleNumber = vm.ArticleNumber,
                ImagePath = imagePath
            };
        }

        // ===============================
        // DTO → EDIT VM
        // ===============================
        public static ProductAccessoryEditViewModel ToEditViewModel(
            this ProductAccessoryDto dto)
        {
            return new ProductAccessoryEditViewModel
            {
                Id = dto.Id,
                ProductId = dto.ProductId,
                AccessoryName = dto.AccessoryName,
                Type = dto.Type,
                ArticleNumber = dto.ArticleNumber,
                ImagePath = dto.ImagePath
            };
        }
    }
}
