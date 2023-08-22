
using Domain.Entities;

namespace Domain.IRepositories;

public interface ICategoryRepository
{
    void Create(Category category);
    bool Delete(int categoryId);
    IEnumerable<Category> GetAll();
    Category GetById(int id);
    void Edit(Category category);
}
