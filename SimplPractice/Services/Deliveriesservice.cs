using SimplPractice.Models;
using SimplPractice.Interfaces;
using System.Threading;

namespace SimplPractice.Services
{
    /// <summary>
    /// Сервис для управления доставкой.
    /// </summary>
    public class DeliveriesService : IDeliveriesService
    {
        private readonly IDeliveriesRepository _deliveriesRepository;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса доставки.
        /// </summary>
        public DeliveriesService(IDeliveriesRepository deliveriesRepository)
        {
            _deliveriesRepository = deliveriesRepository;
        }

        /// <summary>
        /// Получить список всех доставок.
        /// </summary>
        public async Task<List<Delivery>> GetAllDeliveriesAsync(CancellationToken cancellationToken)
        {
            return await _deliveriesRepository.GetDeliveriesAsync(cancellationToken);
        }

        /// <summary>
        /// Получить доставку по идентификатору.
        /// </summary>
        public async Task<Delivery?> GetDeliveryByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _deliveriesRepository.GetDeliveryByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Добавить новую доставку.
        /// </summary>
        public async Task AddDeliveryAsync(Delivery delivery, CancellationToken cancellationToken)
        {
            await _deliveriesRepository.AddDeliveryAsync(delivery, cancellationToken);
        }

        /// <summary>
        /// Обновить существующую доставку.
        /// </summary>
        public async Task UpdateDeliveryAsync(Delivery delivery, CancellationToken cancellationToken)
        {
            await _deliveriesRepository.UpdateDeliveryAsync(delivery, cancellationToken);
        }

        /// <summary>
        /// Удалить доставку по идентификатору.
        /// </summary>
        public async Task DeleteDeliveryAsync(Guid id, CancellationToken cancellationToken)
        {
            await _deliveriesRepository.DeleteDeliveryAsync(id, cancellationToken);
        }
    }
}