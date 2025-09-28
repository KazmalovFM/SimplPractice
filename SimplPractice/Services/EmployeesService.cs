using SimplPractice.Models;
using SimplPractice.Interfaces;
using System.Threading;

namespace SimplPractice.Services
{
    /// <summary>
    /// Сервис для управления сотрудниками.
    /// </summary>
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса сотрудников.
        /// </summary>
        public EmployeesService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        /// <summary>
        /// Получить список всех сотрудников.
        /// </summary>
        public async Task<List<Employee>> GetAllEmployeesAsync(CancellationToken cancellationToken)
        {
            return await _employeesRepository.GetEmployeesAsync(cancellationToken);
        }

        /// <summary>
        /// Получить сотрудника по идентификатору.
        /// </summary>
        public async Task<Employee?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _employeesRepository.GetEmployeeByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Добавить нового сотрудника.
        /// </summary>
        public async Task AddEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
            await _employeesRepository.AddEmployeeAsync(employee, cancellationToken);
        }

        /// <summary>
        /// Обновить существующего сотрудника .
        /// </summary>
        public async Task UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
            await _employeesRepository.UpdateEmployeeAsync(employee, cancellationToken);
        }

        /// <summary>
        /// Удалить сотрудника по идентификатору.
        /// </summary>
        public async Task DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken)
        {
            await _employeesRepository.DeleteEmployeeAsync(id, cancellationToken);
        }
    }
}