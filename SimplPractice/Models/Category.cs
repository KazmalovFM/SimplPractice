namespace SimplPractice.Models
{
    /// <summary>
    /// Сведения о категориях.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Уникальный идентификатор "Категория".
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название категории.
        /// </summary>
        public string Name { get; set; } = string.Empty;

    }
}