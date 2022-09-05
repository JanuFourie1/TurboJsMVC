using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers
{
    public class AdminModulesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
