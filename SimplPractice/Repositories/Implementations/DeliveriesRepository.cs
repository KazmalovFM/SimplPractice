using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplPractice;
using SimplPractice.Models;
using SimplPractice.Repositories.Interfaces;


namespace SimplPractice.Repositories.Implementations
{
    public class DeliveriesRepository : IDeliveriesRepository
    {
        private readonly SportStoreDbContext _dbContext;

        public DeliveriesRepository(SportStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Delivery>> GetDeliveriesAsync()
        {
            return await _dbContext.Deliveries
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Delivery?> GetDeliveryByIdAsync(Guid id)
        {
            return await _dbContext.Deliveries
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddDeliveryAsync(Delivery delivery)
        {
            await _dbContext.Deliveries.AddAsync(delivery);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDeliveryAsync(Delivery delivery)
        {
            _dbContext.Deliveries.Update(delivery);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDeliveryAsync(Guid id)
        {
            var delivery = await _dbContext.Deliveries.FindAsync(id);
            if (delivery != null)
            {
                _dbContext.Deliveries.Remove(delivery);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}