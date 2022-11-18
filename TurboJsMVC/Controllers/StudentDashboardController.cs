using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class StudentDashboardController : Controller
    {
        private readonly GRP27ETutorContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public StudentDashboardController(GRP27ETutorContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult StudentDashboard()
        {
            var username = HttpContext.Session.GetString("Username") ?? "";
            ViewBag.Username = username;
            ViewData["Users"] = GetUsers();
            ViewData["Courses"] = GetCourses();
            return View();
        }
        private List<User> GetUsers()
        {
            List<User> users = new List<User>(_context.Users);
            return users;
        }
        public List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>(_context.Courses);
            return courses;
        }
    }
}
