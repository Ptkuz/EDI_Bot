using System.ComponentModel.DataAnnotations;

namespace GurrexTelegramBot.WebHost.Models.ViewModels.UserViewModels
{

    /// <summary>
    /// Модель авторизации администратора
    /// </summary>
    public class LoginViewModel
    {

        /// <summary>
        /// Логин администратора
        /// </summary>
        [Required(ErrorMessage = "Не указан логин")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$", ErrorMessage = "Неверный формат логина")]
        [Display(Name = "Логин")]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Пароль администратора
        /// </summary>
        [Required(ErrorMessage = "Не указан пароль")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Пароль не соответствует шаблону")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = null!;

    }
}
