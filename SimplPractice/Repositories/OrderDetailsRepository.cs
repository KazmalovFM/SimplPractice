using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplPractice;
using SimplPractice.Models;
using SimplPractice.Repositories.Interfaces;


namespace SimplPractice.Repositories.Implementations
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly SportStoreDbContext _dbContext;

        public OrderDetailsRepository(SportStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrderDetails>> GetOrderDetailsAsync()
        {
            return await _dbContext.OrderDetails
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<OrderDetails?> GetOrderDetailsByIdAsync(Guid id)
        {
            return await _dbContext.OrderDetails
                .AsNoTracking()
                .FirstOrDefaultAsync(od => od.Id == id);
        }

        public async Task AddOrderDetailsAsync(OrderDetails orderdetails)
        {
            await _dbContext.OrderDetails.AddAsync(orderdetails);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateOrderDetailsAsync(OrderDetails orderdetails)
        {
            _dbContext.OrderDetails.Update(orderdetails);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrderDetailsAsync(Guid id)
        {
            var orderdetails = await _dbContext.OrderDetails.FindAsync(id);
            if (orderdetails != null)
            {
                _dbContext.OrderDetails.Remove(orderdetails);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}