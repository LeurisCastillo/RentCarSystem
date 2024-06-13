using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentCarSystem.Data;
using RentCarSystem.Models;
using Rotativa.AspNetCore;

namespace RentCarSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly RentCarSystemContext _context;

        public ReportController(RentCarSystemContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.VehiculeTypes = new SelectList(await _context.VehiculeType.ToListAsync(), "Description", "Description");
            return View();
        }

        public IActionResult Create([Bind("Id,StartDate,EndDate,VehiculeType")] Report report)
        {
            var query = from rent in _context.RentAndDevolution
                        join vehicle in _context.Vehicule on rent.Vehicule.Id equals vehicle.Id
                        join vehicleType in _context.VehiculeType on vehicle.VehiculeType.Id equals vehicleType.Id into vehicleTypes
                        from vehicleType in vehicleTypes.DefaultIfEmpty()
                        where rent.RentDate >= report.StartDate && rent.RentDate <= report.EndDate
                              && vehicleType.Description == report.VehiculeType
                        select new Report
                        {
                            Id = rent.Id,
                            StartDate = rent.RentDate,
                            EndDate = rent.DevolutionDate,
                            VehiculeType = vehicleType.Description,
                        };

            var results = query.ToList();

            return new ViewAsPdf(results);
        }
    }
}