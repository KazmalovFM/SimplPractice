using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Сервис для управления сотрудниками.
    /// </summary>
    public interface IEmployeesService
    {
        /// <summary>
        /// Получает список всех сотрудников.
        /// </summary>
        Task<List<Employee>> GetAllEmployeesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает сотрудника по его уникальному идентификатору.
        /// </summary>
        Task<Employee?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового сотрудника.
        /// </summary>
        Task AddEmployeeAsync(Employee employee, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет существующего сотрудника.
        /// </summary>
        Task UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет сотрудника по его идентификатору.
        /// </summary>
        Task DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken);
    }
}