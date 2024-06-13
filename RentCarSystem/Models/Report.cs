namespace RentCarSystem.Models
{
    public class Report
    {
        public int Id { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string VehiculeType { get; set; }
    }
}