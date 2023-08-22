
using Application.Dtos;
using Domain.Entities;

namespace Application.IServices;

public interface ICategoryService
{
    void Create(CategoryDto categoryDto);
    void Delete(int categoryId);
    IEnumerable<Category> GetAll();
    Category GetById(int id);
    void Edit(Category category);
}
