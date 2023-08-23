using Domain.Entities;
using Domain.IRepositories;

namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationContext _context;

    public CategoryRepository(ApplicationContext context)
    {
        _context = context;
    }
    public void Create(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public bool Delete(int categoryId)
    {
        var category = _context.Categories.Find(categoryId);

        if (category == null)
            return false;

        _context.Remove(category);
        _context.SaveChanges();
        return true;    
    }

    public void Edit(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();
    }

    public IQueryable<Category> GetAll()
    {
        return _context.Categories.AsQueryable();
    }

    public Category? GetById(int id)
    {
        return _context.Categories.FirstOrDefault(a => a.CategoryId == id);
    }
}
