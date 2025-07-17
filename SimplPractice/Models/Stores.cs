namespace SimplPractice.Models
{
    /// <summary>
    /// Сведения о магазинах.
    /// </summary>
    public class Store
    {
        /// <summary>
        /// Уникальный идентификатор "Магазин".
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название магазина.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Адрес магазина.
        /// </summary>
        public string Address { get; set; } = string.Empty;

    }
}