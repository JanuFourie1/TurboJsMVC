using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class LectureAssessmentsController : Controller
    {
        private readonly GRP27ETutorContext _context;

        public LectureAssessmentsController(GRP27ETutorContext context)
        {
            _context = context;
        }

        // GET: LectureAssessments
        public async Task<IActionResult> Index()
        {
              return View(await _context.Assessments.ToListAsync());
        }

        // GET: LectureAssessments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assessments == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assessment == null)
            {
                return NotFound();
            }

            return View(assessment);
        }

        // GET: LectureAssessments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LectureAssessments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModuleId,Title,QuestionOneQ,QuestionOneA,QuestionOneO,QuestionTwoQ,QuestionTwoA,QuestionTwoO,QuestionThreeQ,QuestionThreeA,QuestionThreeO,QuestionFourQ,QuestionFourA,QuestionFourO,QuestionFiveQ,QuestionFiveA,QuestionFiveO")] Assessment assessment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assessment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assessment);
        }

        // GET: LectureAssessments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assessments == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments.FindAsync(id);
            if (assessment == null)
            {
                return NotFound();
            }
            return View(assessment);
        }

        // POST: LectureAssessments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModuleId,Title,QuestionOneQ,QuestionOneA,QuestionOneO,QuestionTwoQ,QuestionTwoA,QuestionTwoO,QuestionThreeQ,QuestionThreeA,QuestionThreeO,QuestionFourQ,QuestionFourA,QuestionFourO,QuestionFiveQ,QuestionFiveA,QuestionFiveO")] Assessment assessment)
        {
            if (id != assessment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assessment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssessmentExists(assessment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(assessment);
        }

        // GET: LectureAssessments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Assessments == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assessment == null)
            {
                return NotFound();
            }

            return View(assessment);
        }

        // POST: LectureAssessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Assessments == null)
            {
                return Problem("Entity set 'GRP27ETutorContext.Assessments'  is null.");
            }
            var assessment = await _context.Assessments.FindAsync(id);
            if (assessment != null)
            {
                _context.Assessments.Remove(assessment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssessmentExists(int id)
        {
          return _context.Assessments.Any(e => e.Id == id);
        }
    }
}
