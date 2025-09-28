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
    /// Реализация репозитория статуса доставки.
    /// </summary>
    public class DeliveryStatusesRepository : IDeliveryStatusesRepository
    {
        private readonly SportStoreDbContext _dbContext;

        /// <summary>
        /// Создает экземпляр репозитория статуса доставки.
        /// </summary>
        public DeliveryStatusesRepository(SportStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Получить список всех статусов доставки.
        /// </summary>
        public Task<List<DeliveryStatus>> GetDeliveryStatusesAsync(CancellationToken cancellationToken) =>
            _dbContext.DeliveryStatuses.AsNoTracking().ToListAsync(cancellationToken);

        /// <summary>
        /// Получить статус доставки по идентификатору.
        /// </summary>
        public Task<DeliveryStatus?> GetDeliveryStatusByIdAsync(Guid id, CancellationToken cancellationToken) =>
            _dbContext.DeliveryStatuses.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id, cancellationToken);


        /// <summary>
        /// Добавить новый статус доставки.
        /// </summary>
        public async Task AddDeliveryStatusAsync(DeliveryStatus deliverystatus, CancellationToken cancellationToken)
        {
            await _dbContext.DeliveryStatuses.AddAsync(deliverystatus, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Обновить существующий статус доставки.
        /// </summary
        public async Task UpdateDeliveryStatusAsync(DeliveryStatus deliverystatus, CancellationToken cancellationToken)
        {
            _dbContext.DeliveryStatuses.Update(deliverystatus);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удалить статус доставки по идентификатору.
        /// </summary>
        public async Task DeleteDeliveryStatusAsync(Guid id, CancellationToken cancellationToken)
        {
            var deliverystatus = await _dbContext.DeliveryStatuses.FindAsync(new object[] { id }, cancellationToken);
            if (deliverystatus != null)
            {
                _dbContext.DeliveryStatuses.Remove(deliverystatus);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}