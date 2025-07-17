using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplPractice;
using SimplPractice.Models;
using SimplPractice.Interfaces;


namespace SimplPractice.Repositories.Implementations
{
    public class DeliveryStatusesRepository : IDeliveryStatusesRepository
    {
        private readonly SportStoreDbContext _dbContext;

        public DeliveryStatusesRepository(SportStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DeliveryStatus>> GetDeliveryStatusesAsync()
        {
            return await _dbContext.DeliveryStatuses
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<DeliveryStatus?> GetDeliveryStatusByIdAsync(Guid id)
        {
            return await _dbContext.DeliveryStatuses
                .AsNoTracking()
                .FirstOrDefaultAsync(ds => ds.Id == id);
        }

        public async Task AddDeliveryStatusAsync(DeliveryStatus deliverystatus)
        {
            await _dbContext.DeliveryStatuses.AddAsync(deliverystatus);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDeliveryStatusAsync(DeliveryStatus deliverystatus)
        {
            _dbContext.DeliveryStatuses.Update(deliverystatus);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDeliveryStatusAsync(Guid id)
        {
            var deliverystatus = await _dbContext.DeliveryStatuses.FindAsync(id);
            if (deliverystatus != null)
            {
                _dbContext.DeliveryStatuses.Remove(deliverystatus);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}