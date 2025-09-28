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
    /// Реализация репозитория товаров.
    /// </summary>
    public class ProductsRepository : IProductsRepository
    {
        private readonly SportStoreDbContext _dbContext;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория товаров.
        /// </summary>
        public ProductsRepository(SportStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Получить список всех товаров.
        /// </summary>
        public async Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Products
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получить товар по идентификатору.
        /// </summary>
        public async Task<Product?> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        /// <summary>
        /// Добавить новый товар.
        /// </summary>
        public async Task AddProductAsync(Product product, CancellationToken cancellationToken)
        {
            await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Обновить существующий товар.
        /// </summary>
        public async Task UpdateProductAsync(Product product, CancellationToken cancellationToken)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удалить товар по идентификатору.
        /// </summary>
        public async Task DeleteProductAsync(Guid id, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FindAsync(new object[] { id }, cancellationToken);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
