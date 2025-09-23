
using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using GurventVantilator.Domain.Entities;
using GurventVantilator.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace GurventVantilator.Application.Services
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly ILogger<BlogManager> _logger;

        public BlogManager(IBlogRepository blogRepository, ILogger<BlogManager> logger)
        {
            _blogRepository = blogRepository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<BlogDto>>> GetAllAsync()
        {
            try
            {
                var blogs = await _blogRepository.GetAllAsync();
                var dtos = blogs.Select(b => MapToDto(b));
                return Result<IEnumerable<BlogDto>>.Ok(dtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Blog listesi alınırken hata oluştu");
                return Result<IEnumerable<BlogDto>>.Fail("Blog listesi alınamadı.");
            }
        }

        public async Task<Result<BlogDto>> GetByIdAsync(int id)
        {
            try
            {
                var blog = await _blogRepository.GetByIdAsync(id);
                if (blog == null)
                    return Result<BlogDto>.Fail("Blog bulunamadı.");

                return Result<BlogDto>.Ok(MapToDto(blog));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Blog bulunurken hata oluştu. Id={Id}", id);
                return Result<BlogDto>.Fail("Blog getirilemedi.");
            }
        }

        public async Task<Result<BlogDto>> AddAsync(BlogDto dto, List<int> tagIds)
        {
            try
            {
                var entity = MapToEntity(dto);

                if (tagIds.Any())
                {
                    entity.BlogTags = tagIds.Select(tid => new BlogTag { TagId = tid }).ToList();
                }

                await _blogRepository.AddAsync(entity);

                return Result<BlogDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Blog ekleme sırasında hata oluştu");
                return Result<BlogDto>.Fail("Blog eklenemedi.");
            }
        }

        public async Task<Result<BlogDto>> UpdateAsync(BlogDto dto, List<int> tagIds)
        {
            try
            {
                var entity = MapToEntity(dto);

                entity.BlogTags = tagIds.Select(tid => new BlogTag
                {
                    BlogId = entity.Id,
                    TagId = tid
                }).ToList();

                await _blogRepository.UpdateAsync(entity);

                return Result<BlogDto>.Ok(MapToDto(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Blog güncelleme sırasında hata oluştu. Id={Id}", dto.Id);
                return Result<BlogDto>.Fail("Blog güncellenemedi.");
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var blog = await _blogRepository.GetByIdAsync(id);
                if (blog == null)
                    return Result<bool>.Fail("Silinecek blog bulunamadı.");

                await _blogRepository.DeleteAsync(blog);
                return Result<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Blog silme sırasında hata oluştu. Id={Id}", id);
                return Result<bool>.Fail("Blog silinemedi.");
            }
        }


        #region Mapping
        private static BlogDto MapToDto(Blog entity)
        {
            var dto = new BlogDto
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
                FullName = entity.FullName,
                Title = entity.Title,
                Subtitle = entity.Subtitle,
                Description = entity.Description,
                EntryTitle = entity.EntryTitle,
                EntryDescription = entity.EntryDescription,
                ExtraTitle = entity.ExtraTitle,
                ExtraDescription = entity.ExtraDescription,
                Quote = entity.Quote,
                QuoteSource = entity.QuoteSource,
                MainImagePath = entity.MainImagePath,
                ContentImage1Path = entity.ContentImage1Path,
                ContentImage2Path = entity.ContentImage2Path,
                YoutubeVideoUrl = entity.YoutubeVideoUrl,

                CategoryId = entity.CategoryId,
                CategoryName = entity.Category?.Name ?? string.Empty,

                Tags = entity.BlogTags?
                  .Where(bt => bt.Tag != null)
                  .Select(bt => new TagDto
                  {
                      Id = bt.Tag.Id,
                      Name = bt.Tag.Name
                  }).ToList() ?? new List<TagDto>(),

                Comments = entity.Comments.Select(c => new CommentDto
                {
                    Id = c.Id,
                    BlogId = c.BlogId,
                    FullName = c.FullName,
                    Text = c.Text,
                    CreatedAt = c.CreatedAt
                }).ToList()
            };

            return dto;
        }

        private static Blog MapToEntity(BlogDto dto)
        {
            var entity = new Blog
            {
                Id = dto.Id,
                CreatedAt = dto.CreatedAt,
                FullName = dto.FullName,
                Title = dto.Title,
                Subtitle = dto.Subtitle,
                Description = dto.Description,
                EntryTitle = dto.EntryTitle,
                EntryDescription = dto.EntryDescription,
                ExtraTitle = dto.ExtraTitle,
                ExtraDescription = dto.ExtraDescription,
                Quote = dto.Quote,
                QuoteSource = dto.QuoteSource,
                MainImagePath = dto.MainImagePath,
                ContentImage1Path = dto.ContentImage1Path,
                ContentImage2Path = dto.ContentImage2Path,
                YoutubeVideoUrl = dto.YoutubeVideoUrl,
                CategoryId = dto.CategoryId
            };

            if (dto.Comments != null && dto.Comments.Any())
            {
                entity.Comments = dto.Comments.Select(c => new Comment
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    Text = c.Text,
                    CreatedAt = c.CreatedAt
                }).ToList();
            }

            return entity;
        }

        public async Task<Result<PagedResult<BlogDto>>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var (items, totalCount) = await _blogRepository.GetPagedAsync(pageNumber, pageSize);

            var dto = new PagedResult<BlogDto>
            {
                Items = items.Select(b => MapToDto(b)).ToList(),
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Result<PagedResult<BlogDto>>.Ok(dto);
        }

        public async Task<Result<PagedResult<BlogDto>>> GetPagedAsync(int? categoryId, int? tagId, int pageNumber, int pageSize)
        {
            try
            {
                var blogs = await _blogRepository.GetAllAsync();

                if (blogs == null || !blogs.Any())
                    return Result<PagedResult<BlogDto>>.Fail("Blog bulunamadı.");

                var query = blogs.AsQueryable();

                // --- Category filtresi ---
                if (categoryId.HasValue)
                    query = query.Where(b => b.CategoryId == categoryId.Value);

                // --- Tag filtresi ---
                if (tagId.HasValue)
                    query = query.Where(b => b.BlogTags.Any(t => t.TagId == tagId.Value));

                // --- Total Count ---
                var totalCount = query.Count();

                // --- Sayfalama ---
                var pagedBlogs = query
                    .OrderByDescending(b => b.CreatedAt)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                // --- DTO Map ---
                var dtoList = pagedBlogs.Select(MapToDto).ToList();

                var pagedResult = new PagedResult<BlogDto>
                {
                    Items = dtoList,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                return Result<PagedResult<BlogDto>>.Ok(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Blog listesi çekilirken hata oluştu.");
                return Result<PagedResult<BlogDto>>.Fail("Bloglar yüklenirken bir hata oluştu.");
            }
        }




        #endregion
    }
}
