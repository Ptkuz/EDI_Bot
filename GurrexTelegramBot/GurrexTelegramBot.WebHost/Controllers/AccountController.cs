using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GurrexTelegramBot.WebHost.Models.ViewModels.UserViewModels;

namespace GurrexTelegramBot.WebHost.Controllers
{
    /// <summary>
    /// Контроллер авторизации администратора
    /// </summary>
    public class AccountController : Controller
    {

        /// <summary>
        /// Перейти на строницу логина
        /// </summary>
        /// <returns>View страницы логина</returns>
        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }

        //public Task<IActionResult> Login(LoginViewModel loginViewModel) 
        //{
        //    if (ModelState.IsValid) 
        //    {

                
        //    }
        //}


    }
}
