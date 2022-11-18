using Microsoft.AspNetCore.Mvc;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class StudentEnrolmentController : Controller
    {
        private readonly GRP27ETutorContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public StudentEnrolmentController(GRP27ETutorContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
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

        [HttpPost]
        public async Task<IActionResult> StudentEnrolment(StudentEnrollment enrol)
        {

            var userId = HttpContext.Session.GetInt32("UserId");
            StudentEnrollment list = new StudentEnrollment();
            list.UserId = (int)userId;
            list.CourseId = enrol.CourseId;
            _context.StudentEnrollments.Add(list);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "StudyMaterial");
        }
    }
    
    
}
