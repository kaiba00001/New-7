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
    public class LabResultsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LabResultsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LabResults
        public async Task<IActionResult> Index()
        {
              return _context.LabResult != null ? 
                          View(await _context.LabResult.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.LabResult'  is null.");
        }

        // GET: LabResults/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.LabResult == null)
            {
                return NotFound();
            }

            var labResult = await _context.LabResult
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labResult == null)
            {
                return NotFound();
            }

            return View(labResult);
        }

        // GET: LabResults/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LabResults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientName,TestType,Result,ReferenceRange")] LabResult labResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labResult);
        }

        // GET: LabResults/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.LabResult == null)
            {
                return NotFound();
            }

            var labResult = await _context.LabResult.FindAsync(id);
            if (labResult == null)
            {
                return NotFound();
            }
            return View(labResult);
        }

        // POST: LabResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,PatientName,TestType,Result,ReferenceRange")] LabResult labResult)
        {
            if (id != labResult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabResultExists(labResult.Id))
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
            return View(labResult);
        }

        // GET: LabResults/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.LabResult == null)
            {
                return NotFound();
            }

            var labResult = await _context.LabResult
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labResult == null)
            {
                return NotFound();
            }

            return View(labResult);
        }

        // POST: LabResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.LabResult == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LabResult'  is null.");
            }
            var labResult = await _context.LabResult.FindAsync(id);
            if (labResult != null)
            {
                _context.LabResult.Remove(labResult);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabResultExists(string id)
        {
          return (_context.LabResult?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
