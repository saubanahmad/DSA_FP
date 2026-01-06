using System;

namespace FlightBookingSystem.Core.DataStructures
{
// distance based
    public class DijkstraMinHeap<TNode> where TNode : class
    {
        // Inner class to store node-distance pairs
        private class HeapNode
        {
            public TNode Node;
            public int Distance;

            public HeapNode(TNode node, int distance)
            {
                Node = node;
                Distance = distance;
            }
        }

        private HeapNode[] heap;
        private int size;
        private int capacity;

        public DijkstraMinHeap(int initialCapacity = 100)
        {
            capacity = initialCapacity;
            heap = new HeapNode[capacity];
            size = 0;
        }

        public int Count => size;
        public bool IsEmpty => size == 0;
        public void Insert(TNode node, int distance)
        {
            if (size == capacity)
            {
                Resize();
            }

            HeapNode newNode = new HeapNode(node, distance);
            heap[size] = newNode; // adding at end
            HeapifyUp(size); // moving up2rite position
            size++;
        }//minimum distance 
        public TNode ExtractMin(out int distance)//minimum distance 
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            HeapNode minNode = heap[0];
            distance = minNode.Distance;
            TNode node = minNode.Node;
            // Move last element to root and heapify down
            heap[0] = heap[size - 1];
            heap[size - 1] = null!;
            size--;

            if (size > 0)
            {
                HeapifyDown(0);
            }

            return node;
        }
        public TNode PeekMin(out int distance)
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            distance = heap[0].Distance;
            return heap[0].Node;
        }
        /// Update the distance of a node if it exists in the heap
        public void DecreaseKey(TNode node, int newDistance)
        {
            // Find the node in the heap
            int index = -1;
            for (int i = 0; i < size; i++)
            {
                if (heap[i].Node == node)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                // Node not found, insert it
                Insert(node, newDistance);
                return;
            }

            // Only decrease, not increase
            if (newDistance < heap[index].Distance)
            {
                heap[index].Distance = newDistance;
                HeapifyUp(index);
            }
        }
        public bool Contains(TNode node)
        {
            for (int i = 0; i < size; i++)
            {
                if (heap[i].Node == node)
                {
                    return true;
                }
            }
            return false;
        }
        private void HeapifyUp(int index)
        {
            if (index == 0) return;

            int parentIndex = (index - 1) / 2;

            if (heap[index].Distance < heap[parentIndex].Distance)
            {
                Swap(index, parentIndex);
                HeapifyUp(parentIndex);
            }
        }
        private void HeapifyDown(int index)
        {
            int smallest = index;
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;

            if (leftChild < size && heap[leftChild].Distance < heap[smallest].Distance)
            {
                smallest = leftChild;
            }

            if (rightChild < size && heap[rightChild].Distance < heap[smallest].Distance)
            {
                smallest = rightChild;
            }

            if (smallest != index)
            {
                Swap(index, smallest);
                HeapifyDown(smallest);
            }
        }
        private void Swap(int i, int j)
        {
            HeapNode temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
        private void Resize() // double the size and copy the array there
        {
            capacity *= 2;
            HeapNode[] newHeap = new HeapNode[capacity];
            for (int i = 0; i < size; i++)
            {
                newHeap[i] = heap[i];
            }
            heap = newHeap;
        }
        public void Clear()
        {
            for (int i = 0; i < size; i++)
            {
                heap[i] = null!;
            }
            size = 0;
        }
    }
}
