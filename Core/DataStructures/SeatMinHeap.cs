using System;

namespace FlightBookingSystem.Core.DataStructures
{
    public class SeatMinHeap
    {
        private int[] heap;
        private int size;

        public SeatMinHeap(int capacity = 100)
        {
            heap = new int[capacity];
            size = 0;
        }

        public int Count => size;
        public bool IsEmpty => size == 0;

        public void Insert(int seatNumber)
        {
            if (size == heap.Length) Resize();
            heap[size] = seatNumber;
            HeapifyUp(size);
            size++;
        }

        public int ExtractMin()
        {
            if (size == 0) throw new InvalidOperationException("No seats available - Flight is full");
            int minSeat = heap[0];
            heap[0] = heap[size - 1];
            size--;
            if (size > 0) HeapifyDown(0);
            return minSeat;
        }

        private void HeapifyUp(int index)
        {
            int parent = (index - 1) / 2;
            if (index > 0 && heap[index] < heap[parent])
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

            if (left < size && heap[left] < heap[smallest]) smallest = left;
            if (right < size && heap[right] < heap[smallest]) smallest = right;

            if (smallest != index)
            {
                Swap(index, smallest);
                HeapifyDown(smallest);
            }
        }

        private void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        private void Resize()
        {
            Array.Resize(ref heap, heap.Length * 2);
        }
    }
}
