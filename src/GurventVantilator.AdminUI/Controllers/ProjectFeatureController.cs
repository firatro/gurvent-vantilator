using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GurventVantilator.AdminUI.Controllers
{
    public class ProjectFeatureController : Controller
    {
        private readonly IProjectFeatureService _projectFeatureService;
        private readonly IProjectService _projectService;

        public ProjectFeatureController(IProjectFeatureService projectFeatureService, IProjectService projectService)
        {
            _projectFeatureService = projectFeatureService;
            _projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            var featureList = await _projectFeatureService.GetAllAsync();

            return View(featureList);
        }

        public async Task<IActionResult> Create()
        {
            var projectList = await _projectService.GetAllAsync();
            ViewBag.ProjectList = new SelectList(projectList.Data, "Id", "Title");

            return View(new ProjectFeatureDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectFeatureDto projectFeature)
        {
            if (!ModelState.IsValid)
            {
                var projectList = await _projectService.GetAllAsync();
                ViewBag.ProjectList = new SelectList(projectList.Data, "Id", "Title", projectFeature.ProjectId);

                return View(projectFeature);
            }

            await _projectFeatureService.AddAsync(projectFeature);

            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int projectId)
        {
            var projectFeature = await _projectFeatureService.GetByIdAsync(projectId);
            if (projectFeature == null) return NotFound();

            var projectList = await _projectService.GetAllAsync();
            ViewBag.ProjectList = new SelectList(projectList.Data, "Id", "Title", projectFeature.ProjectId);

            return View(projectFeature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectFeatureDto projectFeature)
        {
            if (!ModelState.IsValid)
            {
                var projectList = await _projectService.GetAllAsync();
                ViewBag.ProjectList = new SelectList(projectList.Data, "Id", "Title", projectFeature.ProjectId);

                return View(projectFeature);
            }

            await _projectFeatureService.UpdateAsync(projectFeature);
            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int projectFeatureId)
        {
            await _projectFeatureService.DeleteAsync(projectFeatureId);
            TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
            return RedirectToAction(nameof(Index));
        }
    }
}
