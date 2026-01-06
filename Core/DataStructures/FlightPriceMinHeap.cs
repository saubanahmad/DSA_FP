using System;
using FlightBookingSystem.Models;

namespace FlightBookingSystem.Core.DataStructures
{
    /// Min Heap for sorting flights by price
    public class FlightPriceMinHeap
    {
        private Flight[] heap;
        private int size;

        public FlightPriceMinHeap(int capacity = 100)
        {
            heap = new Flight[capacity];
            size = 0;
        }

        public int Count => size;
        public bool IsEmpty => size == 0;

        public void Insert(Flight flight)
        {
            if (size == heap.Length) Resize();
            heap[size] = flight;
            HeapifyUp(size);
            size++;
        }

        public Flight ExtractMin()
        {
            if (size == 0) throw new InvalidOperationException("Heap is empty");
            Flight minFlight = heap[0];
            heap[0] = heap[size - 1];
            size--;
            if (size > 0) HeapifyDown(0);
            return minFlight;
        }

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

        private void Swap(int i, int j)
        {
            Flight temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        private void Resize()
        {
            Array.Resize(ref heap, heap.Length * 2);
        }
    }
}
