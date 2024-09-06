using Store.Models;
using Store.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(UserRegistrationModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUser(user);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(user);
                }
                ModelState.Clear();
                return View();
            }
            return View(user);
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
