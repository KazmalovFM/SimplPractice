using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Сервис для управления магазинами.
    /// </summary>
    public interface IStoresService
    {
        /// <summary>
        /// Получает список всех магазинов.
        /// </summary>
        Task<List<Store>> GetAllStoresAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает магазин по его уникальному идентификатору.
        /// </summary>
        Task<Store?> GetStoreByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новый магазин.
        /// </summary>
        Task AddStoreAsync(Store store, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующий магазин.
        /// </summary>
        Task UpdateStoreAsync(Store store, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет магазин по его идентификатору.
        /// </summary>
        Task DeleteStoreAsync(Guid id, CancellationToken cancellationToken);
    }
}