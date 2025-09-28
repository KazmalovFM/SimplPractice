using SimplPractice.Models;
using SimplPractice.Interfaces;
using System.Threading;

namespace SimplPractice.Services
{
    /// <summary>
    /// Сервис для управления статусом доставки.
    /// </summary>
    public class DeliveryStatusesService : IDeliveryStatusesService
    {
        private readonly IDeliveryStatusesRepository _deliverystatusesRepository;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса статуса доставки.
        /// </summary>
        public DeliveryStatusesService(IDeliveryStatusesRepository deliverystatusesRepository)
        {
            _deliverystatusesRepository = deliverystatusesRepository;
        }

        /// <summary>
        /// Получить список всех статусов доставки.
        /// </summary>
        public async Task<List<DeliveryStatus>> GetAllDeliveryStatusesAsync(CancellationToken cancellationToken)
        {
            return await _deliverystatusesRepository.GetDeliveryStatusesAsync(cancellationToken);
        }

        /// <summary>
        /// Получить статус лоставки по идентификатору.
        /// </summary>
        public async Task<DeliveryStatus?> GetDeliveryStatusByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _deliverystatusesRepository.GetDeliveryStatusByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Добавить новый статус доставки.
        /// </summary>
        public async Task AddDeliveryStatusAsync(DeliveryStatus deliverystatus, CancellationToken cancellationToken)
        {
            await _deliverystatusesRepository.AddDeliveryStatusAsync(deliverystatus, cancellationToken);
        }

        /// <summary>
        /// Обновить существующий статус доставки.
        /// </summary>
        public async Task UpdateDeliveryStatusAsync(DeliveryStatus deliverystatus, CancellationToken cancellationToken)
        {
            await _deliverystatusesRepository.UpdateDeliveryStatusAsync(deliverystatus, cancellationToken);
        }

        /// <summary>
        /// Удалить статус доставки по идентификатору.
        /// </summary>
        public async Task DeleteDeliveryStatusAsync(Guid id, CancellationToken cancellationToken)
        {
            await _deliverystatusesRepository.DeleteDeliveryStatusAsync(id, cancellationToken);
        }
    }
}