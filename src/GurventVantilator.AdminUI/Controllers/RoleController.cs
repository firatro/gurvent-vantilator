using GurventVantilator.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GurventVantilator.AdminUI.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Admin,DevAdmin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // 🔹 Listeleme
        [HttpGet]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        // 🔹 Ekleme (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 🔹 Ekleme (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationRole model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (await _roleManager.RoleExistsAsync(model.Name))
            {
                ModelState.AddModelError("", "Bu isimde bir rol zaten mevcut.");
                return View(model);
            }

            var role = new ApplicationRole
            {
                Name = model.Name,
                NormalizedName = model.Name.ToUpper(),
                Description = model.Description
            };

            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Rol başarıyla oluşturuldu.";
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        // 🔹 Silme
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
            {
                TempData["ErrorMessage"] = "Rol bulunamadı.";
                return RedirectToAction(nameof(Index));
            }

            var result = await _roleManager.DeleteAsync(role);
            TempData[result.Succeeded ? "SuccessMessage" : "ErrorMessage"] =
                result.Succeeded ? "Rol başarıyla silindi." : "Rol silinemedi.";

            return RedirectToAction(nameof(Index));
        }
    }
}
