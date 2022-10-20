using Microsoft.AspNetCore.Mvc;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class LectureDashboardController : Controller
    {
        public IActionResult LectureDashboard()
        {
           
            return View();
        }
    }
}
