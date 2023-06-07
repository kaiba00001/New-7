using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoctorAp.Data;
using DoctorAp.Models.DoctorAp.Models;

namespace DoctorAp.Controllers
{
    public class EmployeePayrollsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeePayrollsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeePayrolls
        public async Task<IActionResult> Index()
        {
            return _context.EmployeePayroll != null ?
                        View(await _context.EmployeePayroll.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.EmployeePayroll'  is null.");
        }

        // GET: EmployeePayrolls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeePayroll == null)
            {
                return NotFound();
            }

            var employeePayroll = await _context.EmployeePayroll
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeePayroll == null)
            {
                return NotFound();
            }

            return View(employeePayroll);
        }

        // GET: EmployeePayrolls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeePayrolls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,EmployeeName,HourlyRate,HoursWorked,TaxWithholdingRate")] EmployeePayroll employeePayroll)
        {
            if (ModelState.IsValid)
            {
                employeePayroll.NetPay = employeePayroll.CalculateNetPay(); // Calculate the NetPay

                _context.Add(employeePayroll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeePayroll);
        }

        // GET: EmployeePayrolls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeePayroll == null)
            {
                return NotFound();
            }

            var employeePayroll = await _context.EmployeePayroll.FindAsync(id);
            if (employeePayroll == null)
            {
                return NotFound();
            }
            return View(employeePayroll);
        }

        // POST: EmployeePayrolls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,EmployeeName,HourlyRate,HoursWorked,TaxWithholdingRate,NetPay")] EmployeePayroll employeePayroll)
        {
            if (id != employeePayroll.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeePayroll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeePayrollExists(employeePayroll.Id))
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
            return View(employeePayroll);
        }

        // GET: EmployeePayrolls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeePayroll == null)
            {
                return NotFound();
            }

            var employeePayroll = await _context.EmployeePayroll
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeePayroll == null)
            {
                return NotFound();
            }

            return View(employeePayroll);
        }

        // POST: EmployeePayrolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeePayroll == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EmployeePayroll'  is null.");
            }
            var employeePayroll = await _context.EmployeePayroll.FindAsync(id);
            if (employeePayroll != null)
            {
                _context.EmployeePayroll.Remove(employeePayroll);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeePayrollExists(int id)
        {
            return (_context.EmployeePayroll?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}