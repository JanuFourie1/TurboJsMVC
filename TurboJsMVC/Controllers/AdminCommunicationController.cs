using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class AdminCommunicationController : Controller
    {
        private readonly IToastNotification _toastNotification;
        private readonly GRP27ETutorContext _context;

        public AdminCommunicationController(GRP27ETutorContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(string user, string subj, string body)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(subj) || string.IsNullOrEmpty(body))
            {
                _toastNotification.AddErrorToastMessage("Error, please try again");
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }
    }
}
