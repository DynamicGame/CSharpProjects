using System.Collections;

namespace _09_CustomLinkedList;

public class CustomLinkedList<T> : ILinkedList<T>
{
    public CustomLinkedList()
    {
        Head = null!;
        Tail = null!;
    }
    private Node Head { get; set; }
    private Node Tail { get;  set; }
    private int _count;
    public int Count => _count;

    public bool IsReadOnly => false;

    public void AddToFront(T item)
    {
        var newNode = new Node(item) { Next = Head };
        Head = newNode;

        if (Tail == null)
            Tail = Head;

        _count++;
    }

    public void AddToEnd(T item)
    {
        if (Tail == null)
        {
            Head = Tail = new Node(item);
        }
        else
        {
            Tail.Next = new Node(item);
            Tail = Tail.Next;
        }

        _count++;
    }

    public bool Remove(T item)
    {
        Node? previous = null;
        var current = Head;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, item))
            {
                if (previous == null)
                {
                    Head = current.Next;
                    if (Head == null) Tail = null;
                }
                else
                {
                    previous.Next = current.Next;
                    if (current == Tail) Tail = previous;
                }

                _count--;
                return true;
            }

            previous = current;
            current = current.Next;
        }

        return false;
    }


    public void Add(T item)
    {
        if (Head == null)
        {
            Head = new Node(item);
            Tail = Head;
           
        }
        else
        {
            Tail.Next = new Node(item);
            Tail = Tail.Next;


        }
        _count++;
    }

    public void Clear()
    {
        Head = null!;
        Tail = null!;
        _count = 0;
    }

    public bool Contains(T item)
    {
      
        for (var current = Head; current != null; current = current!.Next)
        {
     

            if (current!.Value!.Equals(item))
            {
                
                return true;
               
            }
            
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if(array is null || array.Length < _count || arrayIndex < 0 || arrayIndex >= array.Length)
        {
            throw new ArgumentException("Invalid array or index.");
        }

        for (var current = Head; current != null; current = current.Next)
        {
            array[arrayIndex++] = current.Value;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for(var current = Head; current != null; current = current.Next)
        {
            yield return current.Value;
        }
    }

   

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node(T value)
        {
            Value = value;
            Next = null!;
        }

    }
}


