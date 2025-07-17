using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplPractice.Models;

namespace SimplPractice.Interfaces;

public interface IStoresRepository
{
    Task<List<Store>> GetStoresAsync();
    Task<Store?> GetStoreByIdAsync(Guid id);
    Task AddStoreAsync(Store store);
    Task UpdateStoreAsync(Store store);
    Task DeleteStoreAsync(Guid id);
}