// using GurventVantilator.Application.Common;
// using GurventVantilator.Application.DTOs;
// using GurventVantilator.Application.Interfaces.Services;
// using GurventVantilator.Domain.Interfaces.Repositories;
// using GurventVantilator.Domain.Entities;

// namespace GurventVantilator.Application.Services
// {
//     public class ProductApplicationManager : IProductApplicationService
//     {
//         private readonly IProductApplicationRepository _repository;

//         public ProductApplicationManager(IProductApplicationRepository repository)
//         {
//             _repository = repository;
//         }

//         public async Task<Result<IEnumerable<ProductApplicationDto>>> GetAllAsync()
//         {
//             var entities = await _repository.GetAllAsync();

//             var dtos = entities.Select(a => new ProductApplicationDto
//             {
//                 Id = a.Id,
//                 Name = a.Name
//             });

//             return Result<IEnumerable<ProductApplicationDto>>.Ok(dtos);
//         }

//         public async Task<Result<ProductApplicationDto>> GetByIdAsync(int id)
//         {
//             var entity = await _repository.GetByIdAsync(id);
//             if (entity == null)
//                 return Result<ProductApplicationDto>.Fail("Uygulama alanı bulunamadı.");

//             var dto = new ProductApplicationDto
//             {
//                 Id = entity.Id,
//                 Name = entity.Name
//             };

//             return Result<ProductApplicationDto>.Ok(dto);
//         }

//         public async Task<Result<ProductApplicationDto>> AddAsync(ProductApplicationDto dto)
//         {
//             var entity = new ProductApplication
//             {
//                 Name = dto.Name
//             };

//             await _repository.AddAsync(entity);

//             dto.Id = entity.Id;
//             return Result<ProductApplicationDto>.Ok(dto);
//         }

//         public async Task<Result<ProductApplicationDto>> UpdateAsync(ProductApplicationDto dto)
//         {
//             var existing = await _repository.GetByIdAsync(dto.Id);
//             if (existing == null)
//                 return Result<ProductApplicationDto>.Fail("Uygulama alanı bulunamadı.");

//             existing.Name = dto.Name;
//             await _repository.UpdateAsync(existing);

//             return Result<ProductApplicationDto>.Ok(dto);
//         }

//         public async Task<Result<bool>> DeleteAsync(int id)
//         {
//             var entity = await _repository.GetByIdAsync(id);
//             if (entity == null)
//                 return Result<bool>.Fail("Uygulama alanı bulunamadı.");

//             await _repository.DeleteAsync(entity);
//             return Result<bool>.Ok(true);
//         }

//         public async Task<Result<PagedResult<ProductApplicationDto>>> GetPagedAsync(int pageNumber, int pageSize)
//         {
//             var (items, totalCount) = await _repository.GetPagedAsync(pageNumber, pageSize);

//             var dtos = items.Select(a => new ProductApplicationDto
//             {
//                 Id = a.Id,
//                 Name = a.Name
//             }).ToList();

//             var paged = new PagedResult<ProductApplicationDto>
//             {
//                 Items = dtos,
//                 TotalCount = totalCount,
//                 PageNumber = pageNumber,
//                 PageSize = pageSize
//             };

//             return Result<PagedResult<ProductApplicationDto>>.Ok(paged);
//         }

//     }
// }
