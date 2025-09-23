using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<CompanyManager> _logger;

        public CompanyManager(ICompanyRepository companyRepository, ILogger<CompanyManager> logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }

        public async Task<Result<CompanyDto>> GetByIdAsync(int id)
        {
            try
            {
                var company = await _companyRepository.GetByIdAsync(id);
                if (company == null)
                    return Result<CompanyDto>.Fail("Firma bulunamadı.");

                return Result<CompanyDto>.Ok(MapToDto(company));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Firma getirilirken hata oluştu. Id={Id}", id);
                return Result<CompanyDto>.Fail("Firma getirilemedi.");
            }
        }

        public async Task<Result<IEnumerable<CompanyDto>>> GetAllAsync()
        {
            try
            {
                var companies = await _companyRepository.GetAllAsync();
                var dtos = companies.Select(MapToDto).ToList();

                return Result<IEnumerable<CompanyDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Firma listesi alınırken hata oluştu.");
                return Result<IEnumerable<CompanyDto>>.Fail("Firma listesi getirilemedi.");
            }
        }

        public async Task<Result<CompanyDto>> AddAsync(CompanyDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Name))
                    return Result<CompanyDto>.Fail("Firma adı boş olamaz.");

                var entity = MapToEntity(dto);
                await _companyRepository.AddAsync(entity);

                return Result<CompanyDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Firma eklenirken hata oluştu.");
                return Result<CompanyDto>.Fail("Firma eklenemedi.");
            }
        }

        public async Task<Result<CompanyDto>> UpdateAsync(CompanyDto dto)
        {
            try
            {
                var existing = await _companyRepository.GetByIdAsync(dto.Id);
                if (existing == null)
                    return Result<CompanyDto>.Fail("Güncellenecek firma bulunamadı.");

                existing.Name = dto.Name;
                existing.LogoPath = dto.LogoPath;

                await _companyRepository.UpdateAsync(existing);

                return Result<CompanyDto>.Ok(MapToDto(existing));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Firma güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<CompanyDto>.Fail("Firma güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _companyRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek firma bulunamadı.");

                await _companyRepository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Firma silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Firma silinemedi.");
            }
        }

        #region Mapping
        private static CompanyDto MapToDto(Company entity)
        {
            return new CompanyDto
            {
                Id = entity.Id,
                Name = entity.Name,
                LogoPath = entity.LogoPath
            };
        }

        private static Company MapToEntity(CompanyDto dto)
        {
            return new Company
            {
                Id = dto.Id,
                Name = dto.Name,
                LogoPath = dto.LogoPath
            };
        }
        #endregion
    }
}
