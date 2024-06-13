using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentCarSystem.Data;
using RentCarSystem.Models;

namespace RentCarSystem.Controllers
{
    public class RentAndDevolutionsController : Controller
    {
        private readonly RentCarSystemContext _context;

        public RentAndDevolutionsController(RentCarSystemContext context)
        {
            _context = context;
        }

        // GET: RentAndDevolutions
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentAndDevolution.ToListAsync());
        }

        // GET: RentAndDevolutions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentAndDevolution = await _context.RentAndDevolution
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentAndDevolution == null)
            {
                return NotFound();
            }

            return View(rentAndDevolution);
        }

        // GET: RentAndDevolutions/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Vehicules = new SelectList(await _context.Vehicule.ToListAsync(), "Id", "Description");
            ViewBag.Employees = new SelectList(await _context.Employee.ToListAsync(), "Id", "Name");
            ViewBag.Client = new SelectList(await _context.Client.ToListAsync(), "Id", "Name");

            return View();
        }

        // POST: RentAndDevolutions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RentDate,DevolutionDate,AmountPerDay,NumberOfDays,Comments,State")] RentAndDevolution rentAndDevolution, int Employee, int Vehicule, int Client)
        {
            if (ModelState.IsValid)
            {
                rentAndDevolution.Vehicule = await _context.Vehicule.FindAsync(Vehicule);
                rentAndDevolution.Employee = await _context.Employee.FindAsync(Employee);
                rentAndDevolution.Client = await _context.Client.FindAsync(Client);
                _context.Add(rentAndDevolution);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Rents");
            }
            return RedirectToAction("Index");
        }

        // GET: RentAndDevolutions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentAndDevolution = await _context.RentAndDevolution.FindAsync(id);
            if (rentAndDevolution == null)
            {
                return NotFound();
            }
            return View(rentAndDevolution);
        }

        // POST: RentAndDevolutions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RentDate,DevolutionDate,AmountPerDay,NumberOfDays,Comments,State")] RentAndDevolution rentAndDevolution)
        {
            if (id != rentAndDevolution.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentAndDevolution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentAndDevolutionExists(rentAndDevolution.Id))
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
            return View(rentAndDevolution);
        }

        // GET: RentAndDevolutions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentAndDevolution = await _context.RentAndDevolution
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentAndDevolution == null)
            {
                return NotFound();
            }

            return View(rentAndDevolution);
        }

        // POST: RentAndDevolutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentAndDevolution = await _context.RentAndDevolution.FindAsync(id);
            if (rentAndDevolution != null)
            {
                _context.RentAndDevolution.Remove(rentAndDevolution);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentAndDevolutionExists(int id)
        {
            return _context.RentAndDevolution.Any(e => e.Id == id);
        }
    }
}