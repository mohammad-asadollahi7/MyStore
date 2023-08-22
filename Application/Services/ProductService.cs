using Application.Dtos;
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
    public void Create(Product product)
    {
        _productRepository.Create(product);
    }

    public void Delete(int productId)
    {
        var isDeleted = _productRepository.Delete(productId);

        if (!isDeleted)
            throw new NullReferenceException();

    }

    public void Edit(Product product)
    {
        _productRepository.Edit(product);
    }

    public IEnumerable<Product> GetAll()
    {
        var products = _productRepository.GetAll();
        if (products == null)
            throw new NullReferenceException();

        return products;
    }

    public Product GetById(int id)
    {
        var product = _productRepository.GetById(id);
        if (product == null)
            throw new Exception();

        return product;
    }
}
