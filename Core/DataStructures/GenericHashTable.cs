using System;

namespace FlightBookingSystem.Core.DataStructures
{
    // Generic Hash Table implementation for key-value storage
    public class GenericHashTable<TKey, TValue> where TKey : notnull
    {
        private class Entry
        {
            public TKey Key;
            public TValue Value;
            public Entry? Next;

            public Entry(TKey key, TValue value)
            {
                Key = key;
                Value = value;
                Next = null;
            }
        }

        private Entry?[] buckets;
        private int size;
        private int count;

        public int Count => count;

        public GenericHashTable(int capacity = 100)
        {
            buckets = new Entry?[capacity];
            size = capacity;
            count = 0;
        }

        private int GetHash(TKey key)
        {
            int hash = key.GetHashCode();
            return Math.Abs(hash % size); // will generate an integer non negative hash code that fits in array
        }

        public void Insert(TKey key, TValue value)
        {
            int idx = GetHash(key);
            Entry newEntry = new Entry(key, value);

            if (buckets[idx] == null)
            {
                buckets[idx] = newEntry;
                count++;
            }
            else
            {
                Entry current = buckets[idx]!;
                while (true)
                {
                    if (current.Key.Equals(key))
                    {
                        current.Value = value; // Update existing
                        return;
                    }
                    if (current.Next == null)
                    {
                        current.Next = newEntry;
                        count++;
                        return;
                    }
                    current = current.Next;
                }
            }
        }
        //Index 0: A → null
        //Index 1: null
        //Index 2: B → F → null
        //Index 3: null
        //Index 4: null

        public TValue? Get(TKey key)
        {
            int idx = GetHash(key); // convert key to hash
            Entry? current = buckets[idx]; // goto that bucket

            while (current != null) // traverse the list
            {
                if (current.Key.Equals(key))
                    return current.Value;
                current = current.Next;
            }

            return default(TValue);
        }

        public bool ContainsKey(TKey key)
        {
            int idx = GetHash(key);
            Entry? current = buckets[idx];

            while (current != null)
            {
                if (current.Key.Equals(key))
                    return true;
                current = current.Next;
            }

            return false;
        }

        public bool Remove(TKey key)
        {
            int idx = GetHash(key);
            Entry? current = buckets[idx];
            Entry? prev = null;

            while (current != null)
            {
                if (current.Key.Equals(key))
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
        // Get all keys in the hash table
        public TKey[] GetAllKeys()
        {
            TKey[] keys = new TKey[count];
            int index = 0;

            for (int i = 0; i < size; i++)
            {
                Entry? current = buckets[i];
                while (current != null)
                {
                    keys[index++] = current.Key;
                    current = current.Next;
                }
            }

            return keys;
        }
        // Get all values in the hash table
        public TValue[] GetAllValues()
        {
            TValue[] values = new TValue[count];
            int index = 0;

            for (int i = 0; i < size; i++)
            {
                Entry? current = buckets[i];
                while (current != null)
                {
                    values[index++] = current.Value;
                    current = current.Next;
                }
            }

            return values;
        }
        // Indexer for convenient access
        public TValue this[TKey key]
        {
            get
            {
                TValue? value = Get(key);
                if (value == null)
                    throw new Exception($"Key not found: {key}");
                return value;
            }
            set
            {
                Insert(key, value);
            }
        }
        // Clear all entries
        public void Clear()
        {
            buckets = new Entry?[size];
            count = 0;
        }
    }
}
