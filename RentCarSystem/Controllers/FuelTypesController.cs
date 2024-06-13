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
    public class FuelTypesController : Controller
    {
        private readonly RentCarSystemContext _context;

        public FuelTypesController(RentCarSystemContext context)
        {
            _context = context;
        }

        // GET: FuelTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FuelTypes.ToListAsync());
        }

        // GET: FuelTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelTypes = await _context.FuelTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fuelTypes == null)
            {
                return NotFound();
            }

            return View(fuelTypes);
        }

        // GET: FuelTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FuelTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,State")] FuelTypes fuelTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fuelTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fuelTypes);
        }

        // GET: FuelTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelTypes = await _context.FuelTypes.FindAsync(id);
            if (fuelTypes == null)
            {
                return NotFound();
            }
            return View(fuelTypes);
        }

        // POST: FuelTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,State")] FuelTypes fuelTypes)
        {
            if (id != fuelTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuelTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelTypesExists(fuelTypes.Id))
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
            return View(fuelTypes);
        }

        // GET: FuelTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelTypes = await _context.FuelTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fuelTypes == null)
            {
                return NotFound();
            }

            return View(fuelTypes);
        }

        // POST: FuelTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fuelTypes = await _context.FuelTypes.FindAsync(id);
            if (fuelTypes != null)
            {
                _context.FuelTypes.Remove(fuelTypes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuelTypesExists(int id)
        {
            return _context.FuelTypes.Any(e => e.Id == id);
        }
    }
}
