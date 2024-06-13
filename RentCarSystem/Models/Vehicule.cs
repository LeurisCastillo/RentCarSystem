using System.ComponentModel.DataAnnotations;

namespace RentCarSystem.Models
{
    public class Vehicule
    {
        public int Id { get; set; }

        public string Description { get; set; }

        [StringLength(17, ErrorMessage = "El numero de chasis no puede tener ni más ni menos de 17 caracteres.", MinimumLength = 17)]
        public string ChasisNumber { get; set; }

        [StringLength(17, ErrorMessage = "El numero de chasis no puede tener ni más ni menos de 17 caracteres.", MinimumLength = 17)]
        public string MotorNumber { get; set; }

        [StringLength(8, ErrorMessage = "El numero de chasis no puede tener ni más ni menos de 8 caracteres.", MinimumLength = 8)]
        public string PlateNumber { get; set; }

        public VehiculeType VehiculeType { get; set; }

        public Brand Brand { get; set; }

        public VehiculeModel VehiculeModel { get; set; }

        public FuelTypes FuelTypes { get; set; }

        public bool IsRented { get; set; } = false;

        public string State { get; set; }
    }
}