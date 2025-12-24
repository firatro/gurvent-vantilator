using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class ProductWorkingConditionManager : IProductWorkingConditionService
    {
        private readonly IProductWorkingConditionRepository _repository;
        private readonly ILogger<ProductWorkingConditionManager> _logger;

        public ProductWorkingConditionManager(IProductWorkingConditionRepository repository, ILogger<ProductWorkingConditionManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<ProductWorkingConditionDto>>> GetAllAsync()
        {
            try
            {
                var list = await _repository.GetAllAsync();
                var dtos = list.Select(MapToDto);
                return Result<IEnumerable<ProductWorkingConditionDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Çalışma koşulu listesi alınamadı.");
                return Result<IEnumerable<ProductWorkingConditionDto>>.Fail("Çalışma koşulları yüklenemedi.");
            }
        }

        public async Task<Result<ProductWorkingConditionDto>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    return Result<ProductWorkingConditionDto>.Fail("Kayıt bulunamadı.");

                return Result<ProductWorkingConditionDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Çalışma koşulu getirilemedi. Id={Id}", id);
                return Result<ProductWorkingConditionDto>.Fail("Çalışma koşulu getirilemedi.");
            }
        }

        public async Task<Result<ProductWorkingConditionDto>> AddAsync(ProductWorkingConditionDto dto)
        {
            try
            {
                var entity = MapToEntity(dto);
                await _repository.AddAsync(entity);
                return Result<ProductWorkingConditionDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Çalışma koşulu eklenemedi: {Name}", dto.Name);
                return Result<ProductWorkingConditionDto>.Fail("Çalışma koşulu eklenemedi.");
            }
        }

        public async Task<Result<ProductWorkingConditionDto>> UpdateAsync(ProductWorkingConditionDto dto)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(dto.Id);
                if (entity == null)
                    return Result<ProductWorkingConditionDto>.Fail("Kayıt bulunamadı.");

                entity.Name = dto.Name;
                entity.Description = dto.Description;

                await _repository.UpdateAsync(entity);
                return Result<ProductWorkingConditionDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Çalışma koşulu güncellenemedi.");
                return Result<ProductWorkingConditionDto>.Fail("Çalışma koşulu güncellenemedi.");
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
                _logger.LogError(ex, "Çalışma koşulu silinemedi.");
                return Result<bool>.Fail("Çalışma koşulu silinemedi.");
            }
        }

        private static ProductWorkingConditionDto MapToDto(ProductWorkingCondition entity)
        {
            return new ProductWorkingConditionDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ProductCount = entity.Products?.Count ?? 0,
            };
        }

        private static ProductWorkingCondition MapToEntity(ProductWorkingConditionDto dto)
        {
            return new ProductWorkingCondition
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
            };
        }
    }
}
