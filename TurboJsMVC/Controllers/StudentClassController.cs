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
            return View();
        }

        public List<Class> GetClasses()
        {
            List<Class> classes = new List<Class>(_context.Classes);
            return classes;
        }
    }
}
