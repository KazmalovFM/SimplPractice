using SimplPractice.Models;
using SimplPractice.Interfaces;
using System.Threading;

namespace SimplPractice.Services
{
    /// <summary>
    /// Сервис для управления магазинами.
    /// </summary>
    public class PaymentsService : IPaymentsService
    {
        private readonly IPaymentsRepository _paymentsRepository;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса оплаты.
        /// </summary>
        public PaymentsService(IPaymentsRepository paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;
        }

        /// <summary>
        /// Получить список всех оплат.
        /// </summary>
        public async Task<List<Payment>> GetAllPaymentsAsync(CancellationToken cancellationToken)
        {
            return await _paymentsRepository.GetPaymentsAsync(cancellationToken);
        }

        /// <summary>
        /// Получить оплату по идентификатору.
        /// </summary>
        public async Task<Payment?> GetPaymentByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _paymentsRepository.GetPaymentByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Добавить новую оплату.
        /// </summary>
        public async Task AddPaymentAsync(Payment payment, CancellationToken cancellationToken)
        {
            await _paymentsRepository.AddPaymentAsync(payment, cancellationToken);
        }

        /// <summary>
        /// Обновить существующую оплату.
        /// </summary>
        public async Task UpdatePaymentAsync(Payment payment, CancellationToken cancellationToken)
        {
            await _paymentsRepository.UpdatePaymentAsync(payment, cancellationToken);
        }

        /// <summary>
        /// Удалить оплату по идентификатору.
        /// </summary>
        public async Task DeletePaymentAsync(Guid id, CancellationToken cancellationToken)
        {
            await _paymentsRepository.DeletePaymentAsync(id, cancellationToken);
        }
    }
}