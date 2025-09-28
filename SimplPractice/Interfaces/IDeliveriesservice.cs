using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Сервис для управления доставкой.
    /// </summary>
    public interface IDeliveriesService
    {

        /// <summary>
        /// Получает список всех доставок.
        /// </summary>
        Task<List<Delivery>> GetAllDeliveriesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает доставку по её уникальному идентификатору.
        /// </summary>
        Task<Delivery?> GetDeliveryByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новую доставку.
        /// </summary>
        Task AddDeliveryAsync(Delivery delivery, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующую доставку.
        /// </summary>
        Task UpdateDeliveryAsync(Delivery delivery, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет доставку по её идентификатору.
        /// </summary>
        Task DeleteDeliveryAsync(Guid id, CancellationToken cancellationToken);
    }
}