

using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public class LoginDto
{
    [EmailAddress]
    public string Username { get; set; }

    public string Password { get; set; }    

}
