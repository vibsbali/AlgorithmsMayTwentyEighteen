using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("TestProject")]

namespace LinkedList
{
    public class SinglyLinkedList<T> : ICollection<T>
    {
        internal class Node
        {
            public Node(T value)
            {
                Value = value;
            }
            public T Value { get; }
            public Node Next { get; set; }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        internal Node Head { get; private set; }
        internal Node Tail { get; private set; }


        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            var nodeToAdd = new Node(item);
            if (Tail == null)
            {
                Head = Tail = nodeToAdd;
            }
            else
            {
                Tail.Next = nodeToAdd;
                Tail = nodeToAdd;
            }

            ++Count;
        }

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                array[arrayIndex++] = currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        public bool Remove(T item)
        {
            var currentNode = Head;
            Node previous = null;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    //first item could be head
                    if (currentNode == Head)
                    {
                        //Only one item 
                        if (Head == Tail)
                        {
                            Clear();
                        }
                        else
                        {
                            Head = currentNode.Next;
                        }
                    } //item is tail
                    else if (currentNode == Tail)
                    {
                        Tail = previous;
                        Debug.Assert(Tail != null, nameof(Tail) + " != null");
                        Tail.Next = null;
                    }
                    else
                    {
                        Debug.Assert(previous != null, nameof(previous) + " != null");
                        previous.Next = currentNode.Next;
                    }

                    --Count;
                    return true;
                }

                previous = currentNode;
                currentNode = currentNode.Next;
            }

            return false;
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;
    }
}
