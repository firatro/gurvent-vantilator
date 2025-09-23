using GurventVantilator.AdminUI.Models.Project;
using GurventVantilator.AdminUI.Mappings;
using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

public class ProjectController : Controller
{
    private readonly IProjectService _projectService;
    private readonly IFileService _fileService;

    public ProjectController(IProjectService projectService, IFileService fileService)
    {
        _projectService = projectService;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _projectService.GetAllAsync();

        if (!result.Success || result.Data == null)
        {
            ViewBag.ErrorMessage = result.ErrorMessage ?? "Projeler yüklenemedi.";
            return View(new List<ProjectDto>());
        }

        return View(result.Data);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProjectCreateViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var mainImagePath = vm.MainImageFile != null
            ? await _fileService.SaveFileAsync(vm.MainImageFile, "uploads/images/project")
            : null;

        var contentImage1Path = vm.ContentImage1File != null
            ? await _fileService.SaveFileAsync(vm.ContentImage1File, "uploads/images/project")
            : null;

        var contentImage2Path = vm.ContentImage2File != null
            ? await _fileService.SaveFileAsync(vm.ContentImage2File, "uploads/images/project")
            : null;

        var dto = vm.ToDto(mainImagePath, contentImage1Path, contentImage2Path);

        var result = await _projectService.AddAsync(dto);

        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "Proje eklenemedi.");
            return View(vm);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int projectId)
    {
        var result = await _projectService.GetByIdAsync(projectId);

        if (!result.Success || result.Data == null)
            return NotFound();

        var vm = result.Data.ToEditViewModel();
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProjectEditViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var existingResult = await _projectService.GetByIdAsync(vm.Id);
        if (!existingResult.Success || existingResult.Data == null)
            return NotFound();

        var existing = existingResult.Data;

        var mainImagePath = vm.MainImageFile != null
            ? await _fileService.SaveFileAsync(vm.MainImageFile, "uploads/images/project")
            : existing.MainImagePath;

        var contentImage1Path = vm.ContentImage1File != null
            ? await _fileService.SaveFileAsync(vm.ContentImage1File, "uploads/images/project")
            : existing.ContentImage1Path;

        var contentImage2Path = vm.ContentImage2File != null
            ? await _fileService.SaveFileAsync(vm.ContentImage2File, "uploads/images/project")
            : existing.ContentImage2Path;

        var dto = vm.ToDto(mainImagePath, contentImage1Path, contentImage2Path, existing.CreatedAt);

        var result = await _projectService.UpdateAsync(dto);

        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "Proje güncellenemedi.");
            return View(vm);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int projectId)
    {
        var result = await _projectService.GetByIdAsync(projectId);

        if (result.Success && result.Data != null)
        {
            _fileService.DeleteFile(result.Data.MainImagePath, "uploads/images/project");
            _fileService.DeleteFile(result.Data.ContentImage1Path, "uploads/images/project");
            _fileService.DeleteFile(result.Data.ContentImage2Path, "uploads/images/project");

            var deleteResult = await _projectService.DeleteAsync(projectId);
            if (!deleteResult.Success)
                TempData["Error"] = deleteResult.ErrorMessage ?? "Proje silinemedi.";
        }
        else
        {
            TempData["Error"] = result.ErrorMessage ?? "Silinecek proje bulunamadı.";
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
        return RedirectToAction(nameof(Index));
    }
}
