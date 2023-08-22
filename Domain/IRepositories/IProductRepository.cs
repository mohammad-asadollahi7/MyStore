
using Domain.Entities;

namespace Domain.IRepositories;

public interface IProductRepository
{
    void Create(Product product);
    bool Delete(int productId);
    IEnumerable<Product> GetAll();
    Product GetById(int id);
    void Edit(Product product);
}
