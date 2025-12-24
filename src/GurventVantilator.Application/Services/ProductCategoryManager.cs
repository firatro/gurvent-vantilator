// using GurventVantilator.Application.Common;
// using GurventVantilator.Application.DTOs;
// using GurventVantilator.Application.Interfaces;
// using GurventVantilator.Application.Interfaces.Services;
// using GurventVantilator.Domain.Entities;
// using GurventVantilator.Domain.Interfaces.Repositories;
// using Microsoft.Extensions.Logging;

// namespace GurventVantilator.Application.Services
// {
//     public class ProductCategoryManager : IProductCategoryService
//     {
//         private readonly IProductCategoryRepository _productCategoryRepository;
//         private readonly ILogger<ProductCategoryManager> _logger;

//         public ProductCategoryManager(IProductCategoryRepository productCategoryRepository, ILogger<ProductCategoryManager> logger)
//         {
//             _productCategoryRepository = productCategoryRepository;
//             _logger = logger;
//         }

//         public async Task<Result<List<ProductCategoryDto>>> GetAllAsync(bool onlyTopLevel = false)
//         {
//             try
//             {
//                 // 🔹 Tüm kategorileri repository’den çek
//                 var categories = await _productCategoryRepository.GetAllAsync();

//                 if (categories == null || !categories.Any())
//                     return Result<List<ProductCategoryDto>>.Fail("Kategori bulunamadı.");

//                 // 🔹 İlişkileri DTO’ya dönüştür
//                 var categoryDtos = categories
//                     .Where(c => !onlyTopLevel || c.ParentCategoryId == null)
//                     .Select(MapToDto)
//                     .ToList();

//                 return Result<List<ProductCategoryDto>>.Ok(categoryDtos);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError(ex, "Kategoriler yüklenirken hata oluştu.");
//                 return Result<List<ProductCategoryDto>>.Fail("Kategoriler getirilemedi.");
//             }
//         }


//         public async Task<Result<ProductCategoryDto>> GetByIdAsync(int id)
//         {
//             try
//             {
//                 var productCategory = await _productCategoryRepository.GetByIdAsync(id);
//                 if (productCategory == null)
//                     return Result<ProductCategoryDto>.Fail("Kategori bulunamadı.");

//                 return Result<ProductCategoryDto>.Ok(MapToDto(productCategory));
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError(ex, "Kategori getirilirken hata oluştu. Id={Id}", id);
//                 return Result<ProductCategoryDto>.Fail("Kategori getirilemedi.");
//             }
//         }

//         public async Task<Result<ProductCategoryDto>> AddAsync(ProductCategoryDto dto)
//         {
//             try
//             {
//                 if (string.IsNullOrWhiteSpace(dto.Name))
//                     return Result<ProductCategoryDto>.Fail("Kategori adı boş olamaz.");

//                 var entity = MapToEntity(dto);
//                 await _productCategoryRepository.AddAsync(entity);

//                 return Result<ProductCategoryDto>.Ok(MapToDto(entity));
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError(ex, "Kategori eklenirken hata oluştu.");
//                 return Result<ProductCategoryDto>.Fail("Kategori eklenemedi.");
//             }
//         }

//         public async Task<Result<ProductCategoryDto>> UpdateAsync(ProductCategoryDto dto)
//         {
//             try
//             {
//                 // Kendini üst kategori olarak seçmiş mi?
//                 if (dto.ParentCategoryId == dto.Id)
//                     return Result<ProductCategoryDto>.Fail("Bir kategori kendi üst kategorisi olamaz.");

//                 // Alt kategorilerinden biri üst kategori olarak seçilmiş mi?
//                 var allCategories = await _productCategoryRepository.GetAllAsync(true);
//                 var allSubIds = GetAllSubCategoryIds(allCategories, dto.Id);
//                 if (allSubIds.Contains(dto.ParentCategoryId ?? 0))
//                     return Result<ProductCategoryDto>.Fail("Bir kategori kendi alt kategorisini üst kategori olarak seçemez.");

//                 // Güncelleme işlemi
//                 var entity = MapToEntity(dto);
//                 entity.UpdatedAt = DateTime.UtcNow;

//                 await _productCategoryRepository.UpdateAsync(entity);

//                 return Result<ProductCategoryDto>.Ok(MapToDto(entity));
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError(ex, "Ürün kategori güncelleme sırasında hata oluştu. Id={Id}", dto.Id);
//                 return Result<ProductCategoryDto>.Fail("Ürün kategori güncellenemedi.");
//             }
//         }

//         private List<int> GetAllSubCategoryIds(IEnumerable<ProductCategory> categories, int parentId)
//         {
//             var subIds = new List<int>();

//             void AddSubIds(int parent)
//             {
//                 var children = categories.Where(c => c.ParentCategoryId == parent).ToList();
//                 foreach (var child in children)
//                 {
//                     subIds.Add(child.Id);
//                     AddSubIds(child.Id);
//                 }
//             }

//             AddSubIds(parentId);
//             return subIds;
//         }

//         public async Task<Result<bool>> DeleteAsync(int id)
//         {
//             try
//             {
//                 var entity = await _productCategoryRepository.GetByIdAsync(id);
//                 if (entity == null)
//                     return Result<bool>.Fail("Kategori bulunamadı.");

//                 await _productCategoryRepository.DeleteAsync(entity);
//                 return Result<bool>.Ok(true);
//             }
//             catch (Exception ex)
//             {
//                 _logger.LogError(ex, "Kategori silme hatası. Id={Id}", id);
//                 return Result<bool>.Fail("Kategori silme işlemi başarısız oldu.");
//             }
//         }

//         #region Mapping
//         public static ProductCategoryDto MapToDto(ProductCategory entity)
//         {
//             return new ProductCategoryDto
//             {
//                 Id = entity.Id,
//                 Name = entity.Name,
//                 Description = entity.Description,
//                 ImagePath = entity.ImagePath,
//                 IsActive = entity.IsActive,
//                 Order = entity.Order ?? 0,
//                 ParentCategoryId = entity.ParentCategoryId,
//                 ParentCategoryName = entity.ParentCategory?.Name,
//                 ProductCount = entity.Products?.Count ?? 0,

//                 // Alt kategoriler (isteğe bağlı recursive mapping)
//                 SubCategories = entity.SubCategories?.Select(MapToDto).ToList() ?? new List<ProductCategoryDto>()
//             };
//         }

//         public static ProductCategory MapToEntity(ProductCategoryDto dto)
//         {
//             return new ProductCategory
//             {
//                 Id = dto.Id,
//                 Name = dto.Name,
//                 Description = dto.Description,
//                 ImagePath = dto.ImagePath,
//                 IsActive = dto.IsActive,
//                 Order = dto.Order,
//                 ParentCategoryId = dto.ParentCategoryId,
//                 UpdatedAt = DateTime.UtcNow
//             };
//         }
//         #endregion
//     }
// }
