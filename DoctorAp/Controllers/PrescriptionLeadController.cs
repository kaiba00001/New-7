using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoctorAp.Data;
using DoctorAp.Models;
using Microsoft.AspNetCore.Authorization;

namespace DoctorAp.Controllers
{
    
    public class PrescriptionLeadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrescriptionLeadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PrescriptionLead
        public async Task<IActionResult> Index()
        {
            return _context.PrescriptionLead != null ?
                        View(await _context.PrescriptionLead.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.PrescriptionLead'  is null.");
        }

        // GET: PrescriptionLead/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.PrescriptionLead == null)
            {
                return NotFound();
            }

            var prescriptionLead = await _context.PrescriptionLead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescriptionLead == null)
            {
                return NotFound();
            }

            return View(prescriptionLead);
        }

        // GET: PrescriptionLead/Create
        [Authorize(Roles = "Doctor ,Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrescriptionLead/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Patient_Name,Doctor_Name,Medication,Dosage,Instructions")] PrescriptionLead prescriptionLead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescriptionLead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prescriptionLead);
        }

        // GET: PrescriptionLead/Edit/5
        [Authorize(Roles = "Doctor ,Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.PrescriptionLead == null)
            {
                return NotFound();
            }

            var prescriptionLead = await _context.PrescriptionLead.FindAsync(id);
            if (prescriptionLead == null)
            {
                return NotFound();
            }
            return View(prescriptionLead);
        }

        // POST: PrescriptionLead/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Patient_Name,Doctor_Name,Medication,Dosage,Instructions")] PrescriptionLead prescriptionLead)
        {
            if (id != prescriptionLead.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescriptionLead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescriptionLeadExists(prescriptionLead.Id))
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
            return View(prescriptionLead);
        }

        [Authorize(Roles = "Doctor ,Admin")]
        // GET: PrescriptionLead/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.PrescriptionLead == null)
            {
                return NotFound();
            }

            var prescriptionLead = await _context.PrescriptionLead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescriptionLead == null)
            {
                return NotFound();
            }

            return View(prescriptionLead);
        }

        // POST: PrescriptionLead/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.PrescriptionLead == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PrescriptionLead'  is null.");
            }
            var prescriptionLead = await _context.PrescriptionLead.FindAsync(id);
            if (prescriptionLead != null)
            {
                _context.PrescriptionLead.Remove(prescriptionLead);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescriptionLeadExists(string id)
        {
            return (_context.PrescriptionLead?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}