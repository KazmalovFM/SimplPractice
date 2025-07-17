namespace SimplPractice.Models
{
    /// <summary>
    /// Сведения о клиентах.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Уникальный идентификатор "Клиент".
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Имя клиента.
        /// </summary>
        public string NameUser { get; set; } = string.Empty;

        /// <summary>
        /// Номер телефона клиента.
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Поста клиента.
        /// </summary>
        public string Mail { get; set; } = string.Empty;



    }
}