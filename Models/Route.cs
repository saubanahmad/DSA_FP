namespace FlightBookingSystem.Models
{
    public class Route
    {
        public int RouteID { get; set; }
        public string OriginCode { get; set; } = "";
        public string DestinationCode { get; set; } = "";
        public int Distance { get; set; }
    }
}
