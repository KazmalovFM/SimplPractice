using SimplPractice.Models;
using SimplPractice.Interfaces;

namespace SimplPractice.Services.Implementations
{
    public class DeliveryStatusesService : IDeliveryStatusesService
    {
        private readonly IDeliveryStatusesRepository _deliverystatusesRepository;

        public DeliveryStatusesService(IDeliveryStatusesRepository deliverystatusesRepository)
        {
            _deliverystatusesRepository = deliverystatusesRepository;
        }

        public async Task<List<DeliveryStatus>> GetAllDeliveryStatusesAsync()
        {
            return await _deliverystatusesRepository.GetDeliveryStatusesAsync();
        }

        public async Task<DeliveryStatus?> GetDeliveryStatusByIdAsync(Guid id)
        {
            return await _deliverystatusesRepository.GetDeliveryStatusByIdAsync(id);
        }

        public async Task AddDeliveryStatusAsync(DeliveryStatus deliverystatus)
        {
            await _deliverystatusesRepository.AddDeliveryStatusAsync(deliverystatus);
        }

        public async Task UpdateDeliveryStatusAsync(DeliveryStatus deliverystatus)
        {
            await _deliverystatusesRepository.UpdateDeliveryStatusAsync(deliverystatus);
        }

        public async Task DeleteDeliveryStatusAsync(Guid id)
        {
            await _deliverystatusesRepository.DeleteDeliveryStatusAsync(id);
        }
    }
}