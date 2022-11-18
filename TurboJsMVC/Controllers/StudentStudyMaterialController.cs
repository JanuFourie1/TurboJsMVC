using Microsoft.AspNetCore.Mvc;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class StudentStudyMaterialController : Controller
    {
        private readonly GRP27ETutorContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public StudentStudyMaterialController(GRP27ETutorContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("Username") ?? "";
            ViewBag.Username = username;
            return View();
        }
    }
}
