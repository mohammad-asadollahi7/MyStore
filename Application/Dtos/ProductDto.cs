
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public class ProductDto
{

    [MinLength(3, ErrorMessage = "The minmum length is 3.")]
    [Required]
    public string Name { get; set; }

    [Required]
    public decimal Price { get; set; }


    [MaxLength(8)]
    [MinLength(8)]
    public string ManufactureDate { get; set; }

    public int CategoryId { get; set; }

}
