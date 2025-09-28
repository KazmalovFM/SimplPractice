using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с деталями заказов.
    /// </summary>
    public interface IOrderDetailsRepository
    {
        /// <summary>
        /// Получить список всех деталей заказов.
        /// </summary>
        Task<List<OrderDetails>> GetOrderDetailsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить детали заказа по его ID.
        /// </summary>
        Task<OrderDetails?> GetOrderDetailsByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить новые детали заказа.
        /// </summary>
        Task AddOrderDetailsAsync(OrderDetails orderdetails, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить существующие детали заказа.
        /// </summary>
        Task UpdateOrderDetailsAsync(OrderDetails orderdetails, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить детали заказа по ID.
        /// </summary>
        Task DeleteOrderDetailsAsync(Guid id, CancellationToken cancellationToken);
    }
}