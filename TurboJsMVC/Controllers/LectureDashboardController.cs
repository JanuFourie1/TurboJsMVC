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
        public IActionResult LectureDashboard()
        {
           
            IEnumerable<Module> modules = _context.Modules;
            return View(modules);
        }
        
    }
}
