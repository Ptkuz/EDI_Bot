using GurrexTelegramBot.DAL.Entityes.Base;

namespace GurrexTelegramBot.DAL.Entityes
{
    /// <summary>
    /// Сущность администратора
    /// </summary>
    public class AdminUser : Entity
    {
        /// <summary>
        /// Логин администратора
        /// </summary>
        public string Login { get; set; } = null!;

        /// <summary>
        /// Пароль администратора
        /// </summary>
        public string Password { get; set; } = null!;
    }
}
