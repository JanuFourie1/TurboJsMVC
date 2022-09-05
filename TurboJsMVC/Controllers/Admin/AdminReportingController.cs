using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers.Admin
{
    public class AdminReportingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
