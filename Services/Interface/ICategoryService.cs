using BusinessObjects.Dto.Category;

namespace Services.Interface;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto> GetCategoryByIdAsync(Guid id);
    Task<CategoryDto?> CreateCategoryAsync(CategoryForCreationDto categoryDto);
    Task UpdateCategoryAsync(CategoryForUpdateDto categoryDto);
    Task DeleteCategoryAsync(Guid id);
}