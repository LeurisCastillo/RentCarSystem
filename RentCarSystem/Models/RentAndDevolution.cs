using System.ComponentModel.DataAnnotations;

namespace RentCarSystem.Models
{
    public class RentAndDevolution
    {
        public int Id { get; set; }

        public Employee Employee { get; set; }

        public Vehicule Vehicule { get; set; }

        public Client Client { get; set; }

        public DateOnly RentDate { get; set; }

        public DateOnly DevolutionDate { get; set; } = DateOnly.MinValue;

        [Range(0, double.MaxValue, ErrorMessage = "El campo AmountPerDay debe ser un valor positivo.")]
        public double AmountPerDay { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El campo NumberOfDays debe ser un valor positivo.")]
        public int NumberOfDays { get; set; }

        public string Comments { get; set; }

        public string State { get; set; }
    }
}