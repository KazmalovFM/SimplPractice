using SimplPractice.Models;

namespace SimplPractice.Interfaces
{
    public interface IDeliveriesService
    {
        Task<List<Delivery>> GetAllDeliveriesAsync();
        Task<Delivery?> GetDeliveryByIdAsync(Guid id);
        Task AddDeliveryAsync(Delivery delivery);
        Task UpdateDeliveryAsync(Delivery delivery);
        Task DeleteDeliveryAsync(Guid id);
    }
}