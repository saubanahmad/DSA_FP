using System;

namespace FlightBookingSystem.Models
{
    /// Represents a Flight Edge between two Airport Nodes.
    public class FlightEdge
    {
        public AirportNode From { get; set; }
        public AirportNode To { get; set; }
        public int Distance { get; set; }
        public decimal Price { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public FlightStatus Status { get; set; }
        public string FlightCode { get; set; }
        public int TotalBookings { get; set; }

        public FlightEdge(AirportNode from, AirportNode to, decimal price, DateTime depTime, DateTime arrTime, FlightStatus status, string flightCode)
        {
            From = from;
            To = to;
            Distance = 0;
            Price = price;
            DepartureTime = depTime;
            ArrivalTime = arrTime;
            Status = status;
            FlightCode = flightCode ?? "";
            TotalBookings = 0; // Default
        }
    }
}
