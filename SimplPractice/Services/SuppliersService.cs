using SimplPractice.Models;
using SimplPractice.Interfaces;
using System.Threading;

namespace SimplPractice.Services
{
    /// <summary>
    /// Сервис для управления магазинами.
    /// </summary>
    public class SuppliersService : ISuppliersService
    {
        private readonly ISuppliersRepository _suppliersRepository;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса магазинов.
        /// </summary>
        public SuppliersService(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        /// <summary>
        /// Получить список всех магазинов.
        /// </summary>
        public async Task<List<Supplier>> GetAllSuppliersAsync(CancellationToken cancellationToken)
        {
            return await _suppliersRepository.GetSuppliersAsync(cancellationToken);
        }

        /// <summary>
        /// Получить магазин по идентификатору.
        /// </summary>
        public async Task<Supplier?> GetSupplierByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _suppliersRepository.GetSupplierByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Добавить новый магазин.
        /// </summary>
        public async Task AddSupplierAsync(Supplier supplier, CancellationToken cancellationToken)
        {
            await _suppliersRepository.AddSupplierAsync(supplier, cancellationToken);
        }

        /// <summary>
        /// Обновить существующий магазин.
        /// </summary>
        public async Task UpdateSupplierAsync(Supplier supplier, CancellationToken cancellationToken)
        {
            await _suppliersRepository.UpdateSupplierAsync(supplier, cancellationToken);
        }

        /// <summary>
        /// Удалить магазин по идентификатору.
        /// </summary>
        public async Task DeleteSupplierAsync(Guid id, CancellationToken cancellationToken)
        {
            await _suppliersRepository.DeleteSupplierAsync(id, cancellationToken);
        }
    }
}