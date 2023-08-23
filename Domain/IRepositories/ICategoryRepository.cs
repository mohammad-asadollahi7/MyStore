
using Domain.Entities;

namespace Domain.IRepositories;

public interface ICategoryRepository
{
    void Create(Category category);
    bool Delete(int categoryId);
    IQueryable<Category> GetAll();
    Category GetById(int id);
    void Edit(Category category);
}
