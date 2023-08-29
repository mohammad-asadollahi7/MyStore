using Application.Dtos;
using Application.Exceptions;
using Application.IServices;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountService(UserManager<IdentityUser> userManager, 
                                SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task LoginAsync(LoginDto loginDto)
    {
        if (loginDto == null)
            throw new Exception();

        var user = await _userManager.FindByEmailAsync(loginDto.Username);
        if (user is null)
            throw new UsernameNotFoundException();

        var isValidPassword = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (!isValidPassword)
            throw new PasswordWrongException();

         await _signInManager.SignInAsync(user, false);
    }

    public async Task<IdentityResult> RegisterAsync(RegisterDto registerDto)
    {
        if (registerDto == null)
            throw new Exception();

        if (registerDto.Password != registerDto.ConfirmPassword)
            throw new EmailConfirmationIsNotSame();

        var newUser = new IdentityUser()
        {
            Email = registerDto.Email,
            UserName = registerDto.Email
        };
        return await _userManager.CreateAsync(newUser, registerDto.Password);
    }
}
