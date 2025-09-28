using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с доставкой.
    /// </summary>
    public interface IDeliveriesRepository
    {
        /// <summary>
        /// Получить список всех доставок.
        /// </summary>
        Task<List<Delivery>> GetDeliveriesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить сведения о доставке по его ID.
        /// </summary>
        Task<Delivery?> GetDeliveryByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить новые сведения о доставке.
        /// </summary>
        Task AddDeliveryAsync(Delivery delivery, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить существующие сведения о доставке.
        /// </summary>
        Task UpdateDeliveryAsync(Delivery delivery, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить сведение о доставке по ID.
        /// </summary>
        Task DeleteDeliveryAsync(Guid id, CancellationToken cancellationToken);
    }
}