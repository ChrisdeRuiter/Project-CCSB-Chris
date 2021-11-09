using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_CCSB.Models;

namespace Project_CCSB.Controllers
{
    public class Appointments1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Appointments1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appointments1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Appointments.ToListAsync());
        }

        // GET: Appointments1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointments = await _context.Appointments
                .FirstOrDefaultAsync(m => m.OphalenId == id);
            if (appointments == null)
            {
                return NotFound();
            }

            return View(appointments);
        }

        // GET: Appointments1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appointments1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OphalenId,AppointmentId,TimeAndMoment,Action")] Appointments appointments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appointments);
        }

        // GET: Appointments1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointments = await _context.Appointments.FindAsync(id);
            if (appointments == null)
            {
                return NotFound();
            }
            return View(appointments);
        }

        // POST: Appointments1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OphalenId,AppointmentId,TimeAndMoment,Action")] Appointments appointments)
        {
            if (id != appointments.OphalenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentsExists(appointments.OphalenId))
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
            return View(appointments);
        }

        // GET: Appointments1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointments = await _context.Appointments
                .FirstOrDefaultAsync(m => m.OphalenId == id);
            if (appointments == null)
            {
                return NotFound();
            }

            return View(appointments);
        }

        // POST: Appointments1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var appointments = await _context.Appointments.FindAsync(id);
            _context.Appointments.Remove(appointments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentsExists(string id)
        {
            return _context.Appointments.Any(e => e.OphalenId == id);
        }
    }
}
