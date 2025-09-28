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
    public class DeliveriesRepository : IDeliveriesRepository
    {
        private readonly SportStoreDbContext _dbContext;

        /// <summary>
        /// Создаёт экземпляр репозитория доставок.
        /// </summary>
        public DeliveriesRepository(SportStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Получить список всех доставок.
        /// </summary>
        public Task<List<Delivery>> GetDeliveriesAsync(CancellationToken cancellationToken) =>
            _dbContext.Deliveries.AsNoTracking().ToListAsync(cancellationToken);

        /// <summary>
        /// Получить доставку по идентификатору.
        /// </summary>
        public Task<Delivery?> GetDeliveryByIdAsync(Guid id, CancellationToken cancellationToken) =>
            _dbContext.Deliveries.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id, cancellationToken);

        /// <summary>
        /// Добавить новыую доставку.
        /// </summary>
        public async Task AddDeliveryAsync(Delivery delivery, CancellationToken cancellationToken)
        {
            await _dbContext.Deliveries.AddAsync(delivery, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Обновить существующую доставку.
        /// </summary>
        public async Task UpdateDeliveryAsync(Delivery delivery, CancellationToken cancellationToken)
        {
            _dbContext.Deliveries.Update(delivery);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удалить доставку по идентификатору.
        /// </summary>
        public async Task DeleteDeliveryAsync(Guid id, CancellationToken cancellationToken)
        {
            var delivery = await _dbContext.Deliveries.FindAsync(new object[] { id }, cancellationToken);
            if (delivery != null)
            {
                _dbContext.Deliveries.Remove(delivery);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}