using Microsoft.AspNetCore.Mvc;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class StudentAssessmentController : Controller
    {
        private readonly GRP27ETutorContext _context;

        public StudentAssessmentController(GRP27ETutorContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Assessments.ToList();
            return View(result);
        }
    }
}
