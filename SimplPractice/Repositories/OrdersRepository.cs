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
    /// Реализация репозитория заказов.
    /// </summary>
    public class OrdersRepository : IOrdersRepository
    {
        private readonly SportStoreDbContext _dbContext;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория заказов.
        /// </summary>
        public OrdersRepository(SportStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Получить список всех заказов.
        /// </summary>
        public Task<List<Order>> GetOrdersAsync(CancellationToken cancellationToken) =>
            _dbContext.Orders.AsNoTracking().ToListAsync(cancellationToken);

        /// <summary>
        /// Получить заказ по идентификатору.
        /// </summary>
        public Task<Order?> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken) =>
            _dbContext.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id, cancellationToken);


        /// <summary>
        /// Добавить новый заказ.
        /// </summary>
        public async Task AddOrderAsync(Order order, CancellationToken cancellationToken)
        {
            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Обновить существующий заказ.
        /// </summary>
        public async Task UpdateOrderAsync(Order order, CancellationToken cancellationToken)
        {
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удалить заказ по идентификатору.
        /// </summary>
        public async Task DeleteOrderAsync(Guid id, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FindAsync(new object[] { id }, cancellationToken);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}