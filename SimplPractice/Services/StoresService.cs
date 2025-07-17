using SimplPractice.Models;
using SimplPractice.Interfaces;

namespace SimplPractice.Services
{
    public class StoresService : IStoresService
    {
        private readonly IStoresRepository _storesRepository;

        public StoresService(IStoresRepository storesRepository)
        {
            _storesRepository = storesRepository;
        }

        public async Task<List<Store>> GetAllStoresAsync()
        {
            return await _storesRepository.GetStoresAsync();
        }

        public async Task<Store?> GetStoreByIdAsync(Guid id)
        {
            return await _storesRepository.GetStoreByIdAsync(id);
        }

        public async Task AddStoreAsync(Store store)
        {
            await _storesRepository.AddStoreAsync(store);
        }

        public async Task UpdateStoreAsync(Store store)
        {
            await _storesRepository.UpdateStoreAsync(store);
        }

        public async Task DeleteStoreAsync(Guid id)
        {
            await _storesRepository.DeleteStoreAsync(id);
        }
    }
}