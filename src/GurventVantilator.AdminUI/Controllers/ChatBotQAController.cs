using GurventVantilator.Application.DTOs;
using GurventVantilator.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

public class ChatBotQAController : Controller
{
    private readonly IChatBotQAService _chatBotQAService;

    public ChatBotQAController(IChatBotQAService chatBotQAService)
    {
        _chatBotQAService = chatBotQAService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _chatBotQAService.GetAllAsync();

        if (!result.Success || result.Data == null)
        {
            ViewBag.ErrorMessage = result.ErrorMessage ?? "Soru-Cevap listesi yüklenemedi.";
            return View(new List<ChatBotQADto>());
        }

        return View(result.Data);
    }

    public IActionResult Create()
    {
        return View(new ChatBotQADto());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ChatBotQADto chatBotQA)
    {
        if (!ModelState.IsValid) return View(chatBotQA);

        var result = await _chatBotQAService.AddAsync(chatBotQA);

        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "Soru-Cevap eklenemedi.");
            return View(chatBotQA);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde eklendi.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int chatBotQAId)
    {
        var result = await _chatBotQAService.GetByIdAsync(chatBotQAId);

        if (!result.Success || result.Data == null)
            return NotFound();

        return View(result.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ChatBotQADto chatBotQA)
    {
        if (!ModelState.IsValid) return View(chatBotQA);

        var result = await _chatBotQAService.UpdateAsync(chatBotQA);

        if (!result.Success)
        {
            ModelState.AddModelError("", result.ErrorMessage ?? "Soru-Cevap güncellenemedi.");
            return View(chatBotQA);
        }

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde güncellendi.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int chatBotQAId)
    {
        var result = await _chatBotQAService.DeleteAsync(chatBotQAId);

        if (!result.Success)
            TempData["Error"] = result.ErrorMessage ?? "Soru-Cevap silinemedi.";

        TempData["SuccessMessage"] = "Kayıt başarılı bir şekilde silindi.";
        return RedirectToAction(nameof(Index));
    }
}
