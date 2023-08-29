using Application.Dtos;
using Application.IServices;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Product.UI.Controllers;

public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    public IActionResult Index()
    {
        return View();
    }


    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> RegisterAsync(RegisterDto model)
    {
        if (ModelState.IsValid)
        {
            var result = await _accountService.RegisterAsync(model);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Registration failed");
                return View();
            }
            return RedirectToAction(nameof(Index), nameof(Product));
        }
        return View(nameof(Register), model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> LoginAsync(LoginDto loginDto,[FromQuery] string? ReturnUrl)
    {
        if (ModelState.IsValid)
        {
            await _accountService.LoginAsync(loginDto);
            if(ReturnUrl != null && Url.IsLocalUrl(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }
            return RedirectToAction(nameof(Index), nameof(Product));
        }

        return View(nameof(Login));
    }
}

