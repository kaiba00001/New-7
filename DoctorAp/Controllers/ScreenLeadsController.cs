using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoctorAp.Data;
using DoctorAp.Models;

namespace DoctorAp.Controllers
{
    public class ScreenLeadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScreenLeadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ScreenLeads
        public async Task<IActionResult> Index()
        {
              return _context.ScreenLead_1 != null ? 
                          View(await _context.ScreenLead_1.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ScreenLead_1'  is null.");
        }

        // GET: ScreenLeads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ScreenLead_1 == null)
            {
                return NotFound();
            }

            var screenLead = await _context.ScreenLead_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (screenLead == null)
            {
                return NotFound();
            }

            return View(screenLead);
        }

        // GET: ScreenLeads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScreenLeads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,weight,temparture,description")] ScreenLead screenLead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(screenLead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(screenLead);
        }

        // GET: ScreenLeads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ScreenLead_1 == null)
            {
                return NotFound();
            }

            var screenLead = await _context.ScreenLead_1.FindAsync(id);
            if (screenLead == null)
            {
                return NotFound();
            }
            return View(screenLead);
        }

        // POST: ScreenLeads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,weight,temparture,description")] ScreenLead screenLead)
        {
            if (id != screenLead.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(screenLead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScreenLeadExists(screenLead.Id))
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
            return View(screenLead);
        }

        // GET: ScreenLeads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ScreenLead_1 == null)
            {
                return NotFound();
            }

            var screenLead = await _context.ScreenLead_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (screenLead == null)
            {
                return NotFound();
            }

            return View(screenLead);
        }

        // POST: ScreenLeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ScreenLead_1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ScreenLead_1'  is null.");
            }
            var screenLead = await _context.ScreenLead_1.FindAsync(id);
            if (screenLead != null)
            {
                _context.ScreenLead_1.Remove(screenLead);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScreenLeadExists(int id)
        {
          return (_context.ScreenLead_1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
