using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
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

        public IActionResult Index(int ? page)
        {
            List<User> list = new List<User>();
            var result = _context.Users.ToList();
            list = result;

            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            int limit = 10;
            int start = (int)(page - 1) * limit;
            int totalData = list.Count();
            ViewBag.totalHistories = totalData;
            ViewBag.pageCurrent = page;
            int numberPage = (totalData / limit);
            ViewBag.numberPage = numberPage;
            var dataHistories = list.Skip(start).Take(limit);
            return View(dataHistories.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = _context.Users.ToList();
                if (null == users || users.Count < 1)
                {
                    return BadRequest(users);
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
