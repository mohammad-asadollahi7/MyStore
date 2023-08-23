

using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Category : BaseEntity
{
    public int CategoryId { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "The minimum Charachters are 3.")]
    public string Name { get; set; }

    public List<Product>? Products { get; set; }

}
