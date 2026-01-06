using System;
using FlightBookingSystem.Models;

namespace FlightBookingSystem.Core.DataStructures
{
    // Min Heap implementation for Flight (by Price)
    public class MyMinHeap
    {
        private Flight[] heap;
        private int size;

        public MyMinHeap(int capacity = 100)
        {
            heap = new Flight[capacity];
            size = 0;
        }

        public void Insert(Flight f)
        {
            if (size == heap.Length) Resize();
            heap[size] = f;
            HeapifyUp(size);
            size++;
        }

        public Flight ExtractMin()
        {
            if (size == 0) throw new InvalidOperationException("Heap empty");
            Flight min = heap[0];
            heap[0] = heap[size - 1];
            size--;
            HeapifyDown(0);
            return min;
        }

        public bool IsEmpty => size == 0;

        private void HeapifyUp(int index)
        {
            int parent = (index - 1) / 2;
            if (index > 0 && heap[index].Price < heap[parent].Price)
            {
                Swap(index, parent);
                HeapifyUp(parent);
            }
        }

        private void HeapifyDown(int index)
        {
            int smallest = index;
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            if (left < size && heap[left].Price < heap[smallest].Price) smallest = left;
            if (right < size && heap[right].Price < heap[smallest].Price) smallest = right;

            if (smallest != index)
            {
                Swap(index, smallest);
                HeapifyDown(smallest);
            }
        }

        private void Swap(int i, int j) { var temp = heap[i]; heap[i] = heap[j]; heap[j] = temp; }
        private void Resize() { Array.Resize(ref heap, heap.Length * 2); }
    }
}
