using System;
using FlightBookingSystem.Core.DataStructures;

namespace FlightBookingSystem.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public string PNR { get; set; } = ""; 
        public int FlightID { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; } = "Confirmed";
        
        // Navigation Properties
        public Flight? FlightDetails { get; set; }
        public MyLinkedList<Passenger> PassengerList { get; set; } = new MyLinkedList<Passenger>();
    }
}
