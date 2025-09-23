using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Application.Mappings;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class VersionInfoManager : IVersionInfoService
    {
        private readonly IVersionInfoRepository _versionInfoRepository;
        private readonly ILogger<VersionInfoManager> _logger;

        public VersionInfoManager(IVersionInfoRepository versionInfoRepository, ILogger<VersionInfoManager> logger)
        {
            _versionInfoRepository = versionInfoRepository;
            _logger = logger;
        }

        public async Task<Result<IReadOnlyList<VersionInfoDto>>> GetAllAsync()
        {
            try
            {
                var list = await _versionInfoRepository.GetAllAsync();
                var dtos = list.Select(x => x.ToDto()).ToList();
                return Result<IReadOnlyList<VersionInfoDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sürüm listesi alınırken hata oluştu.");
                return Result<IReadOnlyList<VersionInfoDto>>.Fail("Sürümler getirilemedi.");
            }
        }

        public async Task<Result<VersionInfoDto>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _versionInfoRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<VersionInfoDto>.Fail("Sürüm bulunamadı.");

                return Result<VersionInfoDto>.Ok(entity.ToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sürüm getirilirken hata oluştu. Id={Id}", id);
                return Result<VersionInfoDto>.Fail("Sürüm getirilemedi.");
            }
        }

        public async Task<Result<VersionInfoDto>> GetActiveAsync()
        {
            try
            {
                var entity = await _versionInfoRepository.GetActiveAsync();
                if (entity == null)
                    return Result<VersionInfoDto>.Fail("Aktif sürüm bulunamadı.");

                return Result<VersionInfoDto>.Ok(entity.ToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Aktif sürüm getirilirken hata oluştu.");
                return Result<VersionInfoDto>.Fail("Aktif sürüm getirilemedi.");
            }
        }

        public async Task<Result<VersionInfoDto>> AddAsync(VersionInfoDto dto)
        {
            try
            {
                var entity = dto.ToEntity();
                await _versionInfoRepository.AddAsync(entity);
                return Result<VersionInfoDto>.Ok(entity.ToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sürüm eklenirken hata oluştu.");
                return Result<VersionInfoDto>.Fail("Sürüm eklenemedi.");
            }
        }

        public async Task<Result<bool>> UpdateAsync(VersionInfoDto dto)
        {
            try
            {
                var entity = dto.ToEntity();
                await _versionInfoRepository.UpdateAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sürüm güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<bool>.Fail("Sürüm güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _versionInfoRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek sürüm bulunamadı.");

                await _versionInfoRepository.DeleteAsync(id);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Sürüm silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Sürüm silinemedi.");
            }
        }

        public async Task<Result<bool>> SetActiveAsync(int id)
        {
            try
            {
                var allVersions = await _versionInfoRepository.GetAllAsync();
                foreach (var version in allVersions)
                {
                    version.IsActive = version.Id == id;
                    await _versionInfoRepository.UpdateAsync(version);
                }
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Aktif sürüm ayarlanırken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Aktif sürüm ayarlanamadı.");
            }
        }
    }
}
