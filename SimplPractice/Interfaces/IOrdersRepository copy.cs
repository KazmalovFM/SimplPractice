using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplPractice.Models;

namespace SimplPractice.Interfaces;

public interface IOrderDetailsRepository
{
    Task<List<OrderDetails>> GetOrderDetailsAsync();
    Task<OrderDetails?> GetOrderDetailsByIdAsync(Guid id);
    Task AddOrderDetailsAsync(OrderDetails orderdetatils);
    Task UpdateOrderDetailsAsync(OrderDetails orderdetails);
    Task DeleteOrderDetailsAsync(Guid id);
}