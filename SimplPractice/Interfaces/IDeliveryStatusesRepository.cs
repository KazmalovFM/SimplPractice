using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplPractice.Models;

namespace SimplPractice.Repositories.Interfaces;

public interface IDeliveryStatusesRepository
{
    Task<List<DeliveryStatus>> GetDeliveryStatusesAsync();
    Task<DeliveryStatus?> GetDeliveryStatusByIdAsync(Guid id);
    Task AddDeliveryStatusAsync(DeliveryStatus deliverystatus);
    Task UpdateDeliveryStatusAsync(DeliveryStatus deliverystatus);
    Task DeleteDeliveryStatusAsync(Guid id);
}
