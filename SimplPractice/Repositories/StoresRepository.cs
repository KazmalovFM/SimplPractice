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
    /// Реализация репозитория магазинаов.
    /// </summary>
    public class StoresRepository : IStoresRepository
    {
        private readonly SportStoreDbContext _dbContext;

        /// <summary>
        /// Создает экземпляр репозитория магазинов.
        /// </summary>
        public StoresRepository(SportStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Получить список всех магазинов.
        /// </summary>
        public Task<List<Store>> GetStoresAsync(CancellationToken cancellationToken) =>
            _dbContext.Stores.AsNoTracking().ToListAsync(cancellationToken);


        /// <summary>
        /// Получить магазин по идентификатору.
        /// </summary>
        public Task<Store?> GetStoreByIdAsync(Guid id, CancellationToken cancellationToken) =>
            _dbContext.Stores.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        /// <summary>
        /// Добавить новый магазин.
        /// </summary>
        public async Task AddStoreAsync(Store store, CancellationToken cancellationToken)
        {
            await _dbContext.Stores.AddAsync(store, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Обновить существующий магазин.
        /// </summary>
        public async Task UpdateStoreAsync(Store store, CancellationToken cancellationToken)
        {
            _dbContext.Stores.Update(store);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удалить магазин по идентификатору.
        /// </summary>
        public async Task DeleteStoreAsync(Guid id, CancellationToken cancellationToken)
        {
            var store = await _dbContext.Stores.FindAsync(new object[] { id }, cancellationToken);
            if (store != null)
            {
                _dbContext.Stores.Remove(store);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}