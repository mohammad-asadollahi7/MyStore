
using Application.Dtos;
using Domain.Entities;

namespace Application.IServices;

public interface IProductService
{
    IEnumerable<Product> GetProducts();
}
