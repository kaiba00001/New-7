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
    public class StockTrackerLeadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StockTrackerLeadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StockTrackerLeads
        public async Task<IActionResult> Index()
        {
              return _context.StockTrackerLead != null ? 
                          View(await _context.StockTrackerLead.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.StockTrackerLead'  is null.");
        }

        // GET: StockTrackerLeads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StockTrackerLead == null)
            {
                return NotFound();
            }

            var stockTrackerLead = await _context.StockTrackerLead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockTrackerLead == null)
            {
                return NotFound();
            }

            return View(stockTrackerLead);
        }

        // GET: StockTrackerLeads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StockTrackerLeads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Item,Quantity")] StockTrackerLead stockTrackerLead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockTrackerLead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockTrackerLead);
        }

        // GET: StockTrackerLeads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StockTrackerLead == null)
            {
                return NotFound();
            }

            var stockTrackerLead = await _context.StockTrackerLead.FindAsync(id);
            if (stockTrackerLead == null)
            {
                return NotFound();
            }
            return View(stockTrackerLead);
        }

        // POST: StockTrackerLeads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Item,Quantity")] StockTrackerLead stockTrackerLead)
        {
            if (id != stockTrackerLead.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockTrackerLead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockTrackerLeadExists(stockTrackerLead.Id))
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
            return View(stockTrackerLead);
        }

        // GET: StockTrackerLeads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StockTrackerLead == null)
            {
                return NotFound();
            }

            var stockTrackerLead = await _context.StockTrackerLead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockTrackerLead == null)
            {
                return NotFound();
            }

            return View(stockTrackerLead);
        }

        // POST: StockTrackerLeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StockTrackerLead == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StockTrackerLead'  is null.");
            }
            var stockTrackerLead = await _context.StockTrackerLead.FindAsync(id);
            if (stockTrackerLead != null)
            {
                _context.StockTrackerLead.Remove(stockTrackerLead);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockTrackerLeadExists(int id)
        {
          return (_context.StockTrackerLead?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
