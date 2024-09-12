using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Service;
using System.Diagnostics;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger,
                              IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            //Отримуємо ідентифікатор користувача
            var userId = _userService.GetUserId();
            //Отримуємо інформацію чи залогінений користувач
            var isLoggedId = _userService.IsAuthenticated();
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
