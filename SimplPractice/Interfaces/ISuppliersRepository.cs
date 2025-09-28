using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с поставщиками.
    /// </summary>
    public interface ISuppliersRepository
    {
        /// <summary>
        /// Получить список всех поставщиков.
        /// </summary>
        Task<List<Supplier>> GetSuppliersAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить поставщика по его ID.
        /// </summary>
        Task<Supplier?> GetSupplierByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить новый поставщика.
        /// </summary>
        Task AddSupplierAsync(Supplier supplier, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить существующий поставщика.
        /// </summary>
        Task UpdateSupplierAsync(Supplier supplier, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить поставщика по ID.
        /// </summary>
        Task DeleteSupplierAsync(Guid id, CancellationToken cancellationToken);
    }
}