using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly GRP27ETutorContext _context;

        private readonly IHttpContextAccessor httpContextAccessor;

        public AdminDashboardController(GRP27ETutorContext context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> AdminDashboard(int ? page)
        {
            List<LoginHistoryCustom> list = new List<LoginHistoryCustom>();
            var result = await Task.Run(() => _context.LoginHistories.FromSqlRaw("EXECUTE USP_GET_LoginHistory").ToList());
            result = result.OrderByDescending(x => x.Id).ToList();
            var users =  _context.Users.ToList();

            for (var i = 0; i < result.Count; i++)
            {
                var userString = "";
                var emailString = "";
                for (var j = 0; j < users.Count; j++)
                {

                    if (users[j].UserId == result[i].UserId)
                    {
                        userString = users[j].Username;
                        emailString = users[j].Email;
                    }
                }
                list.Add(new LoginHistoryCustom
                {
                    Username = userString,
                    Email = emailString,
                    Ip = result[i].Ip,
                    Date = result[i].Date.ToString("dddd, dd MMMM yy")
                });
               
            }
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
    }
}
