
using Application.Dtos;
using Domain.Entities;

namespace Application.IServices;

public interface IProductService
{
    IEnumerable<Product> GetProducts();
    void Create(ProductDto productDto, string userId);
}
