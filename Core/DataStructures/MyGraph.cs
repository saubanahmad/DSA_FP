namespace FlightBookingSystem.Core.DataStructures
{
    /// Graph implementation using Adjacency List
    public class MyGraph
    {
        public class Edge
        {
            public string DestCode;
            public int Distance;
            public Edge(string d, int dist) { DestCode = d; Distance = dist; }
        }

        public class Vertex
        {
            public string Code;
            public MyLinkedList<Edge> Edges;
            public Vertex(string c) { Code = c; Edges = new MyLinkedList<Edge>(); }
        }

        private MyLinkedList<Vertex> vertices = new MyLinkedList<Vertex>();

        public void AddAirport(string code)
        {
            var v = FindVertex(code);
            if (v == null) vertices.AddLast(new Vertex(code));
        }

        public void AddRoute(string origin, string dest, int dist)
        {
            AddAirport(origin);
            AddAirport(dest);
            var v = FindVertex(origin);
            v!.Edges.AddLast(new Edge(dest, dist));
        }

        public bool IsConnected(string origin, string dest)
        {
            var v = FindVertex(origin);
            if (v == null) return false;

            Node<Edge>? edgeNode = v.Edges.Head;
            while (edgeNode != null)
            {
                if (edgeNode.Data.DestCode == dest) return true;
                edgeNode = edgeNode.Next;
            }
            return false;
        }

        private Vertex? FindVertex(string code)
        {
            Node<Vertex>? n = vertices.Head;
            while (n != null)
            {
                if (n.Data.Code == code) return n.Data;
                n = n.Next;
            }
            return null;
        }

        // Get all neighbors of a given airport 
        public MyLinkedList<string> GetNeighbors(string airportCode)
        {
            var neighbors = new MyLinkedList<string>();
            var vertex = FindVertex(airportCode);
            if (vertex == null) return neighbors;

            Node<Edge>? edgeNode = vertex.Edges.Head;
            while (edgeNode != null)
            {
                neighbors.AddLast(edgeNode.Data.DestCode);
                edgeNode = edgeNode.Next;
            }
            return neighbors;
        }

        // Remove airport and all its edges (for cascade delete)
        public void RemoveAirport(string airportCode)
        {
            // Remove the vertex itself
            var vertex = FindVertex(airportCode);
            if (vertex != null)
            {
                vertices.Remove(vertex);
            }

            // Remove all edges pointing to this airport from other vertices
            Node<Vertex>? vNode = vertices.Head;
            while (vNode != null)
            {
                Node<Edge>? edgeNode = vNode.Data.Edges.Head;
                while (edgeNode != null)
                {
                    if (edgeNode.Data.DestCode == airportCode)
                    {
                        vNode.Data.Edges.Remove(edgeNode.Data);
                        break; // Only one edge per destination
                    }
                    edgeNode = edgeNode.Next;
                }
                vNode = vNode.Next;
            }
        }
    }
}
