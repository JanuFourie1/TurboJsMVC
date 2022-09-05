using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers.Admin
{
    public class AdminAnalyticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
