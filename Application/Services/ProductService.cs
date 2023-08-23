using Application.Dtos;
using Application.Exceptions;
using Application.IServices;
using Domain.Entities;
using Domain.IRepositories;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public IEnumerable<Product> GetProducts()
    {
        var products = _productRepository.GetAll();
        if (products == null)
            throw new ThereIsNoAnyProductException();
        
        return products;
    }
}
