using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        private DoublyNode Head { get; set; }
        private DoublyNode Tail { get; set; }

        protected class DoublyNode
        {
            internal T Value { get; }
            internal DoublyNode Next { get; set; }
            internal DoublyNode Previous { get; set; }

            public DoublyNode(T value)
            {
                Value = value;
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            var nodeToAdd = new DoublyNode(item);
            if (Head == null)
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
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;
    }
}
