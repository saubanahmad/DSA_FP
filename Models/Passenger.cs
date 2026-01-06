namespace FlightBookingSystem.Models
{
    public class Passenger
    {
        public int PassengerID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public string PassportNumber { get; set; } = "";
        public string Email { get; set; } = "";

        public string FullName => $"{FirstName} {LastName}";
    }
}
