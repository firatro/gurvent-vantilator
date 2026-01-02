using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

public interface IProductAccessoryService
{
    Task<Result<IEnumerable<ProductAccessoryDto>>> GetByProductIdAsync(int productId);
    Task<Result<ProductAccessoryDto>> GetByIdAsync(int id);

    Task<Result<ProductAccessoryDto>> AddAsync(ProductAccessoryDto dto);
    Task<Result<ProductAccessoryDto>> UpdateAsync(ProductAccessoryDto dto);
    Task<Result<bool>> DeleteAsync(int id);
}
