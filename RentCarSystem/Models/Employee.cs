using System.ComponentModel.DataAnnotations;

namespace RentCarSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(11, ErrorMessage = "La cedula no puede tener más de 11 caracteres.")]
        public string IdentificationCard { get; set; }

        public WorkSchedule WorkSchedule { get; set; }

        public double CommissionPercentage { get; set; }

        public DateOnly StartDate { get; set; }

        public string State { get; set; }
    }

    public enum WorkSchedule
    {
        Morning,

        Evening,

        Nocturnal
    }
}