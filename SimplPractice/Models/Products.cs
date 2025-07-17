namespace SimplPractice.Models
{
    /// <summary>
    /// Сведения о товарах.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Уникальный идентификатор "Товар".
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название товара.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Цена товара.
        /// </summary>
        public decimal Cost { get; set; } = 0;

        /// <summary>
        /// Количество товаров.
        /// </summary>
        public int TheNumberOfItemsInTheOrders { get; set; } = 0;

        /// <summary>
        /// Идентификатор магазина.
        /// </summary>
        public Guid StoreId { get; set; }

        /// <summary>
        /// Навигационное свойтво магазина.
        /// </summary>
        public Store? Store { get; set; }


        /// <summary>
        /// Идентификатор категории.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Навигационное свойтво категории.
        /// </summary>
        public Category? Category { get; set; }

        /// <summary>
        /// Идентификатор поставщика.
        /// </summary>
        public Guid SupplierId { get; set; }

        /// <summary>
        /// Навигационное свойтво поставщика.
        /// </summary>
        public Supplier? Supplier { get; set; }

    }
}