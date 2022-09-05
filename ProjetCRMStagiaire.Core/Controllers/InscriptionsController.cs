using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetCRMStagiaire.Core.Data;
using ProjetCRMStagiaire.Core.Models;

namespace ProjetCRMStagiaire.Core.Controllers
{
    [Authorize]
    public class InscriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InscriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inscriptions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Inscriptions.Include(i => i.Stagiaire);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Inscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inscriptions == null)
            {
                return NotFound();
            }

            var inscription = await _context.Inscriptions
                .Include(i => i.Stagiaire)
                .FirstOrDefaultAsync(m => m.InscriptionId == id);
            if (inscription == null)
            {
                return NotFound();
            }

            return View(inscription);
        }

        // GET: Inscriptions/Create
        public IActionResult Create()
        {


            ViewData["StagiaireId"] = new SelectList(_context.Users, "Id", "UserName");
            ViewData["ActiviteSportiveId"] = new SelectList(_context.ActiviteSportives, "ActiviteSportiveId", "Nom");
            return View();
        }


        // POST: Inscriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InscriptionId,ActiviteSportiveId,StagiaireId,DateInscription")] InscriptionViewModel inscription)
        {
            if (ModelState.IsValid)
            {

                var acsportive = _context.ActiviteSportives.FirstOrDefault(a => a.ActiviteSportiveId
                == inscription.ActiviteSportiveId);

                var inscpt = new Inscription
                {
                    IdActiviteSportive = inscription.ActiviteSportiveId,
                    DateInscription = inscription.DateInscription,
                    // InscriptionId = inscription.InscriptionId,
                    StagiaireId = inscription.StagiaireId,
                    ActiviteSportive = acsportive,
                };

                _context.Add(inscpt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StagiaireId"] = new SelectList(_context.Users, "Id", "Id", inscription.StagiaireId);
            return View(inscription);
        }

        // GET: Inscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inscriptions == null)
            {
                return NotFound();
            }

            var inscription = await _context.Inscriptions.FindAsync(id);
            if (inscription == null)
            {
                return NotFound();
            }
            ViewData["StagiaireId"] = new SelectList(_context.Users, "Id", "Id", inscription.StagiaireId);
            return View(inscription);
        }

        // POST: Inscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InscriptionId,IdActiviteSportive,StagiaireId,DateInscription")] Inscription inscription)
        {
            if (id != inscription.InscriptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscriptionExists(inscription.InscriptionId))
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
            ViewData["StagiaireId"] = new SelectList(_context.Users, "Id", "Id", inscription.StagiaireId);
            return View(inscription);
        }

        // GET: Inscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inscriptions == null)
            {
                return NotFound();
            }

            var inscription = await _context.Inscriptions
                .Include(i => i.Stagiaire)
                .FirstOrDefaultAsync(m => m.InscriptionId == id);
            if (inscription == null)
            {
                return NotFound();
            }

            return View(inscription);
        }

        // POST: Inscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inscriptions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Inscriptions'  is null.");
            }
            var inscription = await _context.Inscriptions.FindAsync(id);
            if (inscription != null)
            {
                _context.Inscriptions.Remove(inscription);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscriptionExists(int id)
        {
            return (_context.Inscriptions?.Any(e => e.InscriptionId == id)).GetValueOrDefault();
        }
    }
}
