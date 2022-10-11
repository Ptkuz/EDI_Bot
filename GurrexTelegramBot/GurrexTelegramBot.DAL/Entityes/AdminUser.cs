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

        public AdminUser() { }

       /// <summary>
       /// Создает нового администратора
       /// </summary>
       /// <param name="id">Id администратора</param>
       /// <param name="login">Логин</param>
       /// <param name="password">Пароль</param>
        public AdminUser(Guid id, string login, string password) : base(id)
        {
            Login = login;
            Password = password;
        }
    }
}
