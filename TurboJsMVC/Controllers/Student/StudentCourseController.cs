using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers.Student
{
    public class StudentCourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
