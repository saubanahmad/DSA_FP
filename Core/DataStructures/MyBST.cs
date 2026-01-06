using System;
using FlightBookingSystem.Models;

namespace FlightBookingSystem.Core.DataStructures
{
    /// Binary Search Tree Node for Flight
    public class FlightNode
    {
        public Flight Data;
        public FlightNode? Left, Right;

        public FlightNode(Flight data) { Data = data; }
    }
    /// Binary Search Tree implementation for Flights
    public class MyBST
    {
        public FlightNode? Root;

        public void Insert(Flight flight)
        {
            Root = InsertRec(Root, flight);
        }

        private FlightNode InsertRec(FlightNode? root, Flight flight)
        {
            if (root == null) return new FlightNode(flight);

            if (flight.FlightDate < root.Data.FlightDate)
                root.Left = InsertRec(root.Left, flight);
            else if (flight.FlightDate > root.Data.FlightDate)
                root.Right = InsertRec(root.Right, flight);
            else { 
                root.Right = InsertRec(root.Right, flight);
            }
            return root;
        }

        public MyLinkedList<Flight> SearchByDate(DateTime date)
        {
            MyLinkedList<Flight> result = new MyLinkedList<Flight>();
            SearchRec(Root, date.Date, result);
            return result;
        }

        private void SearchRec(FlightNode? root, DateTime date, MyLinkedList<Flight> list)
        {
            if (root == null) return;
            SearchRec(root.Left, date, list);
            if (root.Data.FlightDate.Date == date)
                list.AddLast(root.Data);
            SearchRec(root.Right, date, list);
        }
    }
}
