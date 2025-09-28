using SimplPractice.Models;
using SimplPractice.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace SimplPractice.Repositories
{
    /// <summary>
    /// Реализация репозитория деталяей заказа.
    /// </summary>
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly SportStoreDbContext _dbContext;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория деталей заказа.
        /// </summary>
        public OrderDetailsRepository(SportStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Получить список всех деталей заказа.
        /// </summary>
        public Task<List<OrderDetails>> GetOrderDetailsAsync(CancellationToken cancellationToken) =>
            _dbContext.OrderDetails.AsNoTracking().ToListAsync(cancellationToken);

        /// <summary>
        /// Получить детали заказа по идентификатору.
        /// </summary>
        public Task<OrderDetails?> GetOrderDetailsByIdAsync(Guid id, CancellationToken cancellationToken) =>
            _dbContext.OrderDetails.AsNoTracking().FirstOrDefaultAsync(od => od.Id == id, cancellationToken);

        /// <summary>
        /// Добавить новые детали заказа.
        /// </summary>
        public async Task AddOrderDetailsAsync(OrderDetails orderdetails, CancellationToken cancellationToken)
        {
            await _dbContext.OrderDetails.AddAsync(orderdetails, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Обновить существующие детали заказа.
        /// </summary>
        public async Task UpdateOrderDetailsAsync(OrderDetails orderdetails, CancellationToken cancellationToken)
        {
            _dbContext.OrderDetails.Update(orderdetails);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удалить детали заказа по идентификатору.
        /// </summary>
        public async Task DeleteOrderDetailsAsync(Guid id, CancellationToken cancellationToken)
        {
            var orderdetails = await _dbContext.OrderDetails.FindAsync(new object[] { id }, cancellationToken);
            if (orderdetails != null)
            {
                _dbContext.OrderDetails.Remove(orderdetails);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}