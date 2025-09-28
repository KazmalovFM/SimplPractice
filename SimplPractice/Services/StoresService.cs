using SimplPractice.Models;
using SimplPractice.Interfaces;
using System.Threading;

namespace SimplPractice.Services
{
    /// <summary>
    /// Сервис для управления магазинами.
    /// </summary>
    public class StoresService : IStoresService
    {
        private readonly IStoresRepository _storesRepository;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса магазинов.
        /// </summary>
        public StoresService(IStoresRepository storesRepository)
        {
            _storesRepository = storesRepository;
        }

        /// <summary>
        /// Получить список всех магазинов.
        /// </summary>
        public async Task<List<Store>> GetAllStoresAsync(CancellationToken cancellationToken)
        {
            return await _storesRepository.GetStoresAsync(cancellationToken);
        }

        /// <summary>
        /// Получить магазин по идентификатору.
        /// </summary>
        public async Task<Store?> GetStoreByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _storesRepository.GetStoreByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Добавить новый мгазин.
        /// </summary>
        public async Task AddStoreAsync(Store store, CancellationToken cancellationToken)
        {
            await _storesRepository.AddStoreAsync(store, cancellationToken);
        }

        /// <summary>
        /// Обновить существующий магазин.
        /// </summary>
        public async Task UpdateStoreAsync(Store store, CancellationToken cancellationToken)
        {
            await _storesRepository.UpdateStoreAsync(store, cancellationToken);
        }

        /// <summary>
        /// Удалить магазин по идентификатору.
        /// </summary>
        public async Task DeleteStoreAsync(Guid id, CancellationToken cancellationToken)
        {
            await _storesRepository.DeleteStoreAsync(id, cancellationToken);
        }
    }
}