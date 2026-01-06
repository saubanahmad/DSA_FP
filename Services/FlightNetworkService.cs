using System;
using System.Collections.Generic;
using System.Linq;
using FlightBookingSystem.Models;
using FlightBookingSystem.Data;
using FlightBookingSystem.Core.DataStructures;

namespace FlightBookingSystem.Services
{
    public class FlightNetworkGraph
    {
        private Dictionary<AirportNode, List<FlightEdge>> adjacencyList;

        public FlightNetworkGraph()
        {
            adjacencyList = new Dictionary<AirportNode, List<FlightEdge>>();
        }
        public void AddAirport(AirportNode airport)
        {
            if (!adjacencyList.ContainsKey(airport))
            {
                adjacencyList[airport] = new List<FlightEdge>();
            }
        }
        public void AddFlight(AirportNode source, AirportNode destination, decimal price, DateTime depTime, DateTime arrTime, FlightStatus status, string flightCode = "")
        {
            // Ensure nodes exist
            AddAirport(source);
            AddAirport(destination);

            var flight = new FlightEdge(source, destination, price, depTime, arrTime, status, flightCode);
            adjacencyList[source].Add(flight);
        }
        public List<FlightEdge> GetOutgoingFlights(AirportNode source)
        {
            if (adjacencyList.ContainsKey(source))
            {
                return adjacencyList[source];
            }
            return new List<FlightEdge>();
        }
        public List<AirportNode> GetAllAirports()
        {
            return adjacencyList.Keys.ToList();
        }
        public Dictionary<AirportNode, List<FlightEdge>> GetAdjacencyList()
        {
            return adjacencyList;
        }
        public bool IsValidRoute(string sourceCode, string destCode)
        {
            var source = adjacencyList.Keys.FirstOrDefault(a => a.Code.Equals(sourceCode, StringComparison.OrdinalIgnoreCase));
            if (source == null) return false;

            // Check if there is any edge to destination
            return adjacencyList[source].Any(e => e.To.Code.Equals(destCode, StringComparison.OrdinalIgnoreCase));
        }
        public static FlightNetworkGraph LoadFromDatabase()
        {
            var graph = new FlightNetworkGraph();

            var airports = DbHelper.LoadAirports();
            var airportNodeMap = new Dictionary<string, AirportNode>();

            Node<Airport>? aNode = airports.Head;
            while (aNode != null)
            {
                var dbAirport = aNode.Data;
                var newNode = new AirportNode(dbAirport.AirportCode, dbAirport.AirportName, 0, 0);
                
                graph.AddAirport(newNode);
                airportNodeMap[dbAirport.AirportCode] = newNode; // Cache for edge creation

                aNode = aNode.Next;
            }

            var routes = DbHelper.LoadRoutes();
            Node<Route>? rNode = routes.Head;
            
            while (rNode != null)
            {
                var route = rNode.Data;
                
                if (airportNodeMap.ContainsKey(route.OriginCode) && airportNodeMap.ContainsKey(route.DestinationCode))
                {
                    var src = airportNodeMap[route.OriginCode];
                    var dst = airportNodeMap[route.DestinationCode];

                    var flights = DbHelper.LoadFlights();
                    bool hasActiveFlight = false;
                    
                    Node<Flight>? fNode = flights.Head;
                    while (fNode != null)
                    {
                        var f = fNode.Data;
                        if (f.OriginCode == route.OriginCode && f.DestinationCode == route.DestinationCode)
                        {
                            FlightStatus status = FlightStatus.Scheduled;
                            if (f.Status == "Completed") status = FlightStatus.Inactive;
                            
                            if (DateTime.Now >= f.FlightDate && DateTime.Now <= f.FlightDate.AddMinutes(f.DurationMinutes))
                                status = FlightStatus.Active;
                            else if (DateTime.Now < f.FlightDate)
                                status = FlightStatus.Scheduled;
                            else 
                                status = FlightStatus.Inactive;

                            graph.AddFlight(src, dst, f.Price, f.FlightDate, f.FlightDate.AddMinutes(f.DurationMinutes), status, f.FlightID.ToString());
                            hasActiveFlight = true;
                        }
                        fNode = fNode.Next;
                    }

                    if (!hasActiveFlight)
                    {
                       graph.AddFlight(src, dst, 0, DateTime.MinValue, DateTime.MinValue, FlightStatus.Inactive, "ROUTE-ONLY");
                    }
                }
                
                rNode = rNode.Next;
            }

            return graph;
        }
    }
}
