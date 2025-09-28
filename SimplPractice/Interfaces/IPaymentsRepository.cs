using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с оплатой.
    /// </summary>
    public interface IPaymentsRepository
    {
        /// <summary>
        /// Получить список всех оплат.
        /// </summary>
        Task<List<Payment>> GetPaymentsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить оплату по ее ID.
        /// </summary>
        Task<Payment?> GetPaymentByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить новыую оплату.
        /// </summary>
        Task AddPaymentAsync(Payment payment, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить существующую оплату.
        /// </summary>
        Task UpdatePaymentAsync(Payment payment, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить оплату по ID.
        /// </summary>
        Task DeletePaymentAsync(Guid id, CancellationToken cancellationToken);
    }
}