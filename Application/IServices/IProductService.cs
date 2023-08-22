
using Application.Dtos;
using Domain.Entities;

namespace Application.IServices;

public interface IProductService
{
    void Create(Product product);
    void Delete(int productId);
    IEnumerable<Product> GetAll();
    Product GetById(int id);
    void Edit(Product product);
}
