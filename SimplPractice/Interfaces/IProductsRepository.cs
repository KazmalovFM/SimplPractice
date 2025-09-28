using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с товарами.
    /// </summary>
    public interface IProductsRepository
    {
        /// <summary>
        /// Получить список всех товаров.
        /// </summary>
        Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить товар по его ID.
        /// </summary>
        Task<Product?> GetProductByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить новый товар.
        /// </summary>
        Task AddProductAsync(Product product, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить существующий товар.
        /// </summary>
        Task UpdateProductAsync(Product product, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить товар по ID.
        /// </summary>
        Task DeleteProductAsync(Guid id, CancellationToken cancellationToken);
    }
}