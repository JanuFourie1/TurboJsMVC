using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers
{
    public class StudentEnrolmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
