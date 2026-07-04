using System.Xml;

namespace _09_CustomLinkedList;

public interface ILinkedList<T> : ICollection<T>
{
    void AddToEnd(T item);
    void AddToFront(T item);
}


