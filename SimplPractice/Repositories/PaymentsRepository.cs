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
    /// Реализация репозитория оплаты.
    /// </summary>
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly SportStoreDbContext _dbContext;

        /// <summary>
        /// Создает экземпляр репозитория оплаты.
        /// </summary>
        public PaymentsRepository(SportStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Получить список всех оплат.
        /// </summary>
        public Task<List<Payment>> GetPaymentsAsync(CancellationToken cancellationToken) =>
            _dbContext.Payments.AsNoTracking().ToListAsync(cancellationToken);

        /// <summary>
        /// Получить оплаты по идентификатору.
        /// </summary>
        public Task<Payment?> GetPaymentByIdAsync(Guid id, CancellationToken cancellationToken) =>
            _dbContext.Payments.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        /// <summary>
        /// Добавить новыую оплату.
        /// </summary>
        public async Task AddPaymentAsync(Payment payment, CancellationToken cancellationToken)
        {
            await _dbContext.Payments.AddAsync(payment, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Обновить существующую оплату.
        /// </summary>
        public async Task UpdatePaymentAsync(Payment payment, CancellationToken cancellationToken)
        {
            _dbContext.Payments.Update(payment);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удалить оплату по идентификатору.
        /// </summary>
        public async Task DeletePaymentAsync(Guid id, CancellationToken cancellationToken)
        {
            var payment = await _dbContext.Payments.FindAsync(new object[] { id }, cancellationToken);
            if (payment != null)
            {
                _dbContext.Payments.Remove(payment);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}