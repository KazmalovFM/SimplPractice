using SimplPractice.Models;
using SimplPractice.Interfaces;

namespace SimplPractice.Services.Implementations
{
    public class DeliveriesService : IDeliveriesService
    {
        private readonly IDeliveriesRepository _deliveriesRepository;

        public DeliveriesService(IDeliveriesRepository deliveriesRepository)
        {
            _deliveriesRepository = deliveriesRepository;
        }

        public async Task<List<Delivery>> GetAllDeliveriesAsync()
        {
            return await _deliveriesRepository.GetDeliveriesAsync();
        }

        public async Task<Delivery?> GetDeliveryByIdAsync(Guid id)
        {
            return await _deliveriesRepository.GetDeliveryByIdAsync(id);
        }

        public async Task AddDeliveryAsync(Delivery delivery)
        {
            await _deliveriesRepository.AddDeliveryAsync(delivery);
        }

        public async Task UpdateDeliveryAsync(Delivery delivery)
        {
            await _deliveriesRepository.UpdateDeliveryAsync(delivery);
        }

        public async Task DeleteDeliveryAsync(Guid id)
        {
            await _deliveriesRepository.DeleteDeliveryAsync(id);
        }
    }
}