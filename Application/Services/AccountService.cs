using Application.Dtos;
using Application.Exceptions;
using Application.IServices;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<IdentityUser> _userManager;

    public AccountService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
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
