using Microsoft.AspNetCore.Mvc;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class LectureDashboardController : Controller
    {
        private readonly GRP27ETutorContext _context;

        public LectureDashboardController(GRP27ETutorContext context)
        {
            _context = context;
            
        }
        public IActionResult LecturerDashboard()
        {
            ViewData["Users"] = GetUsers();
            ViewData["Courses"] = GetModules();
            return View();
        }
        private List<User> GetUsers()
        {
            List<User> users = new List<User>(_context.Users);
            return users;
        }
        public List<Module> GetModules()
        {
            List<Module> modules = new List<Module>(_context.Modules);
            return modules;
        }
    }
}
