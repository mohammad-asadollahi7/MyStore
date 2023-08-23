using Application.Dtos;
using Application.IServices;
using Domain.Entities;
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

    public ActionResult Index()
    {
        var categories =_categoryService.GetAll();
        return View(categories);
    }

 
    public ActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CategoryDto categoryDto)
    {
        if (ModelState.IsValid)
        {
            _categoryService.Create(categoryDto);
            return RedirectToAction(nameof(Index));
        }
        return View(nameof(Create), categoryDto);
    }

    [HttpGet]
    public ActionResult Edit(int categoryId)
    {
        var category =_categoryService.GetById(categoryId);
        return View(category);
    }

  
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Category category)
    {
        if(ModelState.IsValid)
        {
            _categoryService.Edit(category);
            return RedirectToAction(nameof(Index));
        }
        return View(nameof(Edit), category);
    }


    public ActionResult Delete(int categoryId)
    {
        _categoryService.Delete(categoryId);
        return RedirectToAction(nameof(Index));
    }

}
