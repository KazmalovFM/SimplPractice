namespace SimplPractice.Models
{
    /// <summary>
    /// Хранение деталей заказа.
    /// </summary>
    public class OrderDetails
    {
        /// <summary>
        /// Уникальный идентификатор "Детали заказа".
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Указывается позиция заказа.
        /// </summary>
        public string OrderPosition { get; set; } = string.Empty;

        /// <summary>
        /// Количество товарова в заказе.
        /// </summary>
        public int NumberOfItemsInOrder { get; set; }

        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Навигационное свойтво товара.
        /// </summary>
        public Product? Product { get; set; }


        /// <summary>
        /// Идентификатор заказа.
        /// </summary>

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