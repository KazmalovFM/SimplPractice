using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Сервис для управления статусами доставки.
    /// </summary>
    public interface IDeliveryStatusesService
    {
        /// <summary>
        /// Получает список всех статусов доставки.
        /// </summary>
        Task<List<DeliveryStatus>> GetAllDeliveryStatusesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает статус доставки по его уникальному идентификатору.
        /// </summary>
        Task<DeliveryStatus?> GetDeliveryStatusByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новый статус доставки.
        /// </summary>
        Task AddDeliveryStatusAsync(DeliveryStatus deliverystatus, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующий статус доставки.
        /// </summary>
        Task UpdateDeliveryStatusAsync(DeliveryStatus deliverystatus, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет статус доставки по его идентификатору.
        /// </summary>
        Task DeleteDeliveryStatusAsync(Guid id, CancellationToken cancellationToken);
    }
}