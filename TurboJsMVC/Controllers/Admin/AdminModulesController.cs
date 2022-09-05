using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers.Admin
{
    public class AdminModulesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
