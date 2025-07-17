namespace SimplPractice.Models
{
    /// <summary>
    /// Сотрудник, взявший заказ.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Уникальный идентификатор сотрудника.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя сотрудника.
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Должность сотрудника.
        /// </summary>
        public string Position { get; set; } = string.Empty;
    }
}