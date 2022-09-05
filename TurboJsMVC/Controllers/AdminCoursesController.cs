using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers
{
    public class AdminCoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
