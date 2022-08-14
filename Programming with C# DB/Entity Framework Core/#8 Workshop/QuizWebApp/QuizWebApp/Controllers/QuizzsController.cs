using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quiz.Core.Contracts;
using Quiz.Core.Models;
using Quiz.Infrastructure.Data;
using Quiz.Infrastructure.Data.Models;

namespace QuizWebApp.Controllers
{
    public class QuizzsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IQuizServices service;

        public QuizzsController(ApplicationDbContext context, IQuizServices quizServices)
        {
            _context = context;
            service = quizServices;
        }

        // GET: Quizzs
        public async Task<IActionResult> Index()
        {
            return View(await service.GetQuizzesAsync());
        }

        // GET: Quizzs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Quizzes == null)
            {
                return NotFound();
            }

            var quizz = await _context.Quizzes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizz == null)
            {
                return NotFound();
            }

            return View(quizz);
        }

        // GET: Quizzs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quizzs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] QuizViewModel quizz)
        {
            if (ModelState.IsValid)
            {
                await service.CreateQuizAsync(quizz);
                return RedirectToAction(nameof(Index));
            }
            return View(quizz);
        }

        // GET: Quizzs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizz = await service.GetQuizzAsync(id ?? 0);
            if (quizz == null)
            {
                return NotFound();
            }
            return View(quizz);
        }

        // POST: Quizzs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] QuizViewModel quizz)
        {
            if (id != quizz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await service.EditQuizzAsync(quizz);
                }
                catch(ArgumentException ae)
                {
                    return NotFound();
                }
              
                return RedirectToAction(nameof(Index));
            }
            return View(quizz);
        }

        // GET: Quizzs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Quizzes == null)
            {
                return NotFound();
            }

            var quizz = await _context.Quizzes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizz == null)
            {
                return NotFound();
            }

            return View(quizz);
        }

        // POST: Quizzs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Quizzes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Quizzes'  is null.");
            }
            var quizz = await _context.Quizzes.FindAsync(id);
            if (quizz != null)
            {
                _context.Quizzes.Remove(quizz);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizzExists(int id)
        {
            return (_context.Quizzes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
