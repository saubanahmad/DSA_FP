using System;
using System.Collections.Generic;
using FlightBookingSystem.Core.DataStructures;

namespace FlightBookingSystem.Services
{
    public static class SeatManager
    {
        private static Dictionary<int, SeatMinHeap> flightSeats = new Dictionary<int, SeatMinHeap>();
        public static void InitializeFlightSeats(int flightId, int totalSeats)
        {
            var heap = new SeatMinHeap(totalSeats);
            for (int i = 1; i <= totalSeats; i++)
            {
                heap.Insert(i);
            }
            flightSeats[flightId] = heap;
        }
        public static void LoadExistingSeats(int flightId, List<int> occupiedSeats, int totalSeats)
        {
            var heap = new SeatMinHeap(totalSeats);
            
            var occupied = new HashSet<int>(occupiedSeats);
            
            for (int i = 1; i <= totalSeats; i++)
            {
                if (!occupied.Contains(i))
                {
                    heap.Insert(i);
                }
            }
            
            flightSeats[flightId] = heap;
        }
        public static int AssignSeat(int flightId)
        {
            if (!flightSeats.ContainsKey(flightId))
            {
                throw new InvalidOperationException($"Flight {flightId} not initialized in SeatManager");
            }

            return flightSeats[flightId].ExtractMin();
        }
        public static void RestoreSeat(int flightId, int seatNumber)
        {
            if (!flightSeats.ContainsKey(flightId))
            {
                throw new InvalidOperationException($"Flight {flightId} not initialized in SeatManager");
            }

            flightSeats[flightId].Insert(seatNumber);
        }
        public static bool IsFlightFull(int flightId)
        {
            if (!flightSeats.ContainsKey(flightId))
            {
                return true; // If not initialized, consider it full
            }

            return flightSeats[flightId].IsEmpty;
        }
        public static int GetAvailableSeatsCount(int flightId)
        {
            if (!flightSeats.ContainsKey(flightId))
            {
                return 0;
            }

            return flightSeats[flightId].Count;
        }
        public static void RemoveFlight(int flightId)
        {
            if (flightSeats.ContainsKey(flightId))
            {
                flightSeats.Remove(flightId);
            }
        }
        public static void ClearAll()
        {
            flightSeats.Clear();
        }
    }
}
