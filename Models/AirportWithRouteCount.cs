namespace FlightBookingSystem.Models
{
    /// Represents an Airport with its route count for management grid.
    public class AirportWithRouteCount
    {
        public string AirportCode { get; set; } = "";
        public string AirportName { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        public int RouteCount { get; set; }
    }
}
