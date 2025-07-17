using SimplPractice.Models;

namespace SimplPractice.Services.Interfaces
{
    public interface IDeliveryStatusesService
    {
        Task<List<DeliveryStatus>> GetAllDeliveryStatusesAsync();
        Task<DeliveryStatus?> GetDeliveryStatusByIdAsync(Guid id);
        Task AddDeliveryStatusAsync(DeliveryStatus deliverystatus);
        Task UpdateDeliveryStatusAsync(DeliveryStatus deliverystatus);
        Task DeleteDeliveryStatusAsync(Guid id);
    }
}