using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers.Admin
{
    public class AdminDashboardController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
