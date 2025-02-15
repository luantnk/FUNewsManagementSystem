using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using BusinessObjects.Dto.Category;

namespace API.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return View(categories);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        return View(category);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CategoryForCreationDto categoryDto)
    {
        if (ModelState.IsValid)
        {
            var createdCategory = await _categoryService.CreateCategoryAsync(categoryDto);
            return RedirectToAction(nameof(Index));
        }
        return View(categoryDto);
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, CategoryForUpdateDto categoryDto)
    {
        if (id != categoryDto.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            await _categoryService.UpdateCategoryAsync(categoryDto);
            return RedirectToAction(nameof(Index));
        }
        return View(categoryDto);
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return RedirectToAction(nameof(Index));
    }
}