using Application.Dtos;
using Application.Exceptions;
using Application.Extensions;
using Application.IServices;
using Domain.Entities;
using Domain.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
   

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void Create(ProductDto productDto, string userId)
    {
        var product = new Product()
        {
            Name = productDto.Name,
            Price = productDto.Price,
            ManufactureDate = productDto.ManufactureDate.DateConvertor(),
            CategoryId = productDto.CategoryId,
            UserId = userId
        };
        _productRepository.Create(product);
        
    }

    public IEnumerable<Product> GetProducts()
    {
        var products = _productRepository.GetAll();
        if (products == null)
            throw new ThereIsNoAnyProductException();
        
        return products;
    }

    
}
