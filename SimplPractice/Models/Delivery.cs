namespace SimplPractice.Models
{
    /// <summary>
    /// Сведения о доставке.
    /// </summary>
    public class Delivery
    {
        /// <summary>
        /// Уникальный идентификатор "Доставка".
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Время доставки.
        /// </summary>
        public DateTime DeliveryDate { get; set; }


        /// <summary>
        /// Идентификатор заказа.
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Навигационное свойтво заказа.
        /// </summary>
        public Order? Order { get; set; }

        /// <summary>
        /// Идентификатор статуса доставки.
        /// </summary>
        public Guid DeliveryStatusId { get; set; }

        /// <summary>
        /// Навигационное свойтво статуса доставки.
        /// </summary>
        public DeliveryStatus? DeliveryStatus { get; set; }
    }
}