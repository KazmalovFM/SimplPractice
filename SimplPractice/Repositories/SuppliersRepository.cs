using SimplPractice.Models;
using SimplPractice.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace SimplPractice.Repositories
{
    /// <summary>
    /// Реализация репозитория поставщиков.
    /// </summary>
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly SportStoreDbContext _dbContext;

        /// <summary>
        /// Создает экземпляр репозитория поставщиков.
        /// </summary>
        public SuppliersRepository(SportStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Получить список всех поставщиков.
        /// </summary>
        public Task<List<Supplier>> GetSuppliersAsync(CancellationToken cancellationToken) =>
            _dbContext.Suppliers.AsNoTracking().ToListAsync(cancellationToken);


        /// <summary>
        /// Получить поставщика по идентификатору.
        /// </summary>
        public Task<Supplier?> GetSupplierByIdAsync(Guid id, CancellationToken cancellationToken) =>
            _dbContext.Suppliers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        /// <summary>
        /// Добавить нового поставщика.
        /// </summary>
        public async Task AddSupplierAsync(Supplier supplier, CancellationToken cancellationToken)
        {
            await _dbContext.Suppliers.AddAsync(supplier, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Обновить существующего поставщика.
        /// </summary>
        public async Task UpdateSupplierAsync(Supplier supplier, CancellationToken cancellationToken)
        {
            _dbContext.Suppliers.Update(supplier);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удалить поставщика по идентификатору.
        /// </summary>
        public async Task DeleteSupplierAsync(Guid id, CancellationToken cancellationToken)
        {
            var supplier = await _dbContext.Suppliers.FindAsync(new object[] { id }, cancellationToken);
            if (supplier != null)
            {
                _dbContext.Suppliers.Remove(supplier);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}