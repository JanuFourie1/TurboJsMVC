using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
