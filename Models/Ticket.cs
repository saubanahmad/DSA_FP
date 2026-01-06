namespace FlightBookingSystem.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public string TicketNumber { get; set; } = "";
        public int BookingID { get; set; }
        public int PassengerID { get; set; }
        public string SeatNumber { get; set; } = "";
    }
}
