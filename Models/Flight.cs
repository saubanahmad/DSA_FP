using System;

namespace FlightBookingSystem.Models
{
    public class Flight
    {
        public int FlightID { get; set; }
        public string OriginCode { get; set; } = "";
        public string DestinationCode { get; set; } = "";
        public DateTime FlightDate { get; set; }
        public int DurationMinutes { get; set; }
        public decimal Price { get; set; }
        public int SeatsAvailable { get; set; }
        public int TotalSeats { get; set; }
        
        public string Status 
        { 
            get 
            {
                if (DateTime.Now > FlightDate.AddMinutes(DurationMinutes)) return "Completed";
                return "Scheduled";
            }
        }

        public override string ToString() => $"Flight {FlightID}: {OriginCode}->{DestinationCode} @ {FlightDate} (${Price})";
    }
}
