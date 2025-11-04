using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface IProductContentFeatureService
    {
        Task<Result<List<ProductContentFeatureDto>>> GetAllAsync();
        Task<Result<ProductContentFeatureDto>> GetByIdAsync(int id);
        Task<Result<List<ProductContentFeatureDto>>> GetByProductIdAsync(int productId);
        Task<Result<ProductContentFeatureDto>> AddAsync(ProductContentFeatureDto dto);
        Task<Result<bool>> UpdateAsync(ProductContentFeatureDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
