using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с магазинами.
    /// </summary>
    public interface IStoresRepository
    {
        /// <summary>
        /// Получить список всех магазинов.
        /// </summary>
        Task<List<Store>> GetStoresAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить магазин по его ID.
        /// </summary>
        Task<Store?> GetStoreByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить новый магазин.
        /// </summary>
        Task AddStoreAsync(Store store, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить существующий магазин.
        /// </summary>
        Task UpdateStoreAsync(Store store, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить магазин по ID.
        /// </summary>
        Task DeleteStoreAsync(Guid id, CancellationToken cancellationToken);
    }
}