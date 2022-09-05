using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers
{
    public class AdminReportingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
