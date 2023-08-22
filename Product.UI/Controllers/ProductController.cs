using Application.Dtos;
using Application.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Product.UI.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public ActionResult Index()
    {
        var products = _productService.GetAll();
        return View(products);
    }


    public ActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Product product)
    {
        _productService.Create(product);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public ActionResult Edit(int productId)
    {
        var product = _productService.GetById(productId);
        return View(product);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Product product)
    {
        _productService.Edit(product);
        return RedirectToAction(nameof(Index));
    }


    public ActionResult Delete(int productId)
    {
        _productService.Delete(productId);
        return RedirectToAction(nameof(Index));
    }
}
