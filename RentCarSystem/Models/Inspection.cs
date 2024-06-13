namespace RentCarSystem.Models
{
    public class Inspection
    {
        public int Id { get; set; }

        public Vehicule Vehicule { get; set; }

        public Client Client { get; set; }

        public bool HasScratches { get; set; }

        public AmountOfFuel AmountOfFuel { get; set; }

        public bool HasReplacementWheel { get; set; }

        public bool HasHydraulicJack { get; set; }

        public bool HasBrokenGlass { get; set; }

        public bool WheelState1 { get; set; }

        public bool WheelState2 { get; set; }

        public bool WheelState3 { get; set; }

        public bool WheelState4 { get; set; }

        public DateOnly Date { get; set; }

        public Employee Employee { get; set; }

        public string State { get; set; }
    }

    public enum AmountOfFuel
    {
        Full,

        Half,

        Third,

        Quarter
    }
}