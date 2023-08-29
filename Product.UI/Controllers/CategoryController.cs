using Application.Dtos;
using Application.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Product.UI.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        var categories = _categoryService.GetAllWithProducts();
        return View(categories);
    }

    [Authorize]
    public ActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Create(CategoryDto categoryDto)
    {
        if (ModelState.IsValid)
        {
            _categoryService.Create(categoryDto);
            return RedirectToAction(nameof(Index));
        }
        return View(nameof(Create), categoryDto);
    }

    [HttpGet]
    public IActionResult Edit(int categoryId)
    {
        var category = _categoryService.GetById(categoryId);
        return View(category);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            _categoryService.Edit(category);
            return RedirectToAction(nameof(Index));
        }
        return View(nameof(Edit), category);
    }


    public IActionResult Delete(int categoryId)
    {
        _categoryService.Delete(categoryId);
        return RedirectToAction(nameof(Index));
    }

}
