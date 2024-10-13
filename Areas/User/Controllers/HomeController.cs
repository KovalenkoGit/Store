using Microsoft.AspNetCore.Mvc;

namespace Store.Areas.User.Controllers
{
    [Area("user")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
