using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurboJsMVC.Common;
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
        public async Task<IActionResult> Enrolment(StudentEnrollment enrol)
        {
            var username = HttpContext.Session.GetString("Username") ?? "";
            ViewBag.Username = username;

            
            StudentEnrollment list = new StudentEnrollment();
            list.UserId = HttpContext.Session.GetInt32("UserId");
            list.CourseId = enrol.CourseId;
            _context.StudentEnrollments.Add(list);
            var result =  await _context.SaveChangesAsync();

            if(result > 0)
            {
                 var userCheck = await _context.StudentEnrollments.FirstOrDefaultAsync(a => a.UserId.Equals(enrol.UserId));
                 
                 return RedirectToAction("Index", "StudentStudyMaterial");
            }
            else
            {
                return RedirectToAction("Index", "StudentEnrolment");
            }
        }
    }
    
    
}
