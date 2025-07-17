using SimplPractice.Models;
using SimplPractice.Repositories.Interfaces;
using SimplPractice.Services.Interfaces;

namespace SimplPractice.Services.Implementations
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeesRepository.GetEmployeesAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
        {
            return await _employeesRepository.GetEmployeeByIdAsync(id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _employeesRepository.AddEmployeeAsync(employee);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _employeesRepository.UpdateEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            await _employeesRepository.DeleteEmployeeAsync(id);
        }
    }
}