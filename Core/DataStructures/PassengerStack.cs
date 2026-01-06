using System;
using FlightBookingSystem.Models;

namespace FlightBookingSystem.Core.DataStructures
{
    public class PassengerStack
    {
        private Passenger[] buffer;
        private int top;

        public PassengerStack(int capacity = 50)
        {
            buffer = new Passenger[capacity];
            top = -1;
        }

        public int Count => top + 1;
        public bool IsEmpty => top == -1;

        public void Push(Passenger passenger)
        {
            if (top == buffer.Length - 1) Resize();
            buffer[++top] = passenger;
        }

        public Passenger Pop()
        {
            if (top == -1) throw new InvalidOperationException("Stack is empty - No passengers to undo");
            return buffer[top--];
        }

        public Passenger Peek()
        {
            if (top == -1) throw new InvalidOperationException("Stack is empty");
            return buffer[top];
        }

        public void Clear()
        {
            top = -1;
        }

        private void Resize()
        {
            Passenger[] newBuffer = new Passenger[buffer.Length * 2];
            for (int i = 0; i <= top; i++) newBuffer[i] = buffer[i];
            buffer = newBuffer;
        }
    }
}
