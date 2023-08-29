

using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public class RegisterDto
{
    [EmailAddress]
    public string Email { get; set; }
   
    public string Password { get; set; }
    [Compare("Password", ErrorMessage = "The confirm password was not equal with password")]
    public string ConfirmPassword { get; set; }

}
