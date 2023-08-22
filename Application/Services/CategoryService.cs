using Application.Dtos;
using Application.IServices;
using Domain.Entities;
using Domain.IRepositories;

namespace Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IProductRepository _categoryRepository;

    public CategoryService(IProductRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public void Create(CategoryDto categoryDto)
    {
        var category = new Category()
        {
            Name = categoryDto.Name,
            Products = null
        };

        _categoryRepository.Create(category);
    }

    public void Delete(int categoryId)
    {
        var isDeleted = _categoryRepository.Delete(categoryId);

        if (!isDeleted)
            throw new NullReferenceException();

    }

    public void Edit(Category category)
    {
        _categoryRepository.Edit(category);
    }

    public IEnumerable<Category> GetAll()
    {
        var categories = _categoryRepository.GetAll();
        if (categories == null)
            throw new NullReferenceException();

        return categories;
    }

    public Category GetById(int id)
    {
        var category = _categoryRepository.GetById(id);
        if (category == null)
            throw new Exception();

        return category;
    }
}
