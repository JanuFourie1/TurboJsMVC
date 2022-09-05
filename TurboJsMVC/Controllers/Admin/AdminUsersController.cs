using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers.Admin
{
    public class AdminUsersController : Controller
    {
        private readonly GRP27ETutorContext _context;
        private readonly IToastNotification _toastNotification;

        public AdminUsersController(GRP27ETutorContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users =  _context.Users.ToList() ;
                if(null == users || users.Count < 1)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
