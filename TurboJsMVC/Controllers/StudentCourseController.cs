using Microsoft.AspNetCore.Mvc;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly GRP27ETutorContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public StudentCourseController(GRP27ETutorContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult StudentCourse()
        {
            var username = HttpContext.Session.GetString("Username") ?? "";
            ViewBag.Username = username;
            ViewData["Courses"] = GetCourses();
            return View();
        }

        public List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>(_context.Courses);
            return courses;
        }
    }
}
