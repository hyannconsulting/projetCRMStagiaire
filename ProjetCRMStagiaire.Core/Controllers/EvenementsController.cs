using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetCRMStagiaire.Core.Data;
using ProjetCRMStagiaire.Core.Models;

namespace ProjetCRMStagiaire.Core.Controllers
{
    //[Authorize]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class EvenementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EvenementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Evenements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Evenements
                .Include(e => e.ActiviteSportives);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Evenements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Evenements == null)
            {
                return NotFound();
            }

            var evenements = await _context.Evenements
                .Include(e => e.ActiviteSportives)
                .FirstOrDefaultAsync(m => m.EvenementId == id);
            if (evenements == null)
            {
                return NotFound();
            }

            return View(evenements);
        }

        /// <summary>
        /// /GET: Evenements/Create
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewData["ActiviteSportiveId"] = new SelectList(_context.ActiviteSportives, "ActiviteSportiveId", "Nom");

            return View();
        }



        // POST: Evenements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvenementId,ActiviteSportiveId,DateEvenement")] EvenementViewModel evenements)
        {

            if (ModelState.IsValid)
            {

                var activite = _context.ActiviteSportives
                      .FirstOrDefault(a => a.ActiviteSportiveId == evenements.ActiviteSportiveId);

                var newevent = new Evenements
                {
                    ActiviteSportiveId = evenements.ActiviteSportiveId,
                    DateEvenement = evenements.DateEvenement,
                    EvenementId = evenements.EvenementId,
                    ActiviteSportives = activite

                };

                _context.Add(newevent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActiviteSportiveId"] = new SelectList(_context.ActiviteSportives, "ActiviteSportiveId", "Nom", evenements.ActiviteSportiveId);
            return View(evenements);
        }

        // GET: Evenements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Evenements == null)
            {
                return NotFound();
            }

            var evenements = await _context.Evenements.FindAsync(id);
            if (evenements == null)
            {
                return NotFound();
            }
            ViewData["ActiviteSportiveId"] = new SelectList(_context.ActiviteSportives, "ActiviteSportiveId", "Nom", evenements.ActiviteSportiveId);
            return View(evenements);
        }

        // POST: Evenements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvenementId,ActiviteSportiveId,DateEvenement")] Evenements evenements)
        {
            if (id != evenements.EvenementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evenements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvenementsExists(evenements.EvenementId))
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
            ViewData["ActiviteSportiveId"] = new SelectList(_context.ActiviteSportives, "ActiviteSportiveId", "Nom", evenements.ActiviteSportiveId);
            return View(evenements);
        }

        // GET: Evenements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Evenements == null)
            {
                return NotFound();
            }

            var evenements = await _context.Evenements
                .Include(e => e.ActiviteSportives)
                .FirstOrDefaultAsync(m => m.EvenementId == id);
            if (evenements == null)
            {
                return NotFound();
            }

            return View(evenements);
        }

        // POST: Evenements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Evenements == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Evenements'  is null.");
            }
            var evenements = await _context.Evenements.FindAsync(id);
            if (evenements != null)
            {
                _context.Evenements.Remove(evenements);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvenementsExists(int id)
        {
            return (_context.Evenements?.Any(e => e.EvenementId == id)).GetValueOrDefault();
        }
    }
}
