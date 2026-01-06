using FlightBookingSystem.Models;

namespace FlightBookingSystem.Core.DataStructures
{
    /// Hash Table implementation for Booking lookup
    public class MyHashTable
    {
        private class Entry
        {
            public string Key;
            public Booking Value;
            public Entry? Next; 
            public Entry(string k, Booking v) { Key = k; Value = v; }
        }

        private Entry?[] buckets;
        private int size;

        public MyHashTable(int capacity = 100)
        {
            buckets = new Entry?[capacity];
            size = capacity;
        }

        private int GetHash(string key)
        {
            ulong hash = 5381;
            foreach (char c in key) hash = ((hash << 5) + hash) + c;
            return (int)(hash % (ulong)size);
        }

        public void Insert(string key, Booking value)
        {
            int idx = GetHash(key);
            Entry newEntry = new Entry(key, value);
            
            if (buckets[idx] == null)
            {
                buckets[idx] = newEntry;
            }
            else
            {
                Entry current = buckets[idx]!;
                while (current.Next != null)
                {
                    if (current.Key == key) { current.Value = value; return; }
                    current = current.Next;
                }
                if (current.Key == key) current.Value = value;
                else current.Next = newEntry;
            }
        }

        public Booking? Search(string key)
        {
            int idx = GetHash(key);
            Entry? current = buckets[idx];
            while (current != null)
            {
                if (current.Key == key) return current.Value;
                current = current.Next;
            }
            return null;
        }
    }
}
