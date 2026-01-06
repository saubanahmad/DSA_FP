using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using FlightBookingSystem.Data;
using FlightBookingSystem.Models;
using FlightBookingSystem.Core.DataStructures;

namespace FlightBookingSystem.Services
{
    public class GraphService
    {
        public class GraphEdge
        {
            public GraphNode Destination;
            public int Distance; // in kilometers

            public GraphEdge(GraphNode destination, int distance)
            {
                Destination = destination;
                Distance = distance;
            }
        }

        // Custom Graph Node
        public class GraphNode
        {
            public string Code;
            public string Name;
            public int X;
            public int Y;
            public GraphEdge[] Edges; // Array of edges instead of neighbors
            public int EdgeCount;
            private int edgeCapacity;

            public GraphNode(string code, string name)
            {
                Code = code;
                Name = name;
                X = 0;
                Y = 0;
                edgeCapacity = 10;
                Edges = new GraphEdge[edgeCapacity];
                EdgeCount = 0;
            }

            public void AddEdge(GraphNode destination, int distance)
            {
                // Check if edge already exists
                for (int i = 0; i < EdgeCount; i++)
                {
                    if (Edges[i].Destination == destination)
                    {
                        Edges[i].Distance = distance;
                        return;
                    }
                }
                if (EdgeCount == edgeCapacity)
                {
                    edgeCapacity *= 2;
                    GraphEdge[] newEdges = new GraphEdge[edgeCapacity];
                    for (int i = 0; i < EdgeCount; i++)
                    {
                        newEdges[i] = Edges[i];
                    }
                    Edges = newEdges;
                }

                Edges[EdgeCount] = new GraphEdge(destination, distance);
                EdgeCount++;
            }
            public List<GraphNode> GetNeighbors()
            {
                List<GraphNode> neighbors = new List<GraphNode>();
                for (int i = 0; i < EdgeCount; i++)
                {
                    neighbors.Add(Edges[i].Destination);
                }
                return neighbors;
            }
        }
        private List<GraphNode> nodes;

        public GraphService()
        {
            nodes = new List<GraphNode>();
        }
        public void LoadFromDatabase()
        {
            nodes.Clear();

            try
            {
                // Load Airports
                string queryAirports = "SELECT AirportCode, AirportName, City FROM Airports";
                using (MySqlConnection conn = new MySqlConnection(DbHelper.ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(queryAirports, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string code = reader.GetString("AirportCode");
                            string name = reader.IsDBNull(reader.GetOrdinal("AirportName")) ? "" : reader.GetString("AirportName");

                            // Add node
                            nodes.Add(new GraphNode(code, name));
                        }
                    }
                }
                string queryRoutes = "SELECT OriginCode, DestinationCode, Distance FROM Routes";
                using (MySqlConnection conn = new MySqlConnection(DbHelper.ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(queryRoutes, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string origin = reader.GetString("OriginCode");
                            string dest = reader.GetString("DestinationCode");
                            int distance = reader.GetInt32("Distance");

                            GraphNode originNode = GetNode(origin);
                            GraphNode destNode = GetNode(dest);

                            if (originNode != null && destNode != null)
                            {
                                originNode.AddEdge(destNode, distance);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load graph from database: {ex.Message}", ex);
            }
        }
        private GraphNode? GetNode(string code)
        {
            foreach (var node in nodes)
            {
                if (node.Code.Equals(code, StringComparison.OrdinalIgnoreCase))
                    return node;
            }
            return null;
        }

        public PathResult? FindShortestPathDijkstra(string start, string end)
        {
            GraphNode startNode = GetNode(start);
            GraphNode endNode = GetNode(end);

            if (startNode == null || endNode == null)
                return null;

            DijkstraMinHeap<GraphNode> minHeap = new DijkstraMinHeap<GraphNode>(nodes.Count); // It stores nodes we need to visit, but it always keeps the node with the smallest distance at the top. It ensures we always process the closest node next.
            GenericHashTable<GraphNode, int> distances = new GenericHashTable<GraphNode, int>(nodes.Count * 2); // A table tracking the shortest known distance from the Start to every other node.
            GenericHashTable<GraphNode, GraphNode> predecessors = new GenericHashTable<GraphNode, GraphNode>(nodes.Count * 2); // This remembers "Where did I come from?" If you find a shorter path to Node B coming from Node A, you write down "A" next to "B". This is used at the very end to build the path back.
            CustomSet<GraphNode> visited = new CustomSet<GraphNode>(nodes.Count); // A set of nodes we have already fully checked. Once a node is here, we know we have found the absolute shortest path to it, so we never check it again.

          
            foreach (var node in nodes)
            {
                distances.Insert(node, int.MaxValue);   // Initialize distances to infinity
            }

            // Start node has distance 0
            distances.Insert(startNode, 0);
            minHeap.Insert(startNode, 0);

            while (!minHeap.IsEmpty)
            {
                int currentDistance = 0;
                GraphNode current = minHeap.ExtractMin(out currentDistance);

                // Skip if already visited
                if (visited.Contains(current))
                    continue;

                visited.Add(current);

                // If we reached the destination, reconstruct path
                if (current == endNode)
                {
                    return ReconstructPath(startNode, endNode, predecessors, currentDistance);
                }

                // Relaxation , Checking if the path to that particular node has another alternate route with shorter distance relax the node with that path
                for (int i = 0; i < current.EdgeCount; i++)
                {
                    GraphEdge edge = current.Edges[i]; 
                    GraphNode neighbor = edge.Destination;

                    if (visited.Contains(neighbor))
                        continue;

                    int newDistance = currentDistance + edge.Distance; // new potential distance 
                    int neighborDistance = distances.Get(neighbor)!; // current best known path to B 

                    if (newDistance < neighborDistance)
                    {
                        distances.Insert(neighbor, newDistance);
                        predecessors.Insert(neighbor, current);
                        minHeap.Insert(neighbor, newDistance);
                    }
                }
            }

            return null;
        }
        private PathResult ReconstructPath(GraphNode start, GraphNode end, 
            GenericHashTable<GraphNode, GraphNode> predecessors, int totalDistance)
        {
            int pathLength = 0;
            GraphNode? current = end;
            while (current != null && current != start)
            {
                pathLength++;
                current = predecessors.Get(current);
            }
            pathLength++; 
            string[] path = new string[pathLength];
            current = end;
            int index = pathLength - 1;

            while (current != null)
            {
                path[index] = current.Code;
                index--;
                if (current == start)
                    break;
                current = predecessors.Get(current);
            }

            PathResult result = new PathResult(path, totalDistance);
            result.IsShortestPath = true;
            return result;
        }
        public PathResult[] FindAllPaths(string start, string end, int maxDepth = 5)
        {
            List<List<string>> allPaths = new List<List<string>>();

            GraphNode startNode = GetNode(start);
            GraphNode endNode = GetNode(end);

            if (startNode == null || endNode == null)
                return new PathResult[0];

            List<GraphNode> currentPath = new List<GraphNode>();
            CustomSet<GraphNode> visited = new CustomSet<GraphNode>();

            DFS(startNode, endNode, visited, currentPath, allPaths, maxDepth);

            PathResult? shortestPath = FindShortestPathDijkstra(start, end);
            int shortestDistance;

            if (shortestPath != null)
            {
                shortestDistance = shortestPath.TotalDistance;
            }
            else
            {
                shortestDistance = int.MaxValue;
            }
            PathResult[] results = new PathResult[allPaths.Count];
            for (int i = 0; i < allPaths.Count; i++)
            {
                List<string> path = allPaths[i]; // The Format Conversion (List to Array)
                string[] pathArray = new string[path.Count];
                for (int j = 0; j < path.Count; j++)
                {
                    pathArray[j] = path[j];
                }

                int distance = CalculatePathDistance(pathArray);
                PathResult result = new PathResult(pathArray, distance); //packages the Route (pathArray) and the Cost (distance) into a single object

                result.IsShortestPath = (distance == shortestDistance);
                
                results[i] = result;
            }

            return results;
        }
        private int CalculatePathDistance(string[] path)
        {
            if (path.Length < 2)
                return 0;

            int totalDistance = 0;

            for (int i = 0; i < path.Length - 1; i++)
            {
                GraphNode fromNode = GetNode(path[i]);
                GraphNode toNode = GetNode(path[i + 1]);

                if (fromNode == null || toNode == null)
                    continue;

                // Find the edge
                bool found = false;
                for (int j = 0; j < fromNode.EdgeCount; j++)
                {
                    if (fromNode.Edges[j].Destination == toNode)
                    {
                        totalDistance += fromNode.Edges[j].Distance;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    return int.MaxValue;
                }
            }

            return totalDistance;
        }
        private void DFS(GraphNode current, GraphNode target, CustomSet<GraphNode> visited,
                        List<GraphNode> currentPath, List<List<string>> allPaths, int maxDepth)
        {
            if (visited.Contains(current))
                return;

            if (currentPath.Count >= maxDepth)
                return;

            visited.Add(current);
            currentPath.Add(current);

            if (current == target)
            {
                List<string> path = new List<string>();
                foreach (var node in currentPath)
                    path.Add(node.Code);
                allPaths.Add(path);
            }
            else
            {
                var neighbors = current.GetNeighbors();
                foreach (var neighbor in neighbors)
                {
                    DFS(neighbor, target, visited, currentPath, allPaths, maxDepth);
                }
            }

            visited.Remove(current);
            currentPath.RemoveAt(currentPath.Count - 1);
        }
        public List<string> GetAllAirportCodes()
        {
            List<string> codes = new List<string>();
            foreach (var node in nodes)
                codes.Add(node.Code);
            return codes;
        }
        public AirportData? GetAirportData(string code)
        {
            GraphNode? node = GetNode(code);
            if (node == null) return null;

            string city = "";
            try
            {
                string query = "SELECT City FROM Airports WHERE AirportCode = @Code";
                using (MySqlConnection conn = new MySqlConnection(DbHelper.ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Code", code);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                            city = result.ToString() ?? "";
                    }
                }
            }
            catch { }

            return new AirportData
            {
                Code = node.Code,
                Name = node.Name,
                City = city,
                X = node.X,
                Y = node.Y
            };
        }
        public GenericHashTable<string, AirportData> GetAllAirportData()
        {
            GenericHashTable<string, AirportData> airportTable = new GenericHashTable<string, AirportData>(nodes.Count * 2);
            
            foreach (var node in nodes)
            {
                var data = GetAirportData(node.Code);
                if (data != null)
                {
                    airportTable.Insert(node.Code, data);
                }
            }
            
            return airportTable;
        }
        public List<string> GetNeighbors(string code)
        {
            GraphNode node = GetNode(code);
            List<string> neighbors = new List<string>();
            if (node != null)
            {
                for (int i = 0; i < node.EdgeCount; i++)
                {
                    neighbors.Add(node.Edges[i].Destination.Code);
                }
            }
            return neighbors;
        }
        public bool HasEdge(string from, string to)
        {
            GraphNode node = GetNode(from);
            if (node != null)
            {
                for (int i = 0; i < node.EdgeCount; i++)
                {
                    if (node.Edges[i].Destination.Code.Equals(to, StringComparison.OrdinalIgnoreCase))
                        return true;
                }
            }
            return false;
        }
        public int GetEdgeDistance(string from, string to)
        {
            GraphNode node = GetNode(from);
            if (node != null)
            {
                for (int i = 0; i < node.EdgeCount; i++)
                {
                    if (node.Edges[i].Destination.Code.Equals(to, StringComparison.OrdinalIgnoreCase))
                        return node.Edges[i].Distance;
                }
            }
            return 0;
        }
        public void CalculateTopologicalLayout(string origin, string destination, int canvasWidth, int canvasHeight)
        {
            GraphNode originNode = GetNode(origin);
            GraphNode destinationNode = GetNode(destination);

            if (originNode == null || destinationNode == null)
                return;

            var paths = FindAllPaths(origin, destination);
            CustomSet<GraphNode> involvedNodes = new CustomSet<GraphNode>(nodes.Count);
            foreach (var pathResult in paths)
            {
                foreach (string code in pathResult.Path)
                {
                    GraphNode n = GetNode(code);
                    if (n != null) involvedNodes.Add(n);
                }
            }
            GenericHashTable<GraphNode, int> distances = CalculateBFSDistances(originNode);

            GenericHashTable<int, List<GraphNode>> layers = new GenericHashTable<int, List<GraphNode>>(20);
            int maxDistance = 0;
            
            GraphNode[] involvedArray = involvedNodes.ToArray();
            foreach (var node in involvedArray)
            {
                int dist = distances.ContainsKey(node) ? distances.Get(node)!: 0;
                
                if (!layers.ContainsKey(dist))
                    layers.Insert(dist, new List<GraphNode>());
                
                layers.Get(dist)!.Add(node);
                maxDistance = Math.Max(maxDistance, dist);
            }

            int margin = 100;
            int usableWidth = canvasWidth - 2 * margin;
            int usableHeight = canvasHeight - 2 * margin;

            int[] layerKeys = layers.GetAllKeys();
            foreach (int layerIndex in layerKeys)
            {
                List<GraphNode> nodesInLayer = layers.Get(layerIndex)!;

                int x = margin + (maxDistance > 0 ? (layerIndex * usableWidth / maxDistance) : usableWidth / 2);
                int yStep = nodesInLayer.Count > 1 ? usableHeight / (nodesInLayer.Count - 1) : 0;
                int startY = margin + (usableHeight - yStep * (nodesInLayer.Count - 1)) / 2;

                for (int i = 0; i < nodesInLayer.Count; i++)
                {
                    nodesInLayer[i].X = x;
                    nodesInLayer[i].Y = startY + i * yStep;
                }
            }

            List<GraphNode> uninvolved = new List<GraphNode>();
            foreach (var node in nodes)
                if (!involvedNodes.Contains(node))
                    uninvolved.Add(node);

            if (uninvolved.Count > 0)
            {
                int circleRadius = 80;
                int centerX = canvasWidth / 2;
                int centerY = canvasHeight - 120;
                double angleStep = 2 * Math.PI / uninvolved.Count;

                for (int i = 0; i < uninvolved.Count; i++)
                {
                    uninvolved[i].X = (int)(centerX + circleRadius * Math.Cos(i * angleStep));
                    uninvolved[i].Y = (int)(centerY + circleRadius * Math.Sin(i * angleStep));
                }
            }
        }

        private GenericHashTable<GraphNode, int> CalculateBFSDistances(GraphNode start)
        {
            GenericHashTable<GraphNode, int> distances = new GenericHashTable<GraphNode, int>(nodes.Count * 2);
            MyQueue<GraphNode> queue = new MyQueue<GraphNode>();

            distances.Insert(start, 0);
            queue.Enqueue(start);

            while (!queue.IsEmpty())
            {
                GraphNode current = queue.Dequeue();
                int currDist = distances.Get(current)!;

                var neighbors = current.GetNeighbors();
                foreach (var neighbor in neighbors)
                {
                    if (!distances.ContainsKey(neighbor))
                    {
                        distances.Insert(neighbor, currDist + 1);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return distances;
        }
    }
}
