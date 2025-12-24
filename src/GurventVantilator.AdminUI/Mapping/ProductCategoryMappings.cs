// using GurventVantilator.Application.DTOs;
// using GurventVantilator.AdminUI.Models.ProductCategory;

// namespace GurventVantilator.AdminUI.Mappings
// {
//     public static class ProductCategoryMappings
//     {
//         #region CreateViewModel → DTO
//         public static ProductCategoryDto ToDto(this ProductCategoryCreateViewModel vm, string? imagePath)
//         {
//             return new ProductCategoryDto
//             {
//                 Name = vm.Name,
//                 Description = vm.Description,
//                 ImagePath = imagePath,
//                 IsActive = vm.IsActive,
//                 Order = vm.Order ?? 0
//             };
//         }
//         #endregion

//         #region DTO → EditViewModel
//         public static ProductCategoryEditViewModel ToEditViewModel(this ProductCategoryDto dto)
//         {
//             return new ProductCategoryEditViewModel
//             {
//                 Id = dto.Id,
//                 Name = dto.Name,
//                 Description = dto.Description,
//                 ImagePath = dto.ImagePath,
//                 IsActive = dto.IsActive,
//                 Order = dto.Order
//             };
//         }
//         #endregion

//         #region EditViewModel → DTO
//         public static ProductCategoryDto ToDto(this ProductCategoryEditViewModel vm, string? imagePath)
//         {
//             return new ProductCategoryDto
//             {
//                 Id = vm.Id,
//                 Name = vm.Name,
//                 Description = vm.Description,
//                 ImagePath = imagePath ?? vm.ImagePath, // yeni yüklenmediyse eskiyi koru
//                 IsActive = vm.IsActive,
//                 Order = vm.Order ?? 0
//             };
//         }
//         #endregion
//     }
// }
