using Application.Dtos;
using Application.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
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
    public IActionResult Index()
    {
        var products = _productService.GetProducts();
        return View(products);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Create()
    {
        return View(); 
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    
    public IActionResult Create([FromForm] ProductDto productDto)
    {
        _productService.Create(productDto);
        return RedirectToAction(nameof(Index));
    }

}
