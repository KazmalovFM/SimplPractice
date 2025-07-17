namespace SimplPractice.Models
{
    /// <summary>
    /// Сведения о статусе доставки.
    /// </summary>
    public class DeliveryStatus
    {
        /// <summary>
        /// Уникальный идентификатор "Статус доставки".
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название статуса.
        /// </summary>
        public string StatusName { get; set; } = string.Empty;
    }
}

