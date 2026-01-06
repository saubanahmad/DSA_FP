using System;

namespace FlightBookingSystem.Core.DataStructures
{
    /// Linked Node-based Queue implementation
    public class MyQueue<T>
    {
        private Node<T>? front;
        private Node<T>? rear;
        public int Count;

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (rear == null)
            {
                front = rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }
            Count++;
        }

        public T Dequeue()
        {
            if (front == null) throw new InvalidOperationException("Queue empty");
            T data = front.Data;
            front = front.Next;
            if (front == null) rear = null;
            Count--;
            return data;
        }

        public bool IsEmpty()
        {
            return front == null;
        }
    }
}
