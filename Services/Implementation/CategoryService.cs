using BusinessObjects.Dto.Category;
using BusinessObjects.Entities;
using Mapster;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository) =>  _categoryRepository = categoryRepository;

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllCategoriesAsync();
        return categories.Adapt<IEnumerable<CategoryDto>>();
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        if (category == null)
        {
            throw new KeyNotFoundException($"Category with ID {id} not found");
        }
        return category.Adapt<CategoryDto>();
    }

    public async Task<CategoryDto?> CreateCategoryAsync(CategoryForCreationDto categoryDto)
    {
        var category = categoryDto.Adapt<Category>();
        var createdCategory = await _categoryRepository.CreateCategoryAsync(category);
        return createdCategory?.Adapt<CategoryDto>();
    }

    public async Task UpdateCategoryAsync(CategoryForUpdateDto categoryDto)
    {
        var category = categoryDto.Adapt<Category>();
        await _categoryRepository.UpdateCategoryAsync(category);
    }

    public async Task DeleteCategoryAsync(Guid id) => await _categoryRepository.DeleteCategoryAsync(id);
  
}