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
        private readonly IEmailService _emailService;
        public HomeController(ILogger<HomeController> logger,
                              IUserService userService,
                              IEmailService emailService)
        {
            _logger = logger;
            _userService = userService;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            //UserEmailOptions emailOptions = new UserEmailOptions() 
            //{
            //    ToEmail = new List<string>() {"test@ukr.net"},
            //    PlaceHolders = new List<KeyValuePair<string, string>>()
            //    {
            //        new KeyValuePair<string, string>("{{UserName}}", "Johan")
            //    }
            //};
            //_emailService.SendTestEmail(emailOptions);
            //Отримуємо ідентифікатор користувача
            //var userId = _userService.GetUserId();
            //Отримуємо інформацію чи залогінений користувач
            //var isLoggedId = _userService.IsAuthenticated();
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
