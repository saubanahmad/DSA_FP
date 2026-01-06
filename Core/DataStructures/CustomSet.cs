using System;

namespace FlightBookingSystem.Core.DataStructures
{
    // Custom Set implementation for unique element storage
    // Replaces HashSet<T>
    // Uses internal hash table for O(1) operations
    public class CustomSet<T> where T : notnull
    {
        private class SetNode
        {
            public T Value;
            public SetNode? Next;

            public SetNode(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private SetNode?[] buckets;
        private int size;
        private int count;

        public int Count => count;

        public CustomSet(int capacity = 100)
        {
            buckets = new SetNode?[capacity];
            size = capacity;
            count = 0;
        }

        private int GetHash(T item)
        {
            int hash = item.GetHashCode();
            return Math.Abs(hash % size);
        }
        /// Add an item to the set (only if not already present)
        public bool Add(T item)
        {
            int idx = GetHash(item);

            if (buckets[idx] == null)
            {
                buckets[idx] = new SetNode(item);
                count++;
                return true;
            }

            SetNode current = buckets[idx]!;
            while (true)
            {
                if (current.Value.Equals(item))
                    return false; // Already exists

                if (current.Next == null)
                {
                    current.Next = new SetNode(item);
                    count++;
                    return true;
                }
                current = current.Next;
            }
        }
        /// Check if item exists in the set
        public bool Contains(T item)
        {
            int idx = GetHash(item);
            SetNode? current = buckets[idx];

            while (current != null)
            {
                if (current.Value.Equals(item))
                    return true;
                current = current.Next;
            }

            return false;
        }
        /// Remove an item from the set
        public bool Remove(T item)
        {
            int idx = GetHash(item);
            SetNode? current = buckets[idx];
            SetNode? prev = null;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (prev == null)
                        buckets[idx] = current.Next;
                    else
                        prev.Next = current.Next;

                    count--;
                    return true;
                }
                prev = current;
                current = current.Next;
            }

            return false;
        }
        /// Clear all items from the set
        public void Clear()
        {
            buckets = new SetNode?[size];
            count = 0;
        }
        /// Get all items as an array
        public T[] ToArray()
        {
            T[] items = new T[count];
            int index = 0;

            for (int i = 0; i < size; i++)
            {
                SetNode? current = buckets[i];
                while (current != null)
                {
                    items[index++] = current.Value;
                    current = current.Next;
                }
            }

            return items;
        }
    }
}
