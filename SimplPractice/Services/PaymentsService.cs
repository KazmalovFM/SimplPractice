using SimplPractice.Models;
using SimplPractice.Repositories.Interfaces;
using SimplPractice.Services.Interfaces;

namespace SimplPractice.Services.Implementations
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IPaymentsRepository _paymentsRepository;

        public PaymentsService(IPaymentsRepository paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;
        }

        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            return await _paymentsRepository.GetPaymentsAsync();
        }

        public async Task<Payment?> GetPaymentByIdAsync(Guid id)
        {
            return await _paymentsRepository.GetPaymentByIdAsync(id);
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            await _paymentsRepository.AddPaymentAsync(payment);
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            await _paymentsRepository.UpdatePaymentAsync(payment);
        }

        public async Task DeletePaymentAsync(Guid id)
        {
            await _paymentsRepository.DeletePaymentAsync(id);
        }
    }
}