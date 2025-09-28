using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Сервис для управления поставщиками.
    /// </summary>
    public interface ISuppliersService
    {
        /// <summary>
        /// Получает список всех поставщиков.
        /// </summary>
        Task<List<Supplier>> GetAllSuppliersAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает поставщика по его уникальному идентификатору.
        /// </summary>
        Task<Supplier?> GetSupplierByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового поставщика.
        /// </summary>
        Task AddSupplierAsync(Supplier supplier, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующий магазин.
        /// </summary>
        Task UpdateSupplierAsync(Supplier supplier, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет магазин по его идентификатору.
        /// </summary>
        Task DeleteSupplierAsync(Guid id, CancellationToken cancellationToken);
    }
}