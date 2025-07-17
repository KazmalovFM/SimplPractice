using SimplPractice.Models;
using SimplPractice.Interfaces;

namespace SimplPractice.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderdetailsRepository;

        public OrderDetailsService(IOrderDetailsRepository orderdetailsRepository)
        {
            _orderdetailsRepository = orderdetailsRepository;
        }

        public async Task<List<OrderDetails>> GetAllOrderDetailsAsync()
        {
            return await _orderdetailsRepository.GetOrderDetailsAsync();
        }

        public async Task<OrderDetails?> GetOrderDetailsByIdAsync(Guid id)
        {
            return await _orderdetailsRepository.GetOrderDetailsByIdAsync(id);
        }

        public async Task AddOrderDetailsAsync(OrderDetails orderdetails)
        {
            await _orderdetailsRepository.AddOrderDetailsAsync(orderdetails);
        }

        public async Task UpdateOrderDetailsAsync(OrderDetails orderdetails)
        {
            await _orderdetailsRepository.UpdateOrderDetailsAsync(orderdetails);
        }

        public async Task DeleteOrderDetailsAsync(Guid id)
        {
            await _orderdetailsRepository.DeleteOrderDetailsAsync(id);
        }
    }
}