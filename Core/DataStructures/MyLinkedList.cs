namespace FlightBookingSystem.Core.DataStructures
{
    /// Doubly Linked List implementation
    public class MyLinkedList<T>
    {
        public Node<T>? Head;
        public Node<T>? Tail;
        public int Count;

        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                Tail!.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }
            Count++;
        }

        public void Remove(T data)
        {
            Node<T>? current = Head;
            while (current != null)
            {
                if (current.Data!.Equals(data))
                {
                    if (current.Prev != null) current.Prev.Next = current.Next;
                    else Head = current.Next;

                    if (current.Next != null) current.Next.Prev = current.Prev;
                    else Tail = current.Prev;

                    Count--;
                    return;
                }
                current = current.Next;
            }
        }
    }
}
