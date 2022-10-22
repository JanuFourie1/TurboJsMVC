using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class AdminReportingController : Controller
    {

        private readonly GRP27ETutorContext _context;
        private readonly IToastNotification _toastNotification;

        private readonly IHttpContextAccessor httpContextAccessor;

        public AdminReportingController(GRP27ETutorContext context, IToastNotification toastNotification, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _toastNotification = toastNotification;
            this.httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetLoginHistory()
        {
            try
            {
                List<LoginHistoryCustom> list = new List<LoginHistoryCustom>();
                var result = await Task.Run(() => _context.LoginHistories.FromSqlRaw("EXECUTE USP_GET_LoginHistory").ToList());
                var users = await _context.Users.ToListAsync();

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

                if (null == list || list.Count < 1)
                {
                    return BadRequest(result);
                }
                return Ok(list);
            }
            catch
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> LoginHistoryReport()
        {
            LoginHistoryReport historyReport = new LoginHistoryReport();
            byte[] _file = historyReport.PrepareReport(GetLoginHistories());
            return File(_file, "application/pdf");
        }

        public List<LoginHistoryCustom> GetLoginHistories()
        {
            List<LoginHistoryCustom> list = new List<LoginHistoryCustom>();
            var result = _context.LoginHistories.ToList();
            result = result.OrderByDescending(x => x.Id).ToList();
            var users = _context.Users.ToList();

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
            return list;
        }

        public async Task<IActionResult> UsersReport(User user) 
        {
            UserReport userReport = new UserReport();
            byte[] _file = userReport.PrepareReport(GetUsers());
            return File(_file, "application/pdf");
        }

        public async Task<IActionResult> JoinedReport(string selected)
        {
            UserJoinedReport userReport = new UserJoinedReport();
            byte[] _file = userReport.PrepareReport(GetJoined(DateTime.Parse(selected)));
            return File(_file, "application/pdf");
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users = _context.Users.Where(q => q.IsDeleted == false).ToList();
            users = users.OrderBy(x => x.Username).ToList();
            return users;
        }

        public List<User> GetJoined(DateTime selected)
        {
            List<User> users = new List<User>();
            users = _context.Users.Where(q => q.DateJoined >= selected).ToList();
            users = users.OrderBy(x => x.Username).ToList();
            return users;
        }
    }
}
