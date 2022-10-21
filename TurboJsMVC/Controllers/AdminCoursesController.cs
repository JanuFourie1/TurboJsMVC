using Microsoft.AspNetCore.Mvc;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class AdminCoursesController : Controller
    {
        private readonly GRP27ETutorContext _context;

        private readonly IHttpContextAccessor httpContextAccessor;

        public AdminCoursesController(GRP27ETutorContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        }


        public async Task<IActionResult>  Index(int ? page)
        {
            List<Course> list = new List<Course>();
            list = await Task.Run(() => _context.Courses.ToList());
            list = list.OrderByDescending(x => x.Id).ToList();
            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            int limit = 3;
            int start = (int)(page - 1) * limit;
            int totalData = list.Count();
            ViewBag.totalHistories = totalData;
            ViewBag.pageCurrent = page;
            float numberPage = (float) totalData / limit;
            ViewBag.numberPage = (int)Math.Ceiling(numberPage);
            var dataHistories = list.Skip(start).Take(limit);
            return View(dataHistories.ToList());
        }

        public async Task<IActionResult> AddCourse(Course course)
        {
            try
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction("Index", "AdminCourses");
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public ActionResult DeleteCourse(int courseId)
        {
            try
            {
                Course course = _context.Courses.FirstOrDefault(x => x.Id == courseId);
                _context.Courses.Remove(course);
                _context.SaveChanges();
                return RedirectToAction("Index", "AdminCourses");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        public async Task<IActionResult> GetCourses() { 
            List<Course> courses = new List<Course>();
            courses = _context.Courses.ToList();
            courses = courses.OrderBy(x => x.Name).ToList();
            return Ok(courses);
        }

        [HttpGet]
        public async Task<IActionResult> GetCourse(int courseId)
        {
            var result = _context.Courses.FirstOrDefault(x => x.Id == courseId);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourse(int courseId, string name, string description, string duration, int department)
        {
            Course course = _context.Courses.FirstOrDefault(m => m.Id== courseId);
            course.Name = name;
            course.Description = description;
            course.Duration = duration;
            course.Department = department;
            _context.Courses.Update(course);
            _context.SaveChanges();
            return Ok("Course updated");
        }
    }
}
