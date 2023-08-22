
using Dapper;
using Domain.Entities;
using Domain.IRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data.SqlTypes;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationContext _context;
    private readonly IConfiguration _configuration;

    public ProductRepository(ApplicationContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    public void Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public bool Delete(int productId)
    {
        var product = _context.Products.FirstOrDefault
                                (c => c.ProductId == productId);
        if (product == null)
        {
            return false;
        }

        _context.Remove(product);
        _context.SaveChanges();
        return true;
    }

    public void Edit(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public IEnumerable<Product> GetAll()
    {
        var sql = "SELECT FROM dbo.Produts";
        using var conn = new SqlConnection(_configuration.GetConnectionString("Default"));
        var result = conn.Query<Product>(sql);
        return _context.Products.ToList();
    }

    public Product? GetById(int id)
    {
        return _context.Products.FirstOrDefault(a => a.ProductId == id);
    }
}
