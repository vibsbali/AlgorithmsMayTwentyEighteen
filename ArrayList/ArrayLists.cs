using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("ArrayListTestProject")]

namespace ArrayList
{
   public class ArrayLists<T> : IList<T>
      where T : IComparable<T>
   {
      private T[] backingStore;
      internal readonly int InitialSize;

      public ArrayLists(int size = 0)
      {
         size = size == 0 ? 4 : size;
         InitialSize = size;

         backingStore = new T[size];
      }

      public IEnumerator<T> GetEnumerator()
      {
         for (var i = 0; i < Count; i++)
         {
            yield return backingStore[i];
         }
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }

      public void Add(T item)
      {
         backingStore[Count++] = item;
         CheckResize();
      }

      private T[] GenerateResizedBackingStore(int newSize, int numberOfElements)
      {
         var temp = new T[newSize];
         Array.Copy(backingStore, 0, temp, 0, numberOfElements);

         return temp;
      }

      public void Clear()
      {
         backingStore = new T[InitialSize];
         Count = 0;
      }

      public bool Contains(T item)
      {
         foreach (var content in backingStore)
         {
            if (content.Equals(item))
            {
               return true;
            }
         }

         return false;
      }

      public void CopyTo(T[] array, int arrayIndex)
      {
         for (int i = 0; i < Count; i++)
         {
            array[arrayIndex++] = backingStore[i];
         }
      }

      public bool Remove(T item)
      {
         var idx = IndexOf(item);
         if (idx != -1)
         {
            RemoveAt(idx);
            return true;
         }

         return false;
      }

      public int Count { get; private set; }

      public bool IsReadOnly => false;

      public int IndexOf(T item)
      {
         for (int i = 0; i < Count; i++)
         {
            if (backingStore[i].CompareTo(item) == 0)
            {
               return i;
            }
         }

         return -1;
      }

      public void Insert(int index, T item)
      {
         if (index >= Count)
         {
            throw new ArgumentOutOfRangeException("Index out of bounds");
         }

         //otherwise insert
         Array.Copy(backingStore, index, backingStore, index + 1, Count - index);
         backingStore[index] = item;

         ++Count;
         CheckResize();
      }

      public void RemoveAt(int index)
      {
         if (index >= Count)
         {
            throw new ArgumentOutOfRangeException("Index out of bounds");
         }

         backingStore[index] = default(T);
         Array.Copy(backingStore, index + 1, backingStore, index, Count - index - 1);
         --Count;

         CheckResize();
      }

      private void CheckResize()
      {
         //Check if it is full
         if (Count == backingStore.Length)
         {
            //Using rotor methodology
            backingStore = GenerateResizedBackingStore(backingStore.Length * 2, Count);
         }

         // ReSharper disable once CompareOfFloatsByEqualityOperator
         else if(backingStore.Length > InitialSize && Count <= (0.33 * backingStore.Length))
         {
            backingStore = GenerateResizedBackingStore(Convert.ToInt32(Math.Round(backingStore.Length * 0.5)), Count);
         }
      }

      public T this[int index]
      {
         get
         {
            if (index >= Count)
            {
               throw new ArgumentOutOfRangeException("Index out of bounds");
            }

            return backingStore[index];
         }

         set => backingStore[index] = value;
      }
   }
}
