using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarSystem.Data;
using RentCarSystem.Models;

namespace RentCarSystem.Controllers
{
    public class RentsController : Controller
    {
        private readonly RentCarSystemContext _context;

        public RentsController(RentCarSystemContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.Vehicule.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicule = await _context.Vehicule.FirstOrDefaultAsync(m => m.Id == id);
            if (vehicule == null)
            {
                return NotFound();
            }

            return View(vehicule);
        }

        public async Task<IActionResult> CheckRentedVehicules(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicule = await _context.Vehicule.FindAsync(id);
            if (vehicule == null)
            {
                return NotFound();
            }

            if (!vehicule.IsRented)
            {
                _context.Entry(vehicule).Property(p => p.IsRented).IsModified = true;

                vehicule.IsRented = true;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Create", "Inspections");
        }

        public async Task<IActionResult> MyRent()
        {
            var rents = await _context.RentAndDevolution.ToListAsync();
            List<RentAndDevolution> returnedVehicules = ValidateReturnedVehicules2(rents);

            return View(returnedVehicules);
        }

        private static List<RentAndDevolution> ValidateReturnedVehicules2(List<RentAndDevolution> rents)
        {
            var rents2 = new List<RentAndDevolution>();
            foreach (var rent in rents)
            {
                if (rent.DevolutionDate == DateOnly.MinValue)
                {
                    rents2.Add(rent);
                }
            }

            return rents2;
        }

        public async Task<IActionResult> ReturnCar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _context.RentAndDevolution.FirstAsync(m => m.Id == id);
            if (rent == null)
            {
                return NotFound();
            }

            var query = from renta in _context.RentAndDevolution
                        where renta.Id == id
                        select new
                        {
                            VehiculoId = renta.Vehicule.Id,
                            VehiculoDescription = renta.Vehicule.Description,
                            VehiculoChasisNumber = renta.Vehicule.ChasisNumber,
                            VehiculoPlateNumber = renta.Vehicule.PlateNumber,
                            IsVehiculoRented = renta.Vehicule.IsRented,
                            VehiculoState = renta.Vehicule.State
                        };

            var resultado = query.FirstOrDefault();

            var vehicule = await _context.Vehicule.FindAsync(resultado.VehiculoId);
            _context.Entry(vehicule).Property(p => p.IsRented).IsModified = true;

            vehicule.IsRented = false;

            rent.DevolutionDate = DateOnly.Parse(DateTime.Now.ToString("MM-dd-yyyy"));

            _context.Update(rent);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}