using SimplPractice.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimplPractice.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с работниками.
    /// </summary>
    public interface IEmployeesRepository
    {
        /// <summary>
        /// Получить список всех работников.
        /// </summary>
        Task<List<Employee>> GetEmployeesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить работника по его ID.
        /// </summary>
        Task<Employee?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить нового работника.
        /// </summary>
        Task AddEmployeeAsync(Employee employee, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить существующего работника.
        /// </summary>
        Task UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить работника по ID.
        /// </summary>
        Task DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken);
    }
}