using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplPractice.Models;

namespace SimplPractice.Repositories.Interfaces;

public interface ISuppliersRepository
{
    Task<List<Supplier>> GetSuppliersAsync();
    Task<Supplier?> GetSupplierByIdAsync(Guid id);
    Task AddSupplierAsync(Supplier supplier);
    Task UpdateSupplierAsync(Supplier supplier);
    Task DeleteSupplierAsync(Guid id);
}