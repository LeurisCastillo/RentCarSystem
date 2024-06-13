using Microsoft.EntityFrameworkCore;
using RentCarSystem.Models;

namespace RentCarSystem.Data
{
    public class RentCarSystemContext : DbContext
    {
        public RentCarSystemContext(DbContextOptions<RentCarSystemContext> options)
            : base(options)
        {
        }

        public DbSet<Inspection> Inspection { get; set; }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<Client> Client { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<FuelTypes> FuelTypes { get; set; }

        public DbSet<RentAndDevolution> RentAndDevolution { get; set; }

        public DbSet<Vehicule> Vehicule { get; set; }

        public DbSet<VehiculeModel> VehiculeModel { get; set; }

        public DbSet<VehiculeType> VehiculeType { get; set; }
        public DbSet<RentCarSystem.Models.Report> Report { get; set; }
    }
}