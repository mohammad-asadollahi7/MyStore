using Application.Dtos;
using Application.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Product.UI.Controllers;

public class ProductController : BaseController
{
    private readonly IProductService _productService;
    private readonly IAccountService _accountService;

    public ProductController(IProductService productService, IAccountService accountService)
    {
        _productService = productService;
        _accountService = accountService;
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
        var userId = base.CurrentUserID;
        _productService.Create(productDto, userId);
        return RedirectToAction(nameof(Index));
    }

}
