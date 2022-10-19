using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers
{
    public class LectureDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
