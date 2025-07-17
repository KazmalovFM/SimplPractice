using SimplPractice.Models;
using SimplPractice.Interfaces;

namespace SimplPractice.Services
{
    public class SuppliersService : ISuppliersService
    {
        private readonly ISuppliersRepository _suppliersRepository;

        public SuppliersService(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            return await _suppliersRepository.GetSuppliersAsync();
        }

        public async Task<Supplier?> GetSupplierByIdAsync(Guid id)
        {
            return await _suppliersRepository.GetSupplierByIdAsync(id);
        }

        public async Task AddSupplierAsync(Supplier supplier)
        {
            await _suppliersRepository.AddSupplierAsync(supplier);
        }

        public async Task UpdateSupplierAsync(Supplier supplier)
        {
            await _suppliersRepository.UpdateSupplierAsync(supplier);
        }

        public async Task DeleteSupplierAsync(Guid id)
        {
            await _suppliersRepository.DeleteSupplierAsync(id);
        }
    }
}