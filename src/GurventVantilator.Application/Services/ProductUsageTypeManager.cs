using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class ProductUsageTypeManager : IProductUsageTypeService
    {
        private readonly IProductUsageTypeRepository _repository;
        private readonly ILogger<ProductUsageTypeManager> _logger;

        public ProductUsageTypeManager(IProductUsageTypeRepository repository, ILogger<ProductUsageTypeManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<ProductUsageTypeDto>>> GetAllAsync()
        {
            try
            {
                var list = await _repository.GetAllAsync();
                var dtos = list.Select(MapToDto);
                return Result<IEnumerable<ProductUsageTypeDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kullanım tipi listesi alınamadı.");
                return Result<IEnumerable<ProductUsageTypeDto>>.Fail("Kullanım tipleri yüklenemedi.");
            }
        }

        public async Task<Result<ProductUsageTypeDto>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    return Result<ProductUsageTypeDto>.Fail("Kayıt bulunamadı.");

                return Result<ProductUsageTypeDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kullanım tipi getirilemedi. Id={Id}", id);
                return Result<ProductUsageTypeDto>.Fail("Kullanım tipi getirilemedi.");
            }
        }

        public async Task<Result<ProductUsageTypeDto>> AddAsync(ProductUsageTypeDto dto)
        {
            try
            {
                var entity = MapToEntity(dto);
                await _repository.AddAsync(entity);
                return Result<ProductUsageTypeDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kullanım tipi eklenemedi: {Name}", dto.Name);
                return Result<ProductUsageTypeDto>.Fail("Kullanım tipi eklenemedi.");
            }
        }

        public async Task<Result<ProductUsageTypeDto>> UpdateAsync(ProductUsageTypeDto dto)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(dto.Id);
                if (entity == null)
                    return Result<ProductUsageTypeDto>.Fail("Kayıt bulunamadı.");

                entity.Name = dto.Name;
                entity.Description = dto.Description;

                await _repository.UpdateAsync(entity);
                return Result<ProductUsageTypeDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kullanım tipi güncellenemedi.");
                return Result<ProductUsageTypeDto>.Fail("Kullanım tipi güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Kayıt bulunamadı.");

                await _repository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kullanım tipi silinemedi.");
                return Result<bool>.Fail("Kullanım tipi silinemedi.");
            }
        }

        private static ProductUsageTypeDto MapToDto(ProductUsageType entity)
        {
            return new ProductUsageTypeDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ProductCount = entity.Products?.Count ?? 0
            };
        }

        private static ProductUsageType MapToEntity(ProductUsageTypeDto dto)
        {
            return new ProductUsageType
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
            };
        }
    }
}
