using SimplPractice.Models;
using SimplPractice.Interfaces;
using System.Threading;

namespace SimplPractice.Services
{
    /// <summary>
    /// Сервис для управления товарами.
    /// </summary>
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса товаров.
        /// </summary>
        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        /// <summary>
        /// Получить список всех товаров.
        /// </summary>
        public async Task<List<Product>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            return await _productsRepository.GetProductsAsync(cancellationToken);
        }

        /// <summary>
        /// Получить товар по идентификатору.
        /// </summary>
        public async Task<Product?> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _productsRepository.GetProductByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Добавить новый товар.
        /// </summary>
        public async Task AddProductAsync(Product product, CancellationToken cancellationToken)
        {
            await _productsRepository.AddProductAsync(product, cancellationToken);
        }

        /// <summary>
        /// Обновить существующий товар.
        /// </summary>
        public async Task UpdateProductAsync(Product product, CancellationToken cancellationToken)
        {
            await _productsRepository.UpdateProductAsync(product, cancellationToken);
        }

        /// <summary>
        /// Удалить товар по идентификатору.
        /// </summary>
        public async Task DeleteProductAsync(Guid id, CancellationToken cancellationToken)
        {
            await _productsRepository.DeleteProductAsync(id, cancellationToken);
        }
    }
}