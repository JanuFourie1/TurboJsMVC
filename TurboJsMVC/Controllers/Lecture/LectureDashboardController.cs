using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers.Lecture
{
    public class LectureDashboardController : Controller
    {
        public IActionResult LectureDashboard()
        {
            return View();
        }
    }
}
