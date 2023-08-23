
using Domain.Entities;

namespace Domain.IRepositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    void Create(Product product);
}
