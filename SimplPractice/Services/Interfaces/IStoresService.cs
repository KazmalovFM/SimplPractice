using SimplPractice.Models;

namespace SimplPractice.Services.Interfaces
{
    public interface IStoresService
    {
        Task<List<Store>> GetAllStoresAsync();
        Task<Store?> GetStoreByIdAsync(Guid id);
        Task AddStoreAsync(Store store);
        Task UpdateStoreAsync(Store store);
        Task DeleteStoreAsync(Guid id);
    }
}