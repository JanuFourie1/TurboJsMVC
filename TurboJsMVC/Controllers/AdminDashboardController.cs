using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
