using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Сервис для управления заказами.
    /// </summary>
    public interface IOrdersService
    {
        /// <summary>
        /// Получает список всех заказов.
        /// </summary>
        Task<List<Order>> GetAllOrdersAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает заказ по его уникальному идентификатору.
        /// </summary>
        Task<Order?> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новый заказ.
        /// </summary>
        Task AddOrderAsync(Order order, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующий заказ.
        /// </summary>
        Task UpdateOrderAsync(Order order, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет заказ по его идентификатору.
        /// </summary>
        Task DeleteOrderAsync(Guid id, CancellationToken cancellationToken);
    }
}