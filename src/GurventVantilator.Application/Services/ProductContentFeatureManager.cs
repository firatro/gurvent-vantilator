using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;

namespace GurventVantilator.Application.Services
{
    public class ProductContentFeatureManager : IProductContentFeatureService
    {
        private readonly IProductContentFeatureRepository _repository;

        public ProductContentFeatureManager(IProductContentFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<ProductContentFeatureDto>>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var dtoList = list.Select(x => new ProductContentFeatureDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductModelId = x.ProductModelId,
                Key = x.Key,
                Value = x.Value,
                Order = x.Order
            }).ToList();

            return Result<List<ProductContentFeatureDto>>.Ok(dtoList);
        }

        public async Task<Result<ProductContentFeatureDto>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return Result<ProductContentFeatureDto>.Fail("Kayıt bulunamadı.");

            var dto = new ProductContentFeatureDto
            {
                Id = entity.Id,
                ProductId = entity.ProductId,
                ProductModelId = entity.ProductModelId,
                Key = entity.Key,
                Value = entity.Value,
                Order = entity.Order
            };
            return Result<ProductContentFeatureDto>.Ok(dto);
        }

        public async Task<Result<List<ProductContentFeatureDto>>> GetByProductIdAsync(int productId)
        {
            var list = await _repository.GetByProductIdAsync(productId);
            var dtoList = list.Select(x => new ProductContentFeatureDto
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Key = x.Key,
                Value = x.Value,
                Order = x.Order
            }).ToList();
            return Result<List<ProductContentFeatureDto>>.Ok(dtoList);
        }

        public async Task<Result<ProductContentFeatureDto>> AddAsync(ProductContentFeatureDto dto)
        {
            var entity = new ProductContentFeature
            {
                ProductModelId = dto.ProductModelId,
                ProductId = dto.ProductId,
                Key = dto.Key,
                Value = dto.Value,
                Order = dto.Order
            };

            await _repository.AddAsync(entity);
            dto.Id = entity.Id;
            return Result<ProductContentFeatureDto>.Ok(dto);
        }

        public async Task<Result<bool>> UpdateAsync(ProductContentFeatureDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null)
                return Result<bool>.Fail("Kayıt bulunamadı.");

            entity.Key = dto.Key;
            entity.Value = dto.Value;
            entity.Order = dto.Order;

            await _repository.UpdateAsync(entity);
            return Result<bool>.Ok(true);
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return Result<bool>.Fail("Kayıt bulunamadı.");

            await _repository.DeleteAsync(entity);
            return Result<bool>.Ok(true);
        }

        public async Task<Result<List<ProductContentFeatureDto>>> GetByModelIdAsync(int modelId)
        {
            var list = await _repository.GetByModelIdAsync(modelId);

            var dtoList = list.Select(x => new ProductContentFeatureDto
            {
                Id = x.Id,
                ProductModelId = x.ProductModelId ?? 0,
                Key = x.Key,
                Value = x.Value,
                Order = x.Order
            }).ToList();

            return Result<List<ProductContentFeatureDto>>.Ok(dtoList);
        }

    }
}
