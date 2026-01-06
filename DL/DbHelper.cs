using System;
using MySql.Data.MySqlClient;
using FlightBookingSystem.Models;
using FlightBookingSystem.Core.DataStructures;
using FlightBookingSystem.Services;

namespace FlightBookingSystem.Data
{
    public static class DbHelper
    {
        private static string connString = "Server=localhost;Database=FlightBookingDB;Uid=root;Pwd=root";

        public static string ConnectionString => connString;

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }
        public static void UpdateFlightStatuses()
        {
        }

        public static MyLinkedList<Airport> LoadAirports()
        {
            var list = new MyLinkedList<Airport>();
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Airports";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.AddLast(new Airport
                        {
                            AirportCode = reader.GetString("AirportCode"),
                            AirportName = reader.GetString("AirportName"),
                            City = reader.GetString("City"),
                            Country = reader.GetString("Country")
                        });
                    }
                }
            }
            return list;
        }

        public static MyLinkedList<Route> LoadRoutes()
        {
            var list = new MyLinkedList<Route>();
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Routes";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.AddLast(new Route
                        {
                            RouteID = reader.GetInt32("RouteID"),
                            OriginCode = reader.GetString("OriginCode"),
                            DestinationCode = reader.GetString("DestinationCode"),
                            Distance = reader.GetInt32("Distance")
                        });
                    }
                }
            }
            return list;
        }

        public static MyLinkedList<Flight> LoadFlights()
        {
            var list = new MyLinkedList<Flight>();
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Flights"; 
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.AddLast(new Flight
                        {
                            FlightID = reader.GetInt32("FlightID"),
                            OriginCode = reader.GetString("OriginCode"),
                            DestinationCode = reader.GetString("DestinationCode"),
                            FlightDate = reader.GetDateTime("FlightDate"),
                            DurationMinutes = reader.GetInt32("DurationMinutes"),
                            Price = reader.GetDecimal("Price"),
                            SeatsAvailable = reader.GetInt32("SeatsAvailable"),
                            TotalSeats = reader.GetInt32("TotalSeats")
                            // Status is derived in class
                        });
                    }
                }
            }
            return list;
        }
        public static MyLinkedList<Booking> LoadAllBookings()
        {
            var bookings = new MyLinkedList<Booking>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT b.BookingID, b.PNR, b.FlightID, b.BookingDate, b.Status,
                           f.OriginCode, f.DestinationCode, f.FlightDate, f.DurationMinutes, f.Price, f.TotalSeats
                    FROM bookings b
                    INNER JOIN flights f ON b.FlightID = f.FlightID
                    ORDER BY b.BookingDate DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Booking booking = new Booking
                        {
                            BookingID = reader.GetInt32("BookingID"),
                            PNR = reader.GetString("PNR"),
                            FlightID = reader.GetInt32("FlightID"),
                            BookingDate = reader.GetDateTime("BookingDate"),
                            Status = reader.GetString("Status"),
                            FlightDetails = new Flight
                            {
                                FlightID = reader.GetInt32("FlightID"),
                                OriginCode = reader.GetString("OriginCode"),
                                DestinationCode = reader.GetString("DestinationCode"),
                                FlightDate = reader.GetDateTime("FlightDate"),
                                DurationMinutes = reader.GetInt32("DurationMinutes"),
                                Price = reader.GetDecimal("Price"),
                                TotalSeats = reader.GetInt32("TotalSeats"),
                                SeatsAvailable = reader.GetInt32("TotalSeats") // will be updated separately
                            }
                        };

                        // Optional: load passengers for this booking
                        booking.PassengerList = LoadPassengersByBookingID(booking.BookingID);

                        bookings.AddLast(booking);
                    }
                }
            }

            return bookings;
        }

        private static MyLinkedList<Passenger> LoadPassengersByBookingID(int bookingID)
        {
            var passengers = new MyLinkedList<Passenger>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT p.PassengerID, p.FirstName, p.LastName, p.Age, p.PassportNumber, p.Email
            FROM passengers p
            INNER JOIN tickets t ON p.PassengerID = t.PassengerID
            WHERE t.BookingID = @BookingID;
        ";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Passenger p = new Passenger
                            {
                                PassengerID = reader.GetInt32("PassengerID"),
                                FirstName = reader.GetString("FirstName"),
                                LastName = reader.GetString("LastName"),
                                Age = reader.GetInt32("Age"),
                                PassportNumber = reader.IsDBNull(reader.GetOrdinal("PassportNumber")) ? null : reader.GetString("PassportNumber"),
                                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString("Email")
                            };
                            passengers.AddLast(p);
                        }
                    }
                }
            }

            return passengers;
        }
        public static void AddAirport(Airport a)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO Airports (AirportCode, AirportName, City, Country) VALUES (@c, @n, @ct, @co)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@c", a.AirportCode);
                    cmd.Parameters.AddWithValue("@n", a.AirportName);
                    cmd.Parameters.AddWithValue("@ct", a.City);
                    cmd.Parameters.AddWithValue("@co", a.Country);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddRoute(string origin, string dest, int dist)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO Routes (OriginCode, DestinationCode, Distance) VALUES (@o, @d, @dist)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@o", origin);
                    cmd.Parameters.AddWithValue("@d", dest);
                    cmd.Parameters.AddWithValue("@dist", dist);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ScheduleFlight(Flight f)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO Flights (OriginCode, DestinationCode, FlightDate, DurationMinutes, Price, SeatsAvailable, TotalSeats) VALUES (@o, @d, @dt, @dur, @p, @seats, @tot); SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@o", f.OriginCode);
                    cmd.Parameters.AddWithValue("@d", f.DestinationCode);
                    cmd.Parameters.AddWithValue("@dt", f.FlightDate);
                    cmd.Parameters.AddWithValue("@dur", f.DurationMinutes);
                    cmd.Parameters.AddWithValue("@p", f.Price);
                    cmd.Parameters.AddWithValue("@seats", f.TotalSeats); // Initially available = total
                    cmd.Parameters.AddWithValue("@tot", f.TotalSeats);
                    
                    // Get the auto-generated FlightID
                    int flightId = Convert.ToInt32(cmd.ExecuteScalar());
                    f.FlightID = flightId;
                    
                    // Initialize seat heap for this flight (Feature 1 & 2)
                    SeatManager.InitializeFlightSeats(flightId, f.TotalSeats);
                }
            }
        }

        public static void SaveBooking(Booking b)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                // 1. Save Booking (Auto Increment BookingID) - Status defaults to 'Pending' now
                string sqlB = "INSERT INTO Bookings (PNR, FlightID, Status) VALUES (@pnr, @fid, 'Pending'); SELECT LAST_INSERT_ID();";
                int bookingId = 0;
                using (var cmd = new MySqlCommand(sqlB, conn))
                {
                    cmd.Parameters.AddWithValue("@pnr", b.PNR);
                    cmd.Parameters.AddWithValue("@fid", b.FlightID);
                    bookingId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                b.BookingID = bookingId; // Update object

                // 2. Save Passengers & Tickets with Seat Assignment
                int passengerCount = 0;
                Node<Passenger>? pNode = b.PassengerList.Head;
                while (pNode != null)
                {
                    Passenger p = pNode.Data;
                    
                    // Assign seat using Min-Heap (Feature 2 & 4)
                    int assignedSeat;
                    try
                    {
                        assignedSeat = SeatManager.AssignSeat(b.FlightID);
                    }
                    catch (InvalidOperationException)
                    {
                        // Flight is full - rollback booking
                        throw new InvalidOperationException("Flight is full - no seats available");
                    }
                    
                    // Insert Passenger
                    string sqlP = "INSERT INTO Passengers (FirstName, LastName, Age, PassportNumber, Email) VALUES (@fn, @ln, @ag, @pp, @em); SELECT LAST_INSERT_ID();";
                    int pId = 0;
                    using (var cmdP = new MySqlCommand(sqlP, conn))
                    {
                        cmdP.Parameters.AddWithValue("@fn", p.FirstName);
                        cmdP.Parameters.AddWithValue("@ln", p.LastName);
                        cmdP.Parameters.AddWithValue("@ag", p.Age);
                        cmdP.Parameters.AddWithValue("@pp", p.PassportNumber);
                        cmdP.Parameters.AddWithValue("@em", p.Email ?? ""); // Use passenger's email
                        pId = Convert.ToInt32(cmdP.ExecuteScalar());
                    }
                    p.PassengerID = pId;

                    // Insert Ticket with assigned seat number
                    string sqlT = "INSERT INTO Tickets (TicketNumber, BookingID, PassengerID, SeatNumber) VALUES (@tno, @bid, @pid, @seat)";
                    using (var cmdT = new MySqlCommand(sqlT, conn))
                    {
                        string tNo = $"TKT-{b.PNR}-{pId}";
                        cmdT.Parameters.AddWithValue("@tno", tNo);
                        cmdT.Parameters.AddWithValue("@bid", bookingId);
                        cmdT.Parameters.AddWithValue("@pid", pId);
                        cmdT.Parameters.AddWithValue("@seat", assignedSeat.ToString());
                        cmdT.ExecuteNonQuery();
                    }

                    passengerCount++;
                    pNode = pNode.Next;
                }
                
                // 3. Update SeatsAvailable in database
                string sqlUpdate = "UPDATE Flights SET SeatsAvailable = SeatsAvailable - @c WHERE FlightID=@id";
                using (var cmdUpdate = new MySqlCommand(sqlUpdate, conn))
                {
                    cmdUpdate.Parameters.AddWithValue("@c", passengerCount);
                    cmdUpdate.Parameters.AddWithValue("@id", b.FlightID);
                    cmdUpdate.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteFlight(int flightId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sqlGetBookings = "SELECT BookingID FROM Bookings WHERE FlightID = @fid";
                var bookingIds = new System.Collections.Generic.List<int>();
                
                using (var cmd = new MySqlCommand(sqlGetBookings, conn))
                {
                    cmd.Parameters.AddWithValue("@fid", flightId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookingIds.Add(reader.GetInt32("BookingID"));
                        }
                    }
                }

                // Delete tickets for each booking
                foreach (int bookingId in bookingIds)
                {
                    string sqlDeleteTickets = "DELETE FROM Tickets WHERE BookingID = @bid";
                    using (var cmd = new MySqlCommand(sqlDeleteTickets, conn))
                    {
                        cmd.Parameters.AddWithValue("@bid", bookingId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Delete all bookings for this flight
                string sqlDeleteBookings = "DELETE FROM Bookings WHERE FlightID = @fid";
                using (var cmd = new MySqlCommand(sqlDeleteBookings, conn))
                {
                    cmd.Parameters.AddWithValue("@fid", flightId);
                    cmd.ExecuteNonQuery();
                }

                // Finally, delete the flight
                string sqlDeleteFlight = "DELETE FROM Flights WHERE FlightID = @fid";
                using (var cmd = new MySqlCommand(sqlDeleteFlight, conn))
                {
                    cmd.Parameters.AddWithValue("@fid", flightId);
                    cmd.ExecuteNonQuery();
                }

                // Remove from SeatManager
                SeatManager.RemoveFlight(flightId);
            }
        }
        public static Flight? GetFlightById(int flightId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Flights WHERE FlightID = @fid";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fid", flightId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Flight
                            {
                                FlightID = reader.GetInt32("FlightID"),
                                OriginCode = reader.GetString("OriginCode"),
                                DestinationCode = reader.GetString("DestinationCode"),
                                FlightDate = reader.GetDateTime("FlightDate"),
                                DurationMinutes = reader.GetInt32("DurationMinutes"),
                                Price = reader.GetDecimal("Price"),
                                SeatsAvailable = reader.GetInt32("SeatsAvailable"),
                                TotalSeats = reader.GetInt32("TotalSeats")
                            };
                        }
                    }
                }
            }
            return null;
        }
        public static Booking? GetTicketByPNR(string pnr)
{
    using (var conn = GetConnection())
    {
        conn.Open();

        string sql = @"
            SELECT 
                b.BookingID, b.PNR, b.FlightID, b.BookingDate, b.Status,
                f.OriginCode, f.DestinationCode, f.FlightDate, f.DurationMinutes,
                f.Price, f.SeatsAvailable, f.TotalSeats,
                t.TicketNumber, t.SeatNumber,
                p.PassengerID, p.FirstName, p.LastName, p.Age, p.PassportNumber
            FROM Bookings b
            INNER JOIN Flights f ON b.FlightID = f.FlightID
            LEFT JOIN Tickets t ON b.BookingID = t.BookingID
            LEFT JOIN Passengers p ON t.PassengerID = p.PassengerID
            WHERE b.PNR = @pnr";

        using (var cmd = new MySqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@pnr", pnr);

            using (var reader = cmd.ExecuteReader())
            {
                Booking? booking = null;

                while (reader.Read())
                {
                    if (booking == null)
                    {
                        booking = new Booking
                        {
                            BookingID = reader.GetInt32("BookingID"),
                            PNR = reader.GetString("PNR"),
                            FlightID = reader.GetInt32("FlightID"),
                            BookingDate = reader.GetDateTime("BookingDate"),
                            Status = reader.GetString("Status"),
                            PassengerList = new MyLinkedList<Passenger>(),
                            FlightDetails = new Flight
                            {
                                FlightID = reader.GetInt32("FlightID"),
                                OriginCode = reader.GetString("OriginCode"),
                                DestinationCode = reader.GetString("DestinationCode"),
                                FlightDate = reader.GetDateTime("FlightDate"),
                                DurationMinutes = reader.GetInt32("DurationMinutes"),
                                Price = reader.GetDecimal("Price"),
                                SeatsAvailable = reader.GetInt32("SeatsAvailable"),
                                TotalSeats = reader.GetInt32("TotalSeats")
                            }
                        };
                    }

                    // Ticket may be NULL (LEFT JOIN)
                    if (!reader.IsDBNull(reader.GetOrdinal("PassengerID")))
                    {
                        booking.PassengerList.AddLast(new Passenger
                        {
                            PassengerID = reader.GetInt32("PassengerID"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName"),
                            Age = reader.GetInt32("Age"),
                            PassportNumber = reader.GetString("PassportNumber")
                        });
                    }
                }

                return booking;
            }
        }
    }
}
        public static bool CancelBooking(string pnr, out string errorMessage)
        {
            errorMessage = "";
            
            using (var conn = GetConnection())
            {
                conn.Open();
                
                // Get booking and flight details
                var booking = GetTicketByPNR(pnr);
                if (booking == null || booking.FlightDetails == null)
                {
                    errorMessage = "Booking not found";
                    return false;
                }

                // Check 24-hour rule
                TimeSpan diff = booking.FlightDetails.FlightDate - DateTime.Now;
                if (diff.TotalHours < 24)
                {
                    errorMessage = "Cannot cancel within 24 hours of departure";
                    return false;
                }

                // Get seat numbers to restore
                string sqlGetSeats = "SELECT SeatNumber FROM Tickets WHERE BookingID = @bid";
                var seatNumbers = new System.Collections.Generic.List<int>();
                
                using (var cmd = new MySqlCommand(sqlGetSeats, conn))
                {
                    cmd.Parameters.AddWithValue("@bid", booking.BookingID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string seatStr = reader.GetString("SeatNumber");
                            if (int.TryParse(seatStr, out int seatNum))
                            {
                                seatNumbers.Add(seatNum);
                            }
                        }
                    }
                }

                // Delete tickets
                string sqlDeleteTickets = "UPDATE Bookings SET Status = 'Cancelled' WHERE BookingID = @bid;";
                using (var cmd = new MySqlCommand(sqlDeleteTickets, conn))
                {
                    cmd.Parameters.AddWithValue("@bid", booking.BookingID);
                    cmd.ExecuteNonQuery();
                }

                // Update booking status to Cancelled
                string sqlUpdateBooking = "UPDATE Bookings SET Status = 'Cancelled' WHERE BookingID = @bid";
                using (var cmd = new MySqlCommand(sqlUpdateBooking, conn))
                {
                    cmd.Parameters.AddWithValue("@bid", booking.BookingID);
                    cmd.ExecuteNonQuery();
                }

                // Update seats available
                string sqlUpdateSeats = "UPDATE Flights SET SeatsAvailable = SeatsAvailable + @count WHERE FlightID = @fid";
                using (var cmd = new MySqlCommand(sqlUpdateSeats, conn))
                {
                    cmd.Parameters.AddWithValue("@count", seatNumbers.Count);
                    cmd.Parameters.AddWithValue("@fid", booking.FlightID);
                    cmd.ExecuteNonQuery();
                }

                // Restore seats to heap
                foreach (int seatNum in seatNumbers)
                {
                    SeatManager.RestoreSeat(booking.FlightID, seatNum);
                }

                return true;
            }
        }
        public static MyLinkedList<Passenger> GetPassengersByFlight(int flightId)
        {
            var passengers = new MyLinkedList<Passenger>();
            
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"SELECT DISTINCT p.*, t.SeatNumber, b.Status 
                              FROM Passengers p
                              INNER JOIN Tickets t ON p.PassengerID = t.PassengerID
                              INNER JOIN Bookings b ON t.BookingID = b.BookingID
                              WHERE b.FlightID = @fid AND b.Status != 'Cancelled'";
                
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fid", flightId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            passengers.AddLast(new Passenger
                            {
                                PassengerID = reader.GetInt32("PassengerID"),
                                FirstName = reader.GetString("FirstName"),
                                LastName = reader.GetString("LastName"),
                                Age = reader.GetInt32("Age"),
                                PassportNumber = reader.GetString("PassportNumber"),
                                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader.GetString("Email")
                            });
                        }
                    }
                }
            }
            
            return passengers;
        }
        public static MyLinkedList<Booking> GetPendingBookings(int? flightId = null)
        {
            var bookings = new MyLinkedList<Booking>();
            
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"SELECT b.*, f.* FROM Bookings b 
                              INNER JOIN Flights f ON b.FlightID = f.FlightID 
                              WHERE b.Status = 'Pending'";
                
                if (flightId.HasValue)
                {
                    sql += " AND b.FlightID = @fid";
                }
                
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (flightId.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@fid", flightId.Value);
                    }
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var booking = new Booking
                            {
                                BookingID = reader.GetInt32("BookingID"),
                                PNR = reader.GetString("PNR"),
                                FlightID = reader.GetInt32("FlightID"),
                                BookingDate = reader.GetDateTime("BookingDate"),
                                Status = reader.GetString("Status"),
                                FlightDetails = new Flight
                                {
                                    FlightID = reader.GetInt32("FlightID"),
                                    OriginCode = reader.GetString("OriginCode"),
                                    DestinationCode = reader.GetString("DestinationCode"),
                                    FlightDate = reader.GetDateTime("FlightDate"),
                                    DurationMinutes = reader.GetInt32("DurationMinutes"),
                                    Price = reader.GetDecimal("Price")
                                }
                            };
                            bookings.AddLast(booking);
                        }
                    }
                }
            }
            
            return bookings;
        }
        public static void UpdateBookingStatus(int bookingId, string status)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "UPDATE Bookings SET Status = @status WHERE BookingID = @bid";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@bid", bookingId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static System.Collections.Generic.List<int> GetOccupiedSeats(int flightId)
        {
            var occupiedSeats = new System.Collections.Generic.List<int>();
            
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"SELECT DISTINCT t.SeatNumber FROM Tickets t
                              INNER JOIN Bookings b ON t.BookingID = b.BookingID
                              WHERE b.FlightID = @fid AND b.Status != 'Cancelled'";
                
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fid", flightId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string seatStr = reader.GetString("SeatNumber");
                            if (int.TryParse(seatStr, out int seatNum))
                            {
                                occupiedSeats.Add(seatNum);
                            }
                        }
                    }
                }
            }
            
            return occupiedSeats;
        }
        public static System.Collections.Generic.List<AirportWithRouteCount> GetAirportsWithRouteCounts()
        {
            var airports = new System.Collections.Generic.List<AirportWithRouteCount>();
            
            using (var conn = GetConnection())
            {
                conn.Open();
                // Count routes where airport is either origin OR destination
                string sql = @"SELECT a.AirportCode, a.AirportName, a.City, a.Country,
                              (SELECT COUNT(*) FROM Routes r 
                               WHERE r.OriginCode = a.AirportCode OR r.DestinationCode = a.AirportCode) AS RouteCount
                              FROM Airports a
                              ORDER BY a.AirportCode";
                
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        airports.Add(new AirportWithRouteCount
                        {
                            AirportCode = reader.GetString("AirportCode"),
                            AirportName = reader.GetString("AirportName"),
                            City = reader.GetString("City"),
                            Country = reader.GetString("Country"),
                            RouteCount = reader.GetInt32("RouteCount")
                        });
                    }
                }
            }
            
            return airports;
        }
        public static bool DeleteAirportCascade(string airportCode, out string errorMessage)
        {
            errorMessage = "";
            
            using (var conn = GetConnection())
            {
                conn.Open();
                MySqlTransaction? transaction = null;
                
                try
                {
                    transaction = conn.BeginTransaction();
                    
                    string sqlGetFlights = @"SELECT FlightID FROM Flights 
                                            WHERE OriginCode = @code OR DestinationCode = @code";
                    var flightIds = new System.Collections.Generic.List<int>();
                    
                    using (var cmd = new MySqlCommand(sqlGetFlights, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@code", airportCode);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                flightIds.Add(reader.GetInt32("FlightID"));
                            }
                        }
                    }
                    
                    if (flightIds.Count > 0)
                    {
                        string flightIdList = string.Join(",", flightIds);
                        string sqlDeleteTickets = $@"DELETE FROM Tickets 
                                                     WHERE BookingID IN 
                                                     (SELECT BookingID FROM Bookings WHERE FlightID IN ({flightIdList}))";
                        
                        using (var cmd = new MySqlCommand(sqlDeleteTickets, conn, transaction))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        
                        string sqlDeleteBookings = $"DELETE FROM Bookings WHERE FlightID IN ({flightIdList})";
                        using (var cmd = new MySqlCommand(sqlDeleteBookings, conn, transaction))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        
                        foreach (int flightId in flightIds)
                        {
                            SeatManager.RemoveFlight(flightId);
                        }
                    }
                    
                    string sqlDeleteFlights = "DELETE FROM Flights WHERE OriginCode = @code OR DestinationCode = @code";
                    using (var cmd = new MySqlCommand(sqlDeleteFlights, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@code", airportCode);
                        cmd.ExecuteNonQuery();
                    }
                    
                    string sqlDeleteRoutes = "DELETE FROM Routes WHERE OriginCode = @code OR DestinationCode = @code";
                    using (var cmd = new MySqlCommand(sqlDeleteRoutes, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@code", airportCode);
                        cmd.ExecuteNonQuery();
                    }
                    
                    string sqlDeleteAirport = "DELETE FROM Airports WHERE AirportCode = @code";
                    using (var cmd = new MySqlCommand(sqlDeleteAirport, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@code", airportCode);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        
                        if (rowsAffected == 0)
                        {
                            errorMessage = "Airport not found";
                            transaction.Rollback();
                            return false;
                        }
                    }
                    
                    transaction.Commit();
                    
                    FlightService.Network.RemoveAirport(airportCode);
                    
                    return true;
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    errorMessage = $"Error deleting airport: {ex.Message}";
                    return false;
                }
            }
        }
    }
}
