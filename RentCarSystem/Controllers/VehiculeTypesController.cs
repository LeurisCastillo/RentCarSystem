using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentCarSystem.Data;
using RentCarSystem.Models;

namespace RentCarSystem.Controllers
{
    public class VehiculeTypesController : Controller
    {
        private readonly RentCarSystemContext _context;

        public VehiculeTypesController(RentCarSystemContext context)
        {
            _context = context;
        }

        // GET: VehiculeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehiculeType.ToListAsync());
        }

        // GET: VehiculeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculeType = await _context.VehiculeType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculeType == null)
            {
                return NotFound();
            }

            return View(vehiculeType);
        }

        // GET: VehiculeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiculeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,State")] VehiculeType vehiculeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculeType);
        }

        // GET: VehiculeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculeType = await _context.VehiculeType.FindAsync(id);
            if (vehiculeType == null)
            {
                return NotFound();
            }
            return View(vehiculeType);
        }

        // POST: VehiculeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,State")] VehiculeType vehiculeType)
        {
            if (id != vehiculeType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculeTypeExists(vehiculeType.Id))
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
            return View(vehiculeType);
        }

        // GET: VehiculeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculeType = await _context.VehiculeType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculeType == null)
            {
                return NotFound();
            }

            return View(vehiculeType);
        }

        // POST: VehiculeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculeType = await _context.VehiculeType.FindAsync(id);
            if (vehiculeType != null)
            {
                _context.VehiculeType.Remove(vehiculeType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculeTypeExists(int id)
        {
            return _context.VehiculeType.Any(e => e.Id == id);
        }
    }
}
