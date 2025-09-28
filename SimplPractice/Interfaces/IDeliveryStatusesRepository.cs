using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы со статусом доставки.
    /// </summary>
    public interface IDeliveryStatusesRepository
    {
        /// <summary>
        /// Получить список всех статусов доставки.
        /// </summary>
        Task<List<DeliveryStatus>> GetDeliveryStatusesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить статус доставки по его ID.
        /// </summary>
        Task<DeliveryStatus?> GetDeliveryStatusByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить новый статус доставки.
        /// </summary>
        Task AddDeliveryStatusAsync(DeliveryStatus deliverystatus, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить существующий статус доставки.
        /// </summary>
        Task UpdateDeliveryStatusAsync(DeliveryStatus deliverystatus, CancellationToken cancellationToken);
        
        /// <summary>
        /// Удалить статус доставки по ID.
        /// </summary>
        Task DeleteDeliveryStatusAsync(Guid id, CancellationToken cancellationToken);
    }
}