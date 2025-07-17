using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplPractice.Models;

namespace SimplPractice.Interfaces;

public interface IPaymentsRepository
{
    Task<List<Payment>> GetPaymentsAsync();
    Task<Payment?> GetPaymentByIdAsync(Guid id);
    Task AddPaymentAsync(Payment payment);
    Task UpdatePaymentAsync(Payment payment);
    Task DeletePaymentAsync(Guid id);
}