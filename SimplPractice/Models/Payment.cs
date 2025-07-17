namespace SimplPractice.Models
{
    /// <summary>
    /// Сведения о оплате.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Уникальный идентификатор "Оплата".
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Сумма.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Дата оплаты.
        /// </summary>
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Способ оплаты.
        /// </summary>
        public string PaymentMethod { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор заказа.
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Навигационное свойтво заказа.
        /// </summary>
        public Order? Order { get; set; }
    }
}