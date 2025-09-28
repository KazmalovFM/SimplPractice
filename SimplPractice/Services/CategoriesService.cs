using SimplPractice.Models; 
using SimplPractice.Interfaces;
using System.Threading;

namespace SimplPractice.Services
{
    /// <summary>
    /// Сервис для управления категориями.
    /// </summary>
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса категорий.
        /// </summary>
        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        /// <summary>
        /// Получить список всех категорий.
        /// </summary>
        public async Task<List<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            return await _categoriesRepository.GetCategoriesAsync(cancellationToken);
        }

        /// <summary>
        /// Получить категорию по идентификатору.
        /// </summary>
        public async Task<Category?> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _categoriesRepository.GetCategoryByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Добавить новую категорию.
        /// </summary>
        public async Task AddCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            await _categoriesRepository.AddCategoryAsync(category, cancellationToken);
        }

        /// <summary>
        /// Обновить существующую категорию.
        /// </summary>
        public async Task UpdateCategoryAsync(Category category, CancellationToken cancellationToken)
        {
            await _categoriesRepository.UpdateCategoryAsync(category, cancellationToken);
        }

        /// <summary>
        /// Удалить категорию по идентификатору.
        /// </summary>
        public async Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken)
        {
            await _categoriesRepository.DeleteCategoryAsync(id, cancellationToken);
        }
    }
}