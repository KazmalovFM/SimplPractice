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
    /// Реализация репозитория сотрудников.
    /// </summary>
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly SportStoreDbContext _dbContext;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория сотрудников.
        /// </summary>
        public EmployeesRepository(SportStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Получить список всех сотрудников.
        /// </summary>
        public Task<List<Employee>> GetEmployeesAsync(CancellationToken cancellationToken) =>
            _dbContext.Employees.AsNoTracking().ToListAsync(cancellationToken);

        /// <summary>
        /// Получить сотрудника по идентификатору.
        /// </summary>
        public Task<Employee?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken) =>
            _dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        /// <summary>
        /// Добавить нового сотрудника.
        /// </summary>
        public async Task AddEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
            await _dbContext.Employees.AddAsync(employee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Обновить существующего сотрудника.
        /// </summary>
        public async Task UpdateEmployeeAsync(Employee employee, CancellationToken cancellationToken)
        {
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удалить сотрудника по идентификатору.
        /// </summary>
        public async Task DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees.FindAsync(new object[] { id }, cancellationToken);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}