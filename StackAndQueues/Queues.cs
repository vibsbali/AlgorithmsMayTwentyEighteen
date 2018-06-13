using System;
using System.Collections.Specialized;

namespace StackAndQueues
{
   public class Queues<T>
   {
      private T[] backingStore;
      public int InitialSize { get; private set; }
      private int Head { get; set; } = 0;
      private int Tail { get; set; } = 0;

      public int Count { get; private set; }
      public Queues(int size = 0)
      {
         InitialSize = size <= 4 ? 4 : size;

         backingStore = new T[InitialSize];
      }

      public T Dequeue()
      {
         if (Count == 0)
         {
            throw new InvalidOperationException("Can't call dequeue on empty queue");
         }

         var itemToReturn = Peek();
         backingStore[Head] = default(T);
         --Count;

         UpdateHead();
         return itemToReturn;
      }

      private void UpdateHead()
      {
         if (Head == backingStore.Length - 1)
         {
            Head = 0;
         }
         else
         {
            Head = Head + 1;
         }
      }

      public void Enqueue(T item)
      {
         backingStore[Tail] = item;
         Count++;
         UpdateTail();
      }

      private void UpdateTail()
      {  
         //Have reached the end
         if (Tail == backingStore.Length - 1)
         {
            //Have exhausted the array
            if (Count == backingStore.Length)
            {
               var temp = new T[Count * 2];
               Array.Copy(backingStore, temp, backingStore.Length);
               backingStore = temp;
            }
            //Still room
            else
            {
               Tail = 0;
               return;
            }
         }
         //We were wrapped 
         else if (Tail == Head - 1)
         {
            var temp = new T[Count * 2];
            Array.Copy(backingStore, Head, temp, 0, backingStore.Length - Head);
            Array.Copy(backingStore, 0, temp, backingStore.Length - Head + 1, Tail + 1);
            backingStore = temp;
            Head = 0;
            Tail++;
            return;
         }

         Tail++;
      }

      public T Peek()
      {
         return backingStore[Head];
      }

      private void CheckResize()
      {
         if (Head == backingStore.Length - 1)
         {
            //Using rotor methodology
            backingStore = GenerateResizedBackingStore(backingStore.Length * 2, Count);
         }
         // ReSharper disable once CompareOfFloatsByEqualityOperator
         else if (backingStore.Length > InitialSize && Count <= (0.33 * backingStore.Length))
         {
            backingStore = GenerateResizedBackingStore(Convert.ToInt32(Math.Round(backingStore.Length * 0.5)), Count);
         }
      }

      private T[] GenerateResizedBackingStore(int newSize, int numberOfElements)
      {
         var temp = new T[newSize];
         Array.Copy(backingStore, 0, temp, 0, numberOfElements);

         return temp;
      }
   }
}
