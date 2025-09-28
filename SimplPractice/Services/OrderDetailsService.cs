using SimplPractice.Models;
using SimplPractice.Interfaces;
using System.Threading;

namespace SimplPractice.Services
{
    /// <summary>
    /// Сервис для управления деталями заказа.
    /// </summary>
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderdetailsRepository;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса деталей заказа.
        /// </summary>
        public OrderDetailsService(IOrderDetailsRepository orderdetailsRepository)
        {
            _orderdetailsRepository = orderdetailsRepository;
        }

        /// <summary>
        /// Получить список всех деталей заказа.
        /// </summary>
        public async Task<List<OrderDetails>> GetAllOrderDetailsAsync(CancellationToken cancellationToken)
        {
            return await _orderdetailsRepository.GetOrderDetailsAsync(cancellationToken);
        }

        /// <summary>
        /// Получить детали заказа по идентификатору.
        /// </summary>
        public async Task<OrderDetails?> GetOrderDetailsByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _orderdetailsRepository.GetOrderDetailsByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Добавить новые детали заказа.
        /// </summary>
        public async Task AddOrderDetailsAsync(OrderDetails orderdetails, CancellationToken cancellationToken)
        {
            await _orderdetailsRepository.AddOrderDetailsAsync(orderdetails, cancellationToken);
        }

        /// <summary>
        /// Обновить существующие детали заказа.
        /// </summary>
        public async Task UpdateOrderDetailsAsync(OrderDetails orderdetails, CancellationToken cancellationToken)
        {
            await _orderdetailsRepository.UpdateOrderDetailsAsync(orderdetails, cancellationToken);
        }

        /// <summary>
        /// Удалить детали заказа по идентификатору.
        /// </summary>
        public async Task DeleteOrderDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            await _orderdetailsRepository.DeleteOrderDetailsAsync(id, cancellationToken);
        }
    }
}