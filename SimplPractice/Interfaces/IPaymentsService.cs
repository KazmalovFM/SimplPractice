using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Сервис для управления оплатой.
    /// </summary>
    public interface IPaymentsService
    {
        /// <summary>
        /// Получает список всех оплат.
        /// </summary>
        Task<List<Payment>> GetAllPaymentsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает оплату по её уникальному идентификатору.
        /// </summary>
        Task<Payment?> GetPaymentByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новую оплату.
        /// </summary>
        Task AddPaymentAsync(Payment payment, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующую оплату.
        /// </summary>
        Task UpdatePaymentAsync(Payment payment, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет оплату по её идентификатору.
        /// </summary>
        Task DeletePaymentAsync(Guid id, CancellationToken cancellationToken);
    }
}