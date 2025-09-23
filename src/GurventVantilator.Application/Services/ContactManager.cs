using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class ContactManager : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly ILogger<ContactManager> _logger;

        public ContactManager(IContactRepository contactRepository, ILogger<ContactManager> logger)
        {
            _contactRepository = contactRepository;
            _logger = logger;
        }

        public async Task<Result<ContactDto>> AddAsync(ContactDto dto)
        {
            try
            {

                var entity = MapToEntity(dto);
                await _contactRepository.AddAsync(entity);

                return Result<ContactDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "İletişim bilgileri eklenirken hata oluştu.");
                return Result<ContactDto>.Fail("İletişim bilgileri eklenemedi.");
            }
        }

        public async Task<Result<ContactDto>> GetByIdAsync(int id)
        {
            try
            {
                var contact = await _contactRepository.GetByIdAsync(id);
                if (contact == null)
                    return Result<ContactDto>.Fail("İletişim kaydı bulunamadı.");

                return Result<ContactDto>.Ok(MapToDto(contact));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Contact getirme sırasında hata oluştu. Id={Id}", id);
                return Result<ContactDto>.Fail("İletişim kaydı getirilemedi.");
            }
        }

        public async Task<Result<IReadOnlyList<ContactDto>>> GetAllAsync()
        {
            try
            {
                var contacts = await _contactRepository.GetAllAsync();
                var dtos = contacts.Select(MapToDto).ToList();
                return Result<IReadOnlyList<ContactDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Contact listesi alınırken hata oluştu.");
                return Result<IReadOnlyList<ContactDto>>.Fail("İletişim listesi getirilemedi.");
            }
        }

        public async Task<Result<ContactDto>> UpdateAsync(ContactDto dto)
        {
            try
            {
                var contact = await _contactRepository.GetByIdAsync(dto.Id);
                if (contact == null)
                    return Result<ContactDto>.Fail("Güncellenecek kayıt bulunamadı.");

                contact.Notes = dto.Notes;
                await _contactRepository.UpdateAsync(contact);

                return Result<ContactDto>.Ok(MapToDto(contact));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Contact güncelleme sırasında hata oluştu. Id={Id}", dto.Id);
                return Result<ContactDto>.Fail("İletişim kaydı güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _contactRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek iletişim kaydı bulunamadı.");

                await _contactRepository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Contact silme sırasında hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("İletişim kaydı silinemedi.");
            }
        }

        #region Mapping
        private static ContactDto MapToDto(Contact entity)
        {
            return new ContactDto
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                Phone = entity.Phone,
                Subject = entity.Subject,
                Message = entity.Message,
                Notes = entity.Notes,
                CreatedAt = entity.CreatedAt
            };
        }

        private static Contact MapToEntity(ContactDto dto)
        {
            return new Contact
            {
                Id = dto.Id,
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                Subject = dto.Subject,
                Message = dto.Message,
                Notes = dto.Notes,
                CreatedAt = dto.CreatedAt
            };
        }
        #endregion
    }
}
