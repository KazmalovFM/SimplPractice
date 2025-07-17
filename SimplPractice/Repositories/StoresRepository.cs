using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplPractice;
using SimplPractice.Models;
using SimplPractice.Interfaces;


namespace SimplPractice.Repositories.Implementations
{
    public class StoresRepository : IStoresRepository
    {
        private readonly SportStoreDbContext _dbContext;

        public StoresRepository(SportStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Store>> GetStoresAsync()
        {
            return await _dbContext.Stores
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Store?> GetStoreByIdAsync(Guid id)
        {
            return await _dbContext.Stores
                .AsNoTracking()
                .FirstOrDefaultAsync(st => st.Id == id);
        }

        public async Task AddStoreAsync(Store store)
        {
            await _dbContext.Stores.AddAsync(store);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateStoreAsync(Store store)
        {
            _dbContext.Stores.Update(store);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteStoreAsync(Guid id)
        {
            var store = await _dbContext.Stores.FindAsync(id);
            if (store != null)
            {
                _dbContext.Stores.Remove(store);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}