using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с заказами.
    /// Определяет методы для выполнения CRUD операций.
    /// </summary>
    public interface IOrdersRepository
    {
        /// <summary>
        /// Получить список всех заказов.
        /// </summary>
        Task<List<Order>> GetOrdersAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить заказ по его ID.
        /// </summary>
        Task<Order?> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить новый заказ.
        /// </summary>
        Task AddOrderAsync(Order order, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить существующий заказ.
        /// </summary>
        Task UpdateOrderAsync(Order order, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить заказ по ID.
        /// </summary>
        Task DeleteOrderAsync(Guid id, CancellationToken cancellationToken);
    }
}