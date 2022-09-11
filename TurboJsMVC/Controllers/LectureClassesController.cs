using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers
{
    public class LectureClassesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
