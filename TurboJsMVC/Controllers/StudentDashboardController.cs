using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers
{
    public class StudentDashboardController : Controller
    {
        public IActionResult StudentDashboard()
        {
            return View();
        }
    }
}
