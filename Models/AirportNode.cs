using System;

namespace FlightBookingSystem.Models
{
    public class AirportNode
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public AirportNode(string code, string name, int x, int y)
        {
            Code = code ?? "";
            Name = name ?? "";
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
        {
            if (obj is AirportNode other)
                return Code == other.Code;
            return false;
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Code} - {Name}";
        }
    }
}
