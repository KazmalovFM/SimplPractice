using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Сервис для управления категориями.
    /// </summary>
    public interface ICategoriesService
    {
        /// <summary>
        /// Получает список всех категорий.
        /// </summary>
        Task<List<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает категорию по её уникальному идентификатору.
        /// </summary>
        Task<Category?> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новую категорию.
        /// </summary>
        Task AddCategoryAsync(Category category, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующую категорию.
        /// </summary>
        Task UpdateCategoryAsync(Category category, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет категорию по её идентификатору.
        /// </summary>
        Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken);
    }
}