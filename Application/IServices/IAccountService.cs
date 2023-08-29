

using Application.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Application.IServices;

public interface IAccountService
{
    Task<IdentityResult> RegisterAsync(RegisterDto registerDto);
}
