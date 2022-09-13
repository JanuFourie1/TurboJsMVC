using Microsoft.AspNetCore.Mvc;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class AdminModulesController : Controller
    {
        private readonly GRP27ETutorContext _context;

        private readonly IHttpContextAccessor httpContextAccessor;

        public AdminModulesController(GRP27ETutorContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetModules()
        {
            List<User> users = new List<User>();
            List<Module> modules = new List<Module>();
            List<Course> courses = new List<Course>();
            List<AdminModules> adminModules = new List<AdminModules>();
            modules = _context.Modules.ToList();
            users = _context.Users.ToList();
            courses = _context.Courses.ToList();
            modules = modules.OrderByDescending(x => x.Id).ToList();
            for(var i = 0; i < modules.Count; i++)
            {
                User user = new User();
                Course course = new Course();
                for(var y = 0; y < users.Count; y++)
                {
                    if (users[y].UserId == modules[i].LectureId)
                    {
                        user = users[y];
                    }
                }
                for (var z = 0; z < courses.Count; z++)
                {
                    if (courses[z].Id== modules[i].CourseId)
                    {
                        course = courses[z];
                    }
                }
                adminModules.Add(new AdminModules
                {
                    Name = modules[i].Name,
                    Description = modules[i].Description,
                    Course = course.Name,
                    Lecture = user.Username
                });
            }

            return Ok(adminModules);
        }
    }
}
