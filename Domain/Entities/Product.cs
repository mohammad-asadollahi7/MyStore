
namespace Domain.Entities;
public class Product : BaseEntity
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ManufactureDate { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

}
