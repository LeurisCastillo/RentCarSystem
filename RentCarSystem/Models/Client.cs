using System.ComponentModel.DataAnnotations;

namespace RentCarSystem.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(11, ErrorMessage = "La cedula no puede tener más de 11 caracteres.")]
        public string IdentificationCard { get; set; }

        [StringLength(11, ErrorMessage = "La tarjeta de credito no puede tener más de 11 caracteres.")]
        public string CreditCardNumber { get; set; }

        public double CreditLimit { get; set; }

        public PersonType PersonType { get; set; }

        public string State { get; set; }
    }

    public enum PersonType
    {
        Physical,

        Legal
    }
}