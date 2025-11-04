using GurventVantilator.Application.Common;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GurventVantilator.AdminUI.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IFileService _fileService;

        protected BaseController(IFileService fileService)
        {
            _fileService = fileService;
        }

        protected async Task<string?> SaveImageAsync(IFormFile? file, string folderPath)
        {
            if (file == null)
                return null;

            return await _fileService.SaveFileAsync(file, folderPath, fileType: Application.Enums.FileType.Image);
        }

        protected void DeleteFileIfExists(string? filePath, string folderPath)
        {
            if (!string.IsNullOrEmpty(filePath))
                _fileService.DeleteFile(filePath, folderPath);
        }

        protected void SetSuccessMessage(string message)
        {
            TempData["SuccessMessage"] = message;
        }

        protected void SetErrorMessage(string message)
        {
            TempData["ErrorMessage"] = message;
        }
        protected IActionResult HandleServiceResult<T>(Result<T> result, string successRedirectAction)
        {
            if (result.Success)
            {
                SetSuccessMessage("İşlem başarılı bir şekilde tamamlandı.");
                return RedirectToAction(successRedirectAction);
            }

            SetErrorMessage(result.ErrorMessage ?? "Bir hata oluştu.");
            return View();
        }

    }
}
