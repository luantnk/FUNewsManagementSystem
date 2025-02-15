using System.Linq.Expressions;
using BusinessObjects.Context;
using Microsoft.EntityFrameworkCore;
using Repositories.Base.Implementation;
using Repositories.Interface;

namespace Repositories.Implementation;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await FindAll()
            .OrderBy(c => c.CategoryName)
            .ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(Guid id)
    {
        return await FindByCondition(c => c.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Category?> CreateCategoryAsync(Category category)
    {
        Create(category);
        await _context.SaveChangesAsync();
        return await GetCategoryByIdAsync(category.Id);
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        var existingCategory = await _context.Categories
            .Include(c => c.SubCategories)
            .FirstOrDefaultAsync(c => c.Id == category.Id);

        if (existingCategory == null)
            throw new KeyNotFoundException($"Category with ID {category.Id} not found");
        if (existingCategory.SubCategories != null)
        {
            _context.Categories.RemoveRange(existingCategory.SubCategories);
        }
        _context.Entry(existingCategory).CurrentValues.SetValues(category);
        if (category.SubCategories != null)
        {
            foreach (var subCategory in category.SubCategories)
            {
                subCategory.ParentCategoryId = category.Id;
                _context.Categories.Add(subCategory);
            }
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        var category = await _context.Categories
            .Include(c => c.SubCategories)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (category == null)
            throw new KeyNotFoundException($"Category with ID {id} not found");
        if (category.SubCategories != null)
        {
            _context.Categories.RemoveRange(category.SubCategories);
        }
        Delete(category);
        await _context.SaveChangesAsync();
    }
}