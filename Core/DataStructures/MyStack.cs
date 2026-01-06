using System;

namespace FlightBookingSystem.Core.DataStructures
{
    /// Array-based Stack implementation
    public class MyStack<T>
    {
        private T[] buffer;
        private int top;

        public MyStack(int capacity = 100)
        {
            buffer = new T[capacity];
            top = -1;
        }

        public void Push(T item)
        {
            if (top == buffer.Length - 1) Resize();
            buffer[++top] = item;
        }

        public T Pop()
        {
            if (top == -1) throw new InvalidOperationException("Stack empty");
            return buffer[top--];
        }

        public T Peek()
        {
            if (top == -1) throw new InvalidOperationException("Stack empty");
            return buffer[top];
        }

        private void Resize()
        {
            T[] newBuffer = new T[buffer.Length * 2];
            for (int i = 0; i <= top; i++) newBuffer[i] = buffer[i];
            buffer = newBuffer;
        }
    }
}
