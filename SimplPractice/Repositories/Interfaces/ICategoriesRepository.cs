using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplPractice.Models;

namespace SimplPractice.Repositories.Interfaces;

public interface ICategoriesRepository
{
    Task<List<Category>> GetCategoriesAsync();
    Task<Category?> GetProductByIdAsync(Guid id);
    Task AddCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(Guid id);
    Task<Category?> GetCategoryByIdAsync(Guid id);
}