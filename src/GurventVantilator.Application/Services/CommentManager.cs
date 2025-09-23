using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ILogger<CommentManager> _logger;

        public CommentManager(ICommentRepository commentRepository, ILogger<CommentManager> logger)
        {
            _commentRepository = commentRepository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<CommentDto>>> GetAllAsync()
        {
            try
            {
                var comments = await _commentRepository.GetAllAsync();
                var dtos = comments.Select(MapToDto).ToList();

                return Result<IEnumerable<CommentDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Yorum listesi alınırken hata oluştu.");
                return Result<IEnumerable<CommentDto>>.Fail("Yorum listesi getirilemedi.");
            }
        }

        public async Task<Result<bool>> ToggleApprovalAsync(int id)
        {
            try
            {
                var comment = await _commentRepository.GetByIdAsync(id);
                if (comment == null)
                    return Result<bool>.Fail("Yorum bulunamadı.");

                comment.IsApproved = !comment.IsApproved;
                await _commentRepository.UpdateAsync(comment);

                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Yorum onay durumu değiştirilirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Onay durumu değiştirilemedi.");
            }
        }

        public async Task<Result<IEnumerable<CommentDto>>> GetByBlogIdAsync(int blogId)
        {
            try
            {
                var comments = await _commentRepository.GetAllByBlogIdAsync(blogId);
                var dtos = comments.Select(MapToDto).ToList();

                return Result<IEnumerable<CommentDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Blog yorumları alınırken hata oluştu. BlogId={BlogId}", blogId);
                return Result<IEnumerable<CommentDto>>.Fail("Blog yorumları getirilemedi.");
            }
        }

        public async Task<Result<CommentDto>> GetByIdAsync(int id)
        {
            try
            {
                var comment = await _commentRepository.GetByIdAsync(id);
                if (comment == null)
                    return Result<CommentDto>.Fail("Yorum bulunamadı.");

                return Result<CommentDto>.Ok(MapToDto(comment));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Yorum getirilirken hata oluştu. Id={Id}", id);
                return Result<CommentDto>.Fail("Yorum getirilemedi.");
            }
        }

        public async Task<Result<CommentDto>> AddAsync(CommentDto dto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dto.Text))
                    return Result<CommentDto>.Fail("Yorum metni boş olamaz.");

                var entity = MapToEntity(dto);
                await _commentRepository.AddAsync(entity);

                return Result<CommentDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Yorum eklenirken hata oluştu.");
                return Result<CommentDto>.Fail("Yorum eklenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _commentRepository.GetByIdAsync(id);
                if (entity == null)
                    return Result<bool>.Fail("Silinecek yorum bulunamadı.");

                await _commentRepository.DeleteAsync(entity);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Yorum silinirken hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Yorum silinemedi.");
            }
        }

        #region Mapping
        private static CommentDto MapToDto(Comment entity)
        {
            return new CommentDto
            {
                Id = entity.Id,
                BlogId = entity.BlogId,
                FullName = entity.FullName,
                Text = entity.Text,
                CreatedAt = entity.CreatedAt,
                IsApproved = entity.IsApproved,
                BlogTitle = entity.Blog != null ? entity.Blog.Title : string.Empty
            };
        }

        private static Comment MapToEntity(CommentDto dto)
        {
            return new Comment
            {
                Id = dto.Id,
                BlogId = dto.BlogId,
                FullName = dto.FullName,
                Text = dto.Text,
                CreatedAt = dto.CreatedAt,
                IsApproved = dto.IsApproved
            };
        }
        #endregion
    }
}
