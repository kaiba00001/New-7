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
    public class ItemsLeadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsLeadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemsLeads
        public async Task<IActionResult> Index()
        {
              return _context.ItemsLead != null ? 
                          View(await _context.ItemsLead.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ItemsLead'  is null.");
        }

        // GET: ItemsLeads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemsLead == null)
            {
                return NotFound();
            }

            var itemsLead = await _context.ItemsLead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemsLead == null)
            {
                return NotFound();
            }

            return View(itemsLead);
        }

        // GET: ItemsLeads/Create
        public IActionResult Create()
        {
            var items = new List<SelectListItem>
    {
        new SelectListItem { Value = "Concerta", Text = "Concerta" },
        new SelectListItem { Value = "Advil", Text = "Advil" },
        new SelectListItem { Value = "Amoxicillin", Text = "Amoxicillin" },
        new SelectListItem { Value = "Aspirin", Text = "Aspirin" },
        new SelectListItem { Value = "Benadryl", Text = "Benadryl" },
        new SelectListItem { Value = "Ciprofloxacin", Text = "Ciprofloxacin" }
        // Add more items as needed
    };

            ViewBag.Items = items;

            return View();
        }
        // POST: ItemsLeads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Item,Quantity,CostPerItem")] ItemsLead itemsLead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemsLead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemsLead);
        }

        // GET: ItemsLeads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemsLead == null)
            {
                return NotFound();
            }

            var itemsLead = await _context.ItemsLead.FindAsync(id);
            if (itemsLead == null)
            {
                return NotFound();
            }
            return View(itemsLead);
        }

        // POST: ItemsLeads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Item,Quantity,CostPerItem")] ItemsLead itemsLead)
        {
            if (id != itemsLead.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemsLead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemsLeadExists(itemsLead.Id))
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
            return View(itemsLead);
        }

        // GET: ItemsLeads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemsLead == null)
            {
                return NotFound();
            }

            var itemsLead = await _context.ItemsLead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemsLead == null)
            {
                return NotFound();
            }

            return View(itemsLead);
        }

        // POST: ItemsLeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemsLead == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ItemsLead'  is null.");
            }
            var itemsLead = await _context.ItemsLead.FindAsync(id);
            if (itemsLead != null)
            {
                _context.ItemsLead.Remove(itemsLead);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemsLeadExists(int id)
        {
          return (_context.ItemsLead?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
