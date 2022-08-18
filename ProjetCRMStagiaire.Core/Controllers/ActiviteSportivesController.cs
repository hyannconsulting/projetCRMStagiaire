using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetCRMStagiaire.Core.Data;

namespace ProjetCRMStagiaire.Core.Controllers
{
    public class ActiviteSportivesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActiviteSportivesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActiviteSportives
        public async Task<IActionResult> Index()
        {
              return _context.ActiviteSportives != null ? 
                          View(await _context.ActiviteSportives.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ActiviteSportives'  is null.");
        }

        // GET: ActiviteSportives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ActiviteSportives == null)
            {
                return NotFound();
            }

            var activiteSportive = await _context.ActiviteSportives
                .FirstOrDefaultAsync(m => m.ActiviteSportiveId == id);
            if (activiteSportive == null)
            {
                return NotFound();
            }

            return View(activiteSportive);
        }

        // GET: ActiviteSportives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActiviteSportives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActiviteSportiveId,Nom,Description,NombreDePlace,Lieu")] ActiviteSportive activiteSportive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activiteSportive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activiteSportive);
        }

        // GET: ActiviteSportives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ActiviteSportives == null)
            {
                return NotFound();
            }

            var activiteSportive = await _context.ActiviteSportives.FindAsync(id);
            if (activiteSportive == null)
            {
                return NotFound();
            }
            return View(activiteSportive);
        }

        // POST: ActiviteSportives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActiviteSportiveId,Nom,Description,NombreDePlace,Lieu")] ActiviteSportive activiteSportive)
        {
            if (id != activiteSportive.ActiviteSportiveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activiteSportive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActiviteSportiveExists(activiteSportive.ActiviteSportiveId))
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
            return View(activiteSportive);
        }

        // GET: ActiviteSportives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ActiviteSportives == null)
            {
                return NotFound();
            }

            var activiteSportive = await _context.ActiviteSportives
                .FirstOrDefaultAsync(m => m.ActiviteSportiveId == id);
            if (activiteSportive == null)
            {
                return NotFound();
            }

            return View(activiteSportive);
        }

        // POST: ActiviteSportives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ActiviteSportives == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ActiviteSportives'  is null.");
            }
            var activiteSportive = await _context.ActiviteSportives.FindAsync(id);
            if (activiteSportive != null)
            {
                _context.ActiviteSportives.Remove(activiteSportive);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActiviteSportiveExists(int id)
        {
          return (_context.ActiviteSportives?.Any(e => e.ActiviteSportiveId == id)).GetValueOrDefault();
        }
    }
}
