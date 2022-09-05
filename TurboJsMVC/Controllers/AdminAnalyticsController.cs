using Microsoft.AspNetCore.Mvc;

namespace TurboJsMVC.Controllers
{
    public class AdminAnalyticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
