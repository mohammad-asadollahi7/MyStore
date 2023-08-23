using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public class CategoryDto
{
    [Required]
    [MinLength(3, ErrorMessage = "The minimum Charachters are 3.")]
    public string Name { get; set; }

}
