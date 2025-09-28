using SimplPractice.Models;
using SimplPractice.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Repositories
{
    /// <summary>
    /// Реализация репозитория категорий.
    /// </summary>
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly SportStoreDbContext _dbContext;

        /// <summary>
        /// Создаёт экземпляр репозитория категорий.
        /// </summary>
        public CategoriesRepository(SportStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Получить список всех категорий.
        /// </summary>
        public Task<List<Category>> GetCategoriesAsync(CancellationToken cancellationToken) =>
            _dbContext.Categories.AsNoTracking().ToListAsync(cancellationToken);

        /// <summary>
        /// Получить категорию по идентификатору.
        /// </summary>
        public Task<Category?> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken) =>
            _dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        /// <summary>
        /// Добавить новую категорию.
        /// </summary>
        public async Task AddCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            await _dbContext.Categories.AddAsync(category, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Обновить сущкствующую категорию.
        /// </summary>
        public async Task UpdateCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удалить категорию по идентификатору.
        /// </summary>
        public async Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Categories.FindAsync(new object[] { id }, cancellationToken);
            if (entity != null)
            {
                _dbContext.Categories.Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
