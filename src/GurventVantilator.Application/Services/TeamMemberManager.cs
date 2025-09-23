using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class TeamMemberManager : ITeamMemberService
    {
        private readonly ITeamMemberRepository _repository;
        private readonly ILogger<TeamMemberManager> _logger;

        public TeamMemberManager(ITeamMemberRepository repository, ILogger<TeamMemberManager> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<TeamMemberDto>>> GetAllAsync()
        {
            try
            {
                var items = await _repository.GetAllAsync();
                var dtos = items.Select(MapToDto).ToList();
                return Result<IEnumerable<TeamMemberDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Takım üyeleri listelenirken hata oluştu.");
                return Result<IEnumerable<TeamMemberDto>>.Fail("Takım üyeleri listelenemedi.");
            }
        }

        public async Task<Result<TeamMemberDto>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    return Result<TeamMemberDto>.Fail("Takım üyesi bulunamadı.");

                return Result<TeamMemberDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Takım üyesi getirilirken hata oluştu. Id={Id}", id);
                return Result<TeamMemberDto>.Fail("Takım üyesi getirilemedi.");
            }
        }

        public async Task<Result<TeamMemberDto>> AddAsync(TeamMemberDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.FullName))
                    return Result<TeamMemberDto>.Fail("Takım üyesinin adı boş olamaz.");

                var entity = MapToEntity(dto);
                await _repository.AddAsync(entity);

                return Result<TeamMemberDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Takım üyesi eklenirken hata oluştu.");
                return Result<TeamMemberDto>.Fail("Takım üyesi eklenemedi.");
            }
        }

        public async Task<Result<TeamMemberDto>> UpdateAsync(TeamMemberDto dto)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(dto.Id);
                if (entity == null)
                    return Result<TeamMemberDto>.Fail("Güncellenecek kayıt bulunamadı.");

                var updatedEntity = MapToEntity(dto);
                await _repository.UpdateAsync(updatedEntity);

                return Result<TeamMemberDto>.Ok(MapToDto(updatedEntity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Takım üyesi güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<TeamMemberDto>.Fail("Takım üyesi güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek kayıt bulunamadı.");

                await _repository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Takım üyesi silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Takım üyesi silinemedi.");
            }
        }

        #region Mapping
        private TeamMemberDto MapToDto(TeamMember entity)
        {
            return new TeamMemberDto
            {
                Id = entity.Id,
                Title = entity.Title,
                FullName = entity.FullName,
                Biography = entity.Biography,
                Phone = entity.Phone,
                Email = entity.Email,
                Website = entity.Website,
                Facebook = entity.Facebook,
                Twitter = entity.Twitter,
                Youtube = entity.Youtube,
                Linkedin = entity.Linkedin,
                Instagram = entity.Instagram,
                Experience = entity.Experience,
                Skills = string.IsNullOrWhiteSpace(entity.Skills)
                    ? ""
                    : string.Join(", ", System.Text.Json.JsonSerializer.Deserialize<List<string>>(entity.Skills)!),
                ImagePath = entity.ImagePath
            };
        }

        private TeamMember MapToEntity(TeamMemberDto dto)
        {
            return new TeamMember
            {
                Id = dto.Id,
                Title = dto.Title,
                FullName = dto.FullName,
                Biography = dto.Biography,
                Phone = dto.Phone,
                Email = dto.Email,
                Website = dto.Website,
                Facebook = dto.Facebook,
                Twitter = dto.Twitter,
                Youtube = dto.Youtube,
                Linkedin = dto.Linkedin,
                Instagram = dto.Instagram,
                Experience = dto.Experience,
                Skills = string.IsNullOrWhiteSpace(dto.Skills)
                    ? "[]"
                    : System.Text.Json.JsonSerializer.Serialize(
                        dto.Skills.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(s => s.Trim())
                                  .ToList()
                    ),
                ImagePath = dto.ImagePath
            };
        }
        #endregion
    }
}
