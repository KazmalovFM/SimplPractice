using SimplPractice.Models;

namespace SimplPractice.Interfaces
{
    public interface IOrderDetailsService
    {
        Task<List<OrderDetails>> GetAllOrderDetailsAsync();
        Task<OrderDetails?> GetOrderDetailsByIdAsync(Guid id);
        Task AddOrderDetailsAsync(OrderDetails orderdetails);
        Task UpdateOrderDetailsAsync(OrderDetails orderdetails);
        Task DeleteOrderDetailsAsync(Guid id);
    }
}