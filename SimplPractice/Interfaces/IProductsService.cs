using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Сервис для управления товарами.
    /// </summary>
    public interface IProductsService
    {
        /// <summary>
        /// Получает список всех товаров.
        /// </summary>
        Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает товар по его уникальному идентификатору.
        /// </summary>
        Task<Product?> GetProductByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новый товар.
        /// </summary>
        Task AddProductAsync(Product product, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующий товар.
        /// </summary>
        Task UpdateProductAsync(Product product, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет товар по его идентификатору.
        /// </summary>
        Task DeleteProductAsync(Guid id, CancellationToken cancellationToken);
    }
}