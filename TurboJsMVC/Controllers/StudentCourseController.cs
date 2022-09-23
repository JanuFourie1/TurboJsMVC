using Microsoft.AspNetCore.Mvc;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly GRP27ETutorContext _context;

        public StudentCourseController(GRP27ETutorContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult StudentCourse()
        {
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
