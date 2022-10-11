using GurrexTelegramBot.DAL;
using GurrexTelegramBot.DAL.Entityes;
using GurrexTelegramBot.Interfaces;
using GurrexTelegramBot.WebHost.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GurrexTelegramBot.WebHost.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRepository<ChatUser> _chatUserRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IRepository<ChatUser> chatUserRepository, 
            ILogger<HomeController> logger)
        {
            _chatUserRepository = chatUserRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {

            var users = _chatUserRepository.Items;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}