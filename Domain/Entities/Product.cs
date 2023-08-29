
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Product : BaseEntity
{
    public int ProductId { get; set; }

    [MinLength(3, ErrorMessage = "The minmum length is 3.")]
    [Required]
    public string Name { get; set; }

    [Required]
    public decimal Price { get; set; }


    [MaxLength(10)]
    [MinLength(10)]
    public string ManufactureDate { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public string? UserId { get; set; }

}
