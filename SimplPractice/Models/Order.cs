namespace SimplPractice.Models;

/// <summary>    
/// Представляет заказ, который оформил клиент.    
/// </summary>
public class Order
{
    /// <summary>
    /// Уникальный идентификатор заказа.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Дата оформления заказа.
    /// </summary>
    public DateTime OrderFormationDate { get; set; }

    /// <summary>
    /// Идентификатор клиента.
    /// </summary>
    public Guid ClientId { get; set; }

    /// <summary>
    /// Навигационное свойтво клиента.
    /// </summary>
    public Client? Client { get; set; }

    /// <summary>
    /// Идентификатор сотрудника.
    /// </summary>
    public Guid EmployeeId { get; set; }

    /// <summary>
    /// Навигационное свойтво Сотрудника.
    /// </summary>
    public Employee? Employee { get; set; }

    /// <summary>
    /// Навигационное свойтво Доствки.
    /// </summary>
    public Delivery? Delivery { get; set; }
}