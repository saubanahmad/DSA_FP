namespace FlightBookingSystem.Models
{
    /// Used for pathfinding results with Dijkstra's algorithm
    public class PathResult
    {
        public string[] Path { get; set; }
        public int TotalDistance { get; set; }

        public int StopCount { get; set; }

        public bool IsShortestPath { get; set; }

        public PathResult()
        {
            Path = new string[0];
            TotalDistance = 0;
            StopCount = 0;
            IsShortestPath = false;
        }

        public PathResult(string[] path, int totalDistance)
        {
            Path = path;
            TotalDistance = totalDistance;
            StopCount = path.Length - 1;
            IsShortestPath = false;
        }
    }
}
