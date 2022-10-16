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
                    Id = modules[i].Id,
                    Name = modules[i].Name,
                    Description = modules[i].Description,
                    Course = course.Name,
                    Lecture = user.Username
                });
            }
            SortModulesByName sortByName = new SortModulesByName();
            adminModules.Sort(sortByName);
            return Ok(adminModules);
        }

        public async Task<IActionResult> AddModule(Module module)
        {
            try
            {
                _context.Modules.Add(module);
                _context.SaveChanges();
                return RedirectToAction("Index", "AdminModules");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteModule(int moduleId)
        {
            try
            {
                Module module = _context.Modules.FirstOrDefault(x => x.Id == moduleId);
                _context.Modules.Remove(module);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetModule(int itemId)
        {
            var module = _context.Modules.FirstOrDefault(x => x.Id == itemId);
            return Ok(module);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateModule(int module, string description, string name, int course, int lecture)
        {
            Module item = _context.Modules.FirstOrDefault(m => m.Id == module);
            item.Name = name;
            item.Description = description;
            item.CourseId = course;
            item.LectureId = lecture;
            _context.Modules.Update(item);
            _context.SaveChanges();
            return Ok("Module updated");
        }
    }
}
