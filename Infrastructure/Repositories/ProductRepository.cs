
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
    private readonly IConfiguration _config;

    public ProductRepository(ApplicationContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public void Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public IEnumerable<Product> GetAll()
    {
        var query = string.Format(SqlQueries.GetAll, "Products");
        using var conn = new SqlConnection(_config.GetConnectionString("Default"));
        var products = conn.Query<Product>(query).AsQueryable();
        return products;
    }
}

public static class SqlQueries
{
    public static string GetAll { get; set; } = "SELECT p.ProductId, p.Name, p.Price, p.ManufactureDate, p.CategoryId FROM {0} p";
}
