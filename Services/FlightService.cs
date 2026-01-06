using System;
using FlightBookingSystem.Data;
using FlightBookingSystem.Models;
using FlightBookingSystem.Core.DataStructures;

namespace FlightBookingSystem.Services
{
    public static class FlightService
    {
        public static MyGraph Network = new MyGraph();
        public static MyBST FlightSchedule = new MyBST();
        public static MyTrie AirportLookup = new MyTrie();
        public static MyHashTable Bookings = new MyHashTable(); // Cache for fast retrieval

        public static void InitializeSystem()
        {
            DbHelper.UpdateFlightStatuses();

            var airports = DbHelper.LoadAirports();
            Node<Airport>? aNode = airports.Head;
            while (aNode != null)
            {
                Airport a = aNode.Data;
                AirportLookup.Insert(a.AirportCode, $"{a.AirportCode} - {a.AirportName}");
                Network.AddAirport(a.AirportCode);
                aNode = aNode.Next;
            }

            // Load Routes into Graph
            var routes = DbHelper.LoadRoutes();
            Node<Route>? rNode = routes.Head;
            while (rNode != null)
            {
                Route r = rNode.Data;
                Network.AddRoute(r.OriginCode, r.DestinationCode, r.Distance);
                rNode = rNode.Next;
            }

            // Load Flights into BST
            var flights = DbHelper.LoadFlights();
            Node<Flight>? fNode = flights.Head;
            while (fNode != null)
            {
                FlightSchedule.Insert(fNode.Data);
                
                // Initialize seat heaps for each flight 
                Flight f = fNode.Data;
                var occupiedSeats = DbHelper.GetOccupiedSeats(f.FlightID);
                SeatManager.LoadExistingSeats(f.FlightID, occupiedSeats, f.TotalSeats);
                
                fNode = fNode.Next;
            }
            // Load existing bookings into cache
            var allBookings = DbHelper.LoadAllBookings();
            Node<Booking>? bNode = allBookings.Head;
            while (bNode != null)
            {
                Bookings.Insert(bNode.Data.PNR, bNode.Data);
                bNode = bNode.Next;
            }


        }

        public static void RefreshFlights()
        {
            FlightSchedule = new MyBST(); // Clear and reload
            var flights = DbHelper.LoadFlights();
            Node<Flight>? fNode = flights.Head;
            while (fNode != null)
            {
                FlightSchedule.Insert(fNode.Data);
                fNode = fNode.Next;
            }
        }

        public static Booking? GetBookingByPNR(string pnr, out string error)
        {
            error = "";
            var cachedBooking = Bookings.Search(pnr);
            if (cachedBooking != null && cachedBooking.Status != "Pending")
            {
                return cachedBooking;
            }
            var dbBooking = DbHelper.GetTicketByPNR(pnr);

            if (dbBooking == null)
            {
                error = "PNR not found";
                return null;
            }
            Bookings.Insert(pnr, dbBooking);

            return dbBooking;
        }
    }
}
