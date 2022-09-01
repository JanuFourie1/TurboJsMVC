using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers.Student
{
    public class StudentDashboardController : Controller
    {
        public IActionResult StudentDashboard()
        {
            return View();
        }
    }
}
