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

    // GET: CategoryController
    public ActionResult Index()
    {
        var categories =_categoryService.GetAll();
        return View(categories);
    }

    // GET: CategoryController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }


 
    public ActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CategoryDto categoryDto)
    {
        _categoryService.Create(categoryDto);
        return RedirectToAction(nameof(Index));
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
        _categoryService.Edit(category);
        return RedirectToAction(nameof(Index));
    }


    public ActionResult Delete(int categoryId)
    {
        _categoryService.Delete(categoryId);
        return RedirectToAction(nameof(Index));
    }

    // POST: CategoryController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
