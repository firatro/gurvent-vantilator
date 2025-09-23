using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

public class CommentController : Controller
{
    private readonly ICommentService _commentService;
    private readonly IBlogService _blogService;

    public CommentController(ICommentService commentService, IBlogService blogService)
    {
        _commentService = commentService;
        _blogService = blogService;
    }

    public async Task<IActionResult> Index(int? blogId = null)
    {
        if (blogId.HasValue)
        {
            var blogResult = await _blogService.GetByIdAsync(blogId.Value);
            if (!blogResult.Success || blogResult.Data == null)
            {
                ViewBag.ErrorMessage = blogResult.ErrorMessage ?? "Blog bulunamadı.";
                return View(new List<CommentDto>());
            }

            var commentResult = await _commentService.GetByBlogIdAsync(blogId.Value);
            if (!commentResult.Success || commentResult.Data == null)
            {
                ViewBag.ErrorMessage = commentResult.ErrorMessage ?? "Yorumlar getirilemedi.";
                return View(new List<CommentDto>());
            }

            ViewBag.BlogTitle = blogResult.Data.Title;
            return View(commentResult.Data);
        }
        else
        {
            var commentResult = await _commentService.GetAllAsync();
            if (!commentResult.Success || commentResult.Data == null)
            {
                ViewBag.ErrorMessage = commentResult.ErrorMessage ?? "Yorum listesi getirilemedi.";
                return View(new List<CommentDto>());
            }

            return View(commentResult.Data);
        }
    }

    public async Task<IActionResult> ToggleApproval(int commentId)
    {
        var result = await _commentService.ToggleApprovalAsync(commentId);

        if (!result.Success)
            TempData["Error"] = result.ErrorMessage ?? "Yorum onay durumu değiştirilemedi.";

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int commentId, int blogId)
    {
        var result = await _commentService.DeleteAsync(commentId);

        if (!result.Success)
            TempData["Error"] = result.ErrorMessage ?? "Yorum silinemedi.";

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
        return RedirectToAction("Index", new { blogId });
    }
}
