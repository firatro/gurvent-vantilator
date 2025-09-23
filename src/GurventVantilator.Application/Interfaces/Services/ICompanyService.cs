using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;

namespace GurventVantilator.Application.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<Result<CompanyDto>> GetByIdAsync(int id);
        Task<Result<IEnumerable<CompanyDto>>> GetAllAsync();
        Task<Result<CompanyDto>> AddAsync(CompanyDto dto);
        Task<Result<CompanyDto>> UpdateAsync(CompanyDto dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
