using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Extensions;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Interfaces.Repositories;
using GurventVantilator.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class MenuManager : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly ILogger<MenuManager> _logger;

        public MenuManager(IMenuRepository menuRepository, ILogger<MenuManager> logger)
        {
            _menuRepository = menuRepository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<MenuDto>>> GetAllAsync()
        {
            try
            {
                var menus = await _menuRepository.GetAllWithChildrenAsync();

                var dtos = menus.Select(x => x.MapToDto()).ToList();
                return Result<IEnumerable<MenuDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Menü listesi alınırken hata oluştu.");
                return Result<IEnumerable<MenuDto>>.Fail("Menü listesi getirilemedi.");
            }
        }

        public async Task<Result<MenuDto>> GetByIdAsync(int id)
        {
            try
            {
                var menu = await _menuRepository.GetByIdAsync(id);
                if (menu == null)
                    return Result<MenuDto>.Fail("Menü bulunamadı.");

                return Result<MenuDto>.Ok(menu.MapToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Menü getirilirken hata oluştu. Id={Id}", id);
                return Result<MenuDto>.Fail("Menü getirilemedi.");
            }
        }

        public async Task<Result<MenuDto>> AddAsync(MenuDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Title))
                    return Result<MenuDto>.Fail("Menü başlığı boş olamaz.");

                dto.Slug = SlugHelper.GenerateSlug(dto.Title);

                var entity = dto.MapToEntity();
                await _menuRepository.AddAsync(entity);

                return Result<MenuDto>.Ok(entity.MapToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Menü eklenirken hata oluştu.");
                return Result<MenuDto>.Fail("Menü eklenemedi.");
            }
        }

        public async Task<Result<MenuDto>> UpdateAsync(MenuDto dto)
        {
            try
            {
                var entity = await _menuRepository.GetByIdAsync(dto.Id);
                if (entity == null)
                    return Result<MenuDto>.Fail("Güncellenecek menü bulunamadı.");

                entity.Title = dto.Title;
                entity.Slug = SlugHelper.GenerateSlug(dto.Title);

                entity.LinkType = (MenuLinkType)dto.LinkType;
                entity.ContentHtml = dto.ContentHtml;
                entity.ServiceId = dto.ServiceId;
                entity.ProjectId = dto.ProjectId;
                entity.ProductId = dto.ProductId;
                entity.ProductCategoryId = dto.ProductCategoryId;

                entity.ParentId = dto.ParentId;
                entity.Order = dto.Order;
                entity.IsActive = dto.IsActive;

                await _menuRepository.UpdateAsync(entity);

                return Result<MenuDto>.Ok(entity.MapToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Menü güncellenirken hata oluştu. Id={Id}", dto.Id);
                return Result<MenuDto>.Fail("Menü güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _menuRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek menü bulunamadı.");

                await _menuRepository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Menü silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Menü silinemedi.");
            }
        }
    }
}
