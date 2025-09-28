using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с категориями.
    /// </summary>
    public interface ICategoriesRepository
    {
        /// <summary>
        /// Получить список всех категорий.
        /// </summary>
        Task<List<Category>> GetCategoriesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить категорию по идентификатору.
        /// </summary>
        Task<Category?> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить новую категорию.
        /// </summary>
        Task AddCategoryAsync(Category category, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить категорию.
        /// </summary>
        Task UpdateCategoryAsync(Category category, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить категорию по идентификатору.
        /// </summary>
        Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken);
    }
}