namespace FlightBookingSystem.Models
{
    public class Airport
    {
        public string AirportCode { get; set; } = "";
        public string AirportName { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";

        public override string ToString() => $"{AirportCode} - {City} ({AirportName})";
    }
}
