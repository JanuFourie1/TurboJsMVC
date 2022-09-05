using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers.Admin
{
    public class AdminCoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
