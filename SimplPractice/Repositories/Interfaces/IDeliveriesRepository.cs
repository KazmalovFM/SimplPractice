using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplPractice.Models;

namespace SimplPractice.Repositories.Interfaces;

public interface IDeliveriesRepository
{
    Task<List<Delivery>> GetDeliveriesAsync();
    Task<Delivery?> GetDeliveryByIdAsync(Guid id);
    Task AddDeliveryAsync(Delivery delivery);
    Task UpdateDeliveryAsync(Delivery delivery);
    Task DeleteDeliveryAsync(Guid id);
}
