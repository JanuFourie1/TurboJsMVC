using Microsoft.AspNetCore.Mvc;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class StudentClassController : Controller
    {
        private readonly GRP27ETutorContext _context;

        public StudentClassController(GRP27ETutorContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult StudentClass()
        {
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
