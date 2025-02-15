using Repositories.Base.Interface;
using BusinessObjects.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Repositories.Interface
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task<Category?> CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Guid id);
    }
}