namespace SimplPractice.Models
{
    /// <summary>
    /// Сведения о поставщиках.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Уникальный идентификатор "Поставщик".
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название поставщика.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;
    }
}