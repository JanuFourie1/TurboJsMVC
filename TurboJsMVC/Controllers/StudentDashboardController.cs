using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class StudentDashboardController : Controller
    {
        private readonly GRP27ETutorContext _context;

        public StudentDashboardController(GRP27ETutorContext context)
        {
            _context = context;
        }

        public IActionResult StudentDashboard()
        {
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
