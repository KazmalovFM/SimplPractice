using SimplPractice.Models;
using SimplPractice.Interfaces;
using System.Threading;

namespace SimplPractice.Services
{
    /// <summary>
    /// Сервис для управления заказов.
    /// </summary>
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса заказов.
        /// </summary>
        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        /// <summary>
        /// Получить список всех заказов.
        /// </summary>
        public async Task<List<Order>> GetAllOrdersAsync(CancellationToken cancellationToken)
        {
            return await _ordersRepository.GetOrdersAsync(cancellationToken);
        }

        /// <summary>
        /// Получить заказ по идентификатору.
        /// </summary>
        public async Task<Order?> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _ordersRepository.GetOrderByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Добавить новый заказ.
        /// </summary>
        public async Task AddOrderAsync(Order order, CancellationToken cancellationToken)
        {
            await _ordersRepository.AddOrderAsync(order, cancellationToken);
        }

        /// <summary>
        /// Обновить существующий заказ.
        /// </summary>
        public async Task UpdateOrderAsync(Order order, CancellationToken cancellationToken)
        {
            await _ordersRepository.UpdateOrderAsync(order, cancellationToken);
        }

        /// <summary>
        /// Удалить заказ по идентификатору.
        /// </summary>
        public async Task DeleteOrderAsync(Guid id, CancellationToken cancellationToken)
        {
            await _ordersRepository.DeleteOrderAsync(id, cancellationToken);
        }
    }
}