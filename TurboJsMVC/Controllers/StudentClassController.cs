using Microsoft.AspNetCore.Mvc;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class StudentClassController : Controller
    {
        private readonly GRP27ETutorContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public StudentClassController(GRP27ETutorContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult StudentClass()
        {
            var username = HttpContext.Session.GetString("Username") ?? "";
            ViewBag.Username = username;
            ViewData["Classes"] = GetClasses();
            ViewData["Modules"] = GetModules();
            return View();
        }

        public List<Class> GetClasses()
        {
            List<Class> classes = new List<Class>(_context.Classes);
            return classes;
        }
        private List<Module> GetModules()
        {
            List<Module> modules = new List<Module>(_context.Modules);
            return modules;
        }
        public List<User> GetLecturers()
        {   
            List<User> lecturers = new List<User>(_context.Users);
            return lecturers;
        }
    }
}
