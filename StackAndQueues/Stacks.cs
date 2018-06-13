using System;

namespace StackAndQueues
{
   public class Stacks<T>
   {
      private T[] backingStore;
      internal int InitialSize { get; set; }
      public int Count { get; private set; }
      internal int Head { get; set; }
      public Stacks(int size = 0)
      {
         InitialSize = size <= 0 ? 4 : size;

         backingStore = new T[InitialSize];
      }

      public void Push(T item)
      {
         backingStore[Head++] = item;
         Count++;

         CheckResize();
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
      public T Pop()
      {
         var itemToReturn = Peek();
         backingStore[Head--] = default(T);
         --Count;
         CheckResize();

         return itemToReturn;
      }

      public T Peek()
      {
         if (Count == 0)
         {
            throw new InvalidOperationException();
         }

         return backingStore[Head - 1];
      }
   }
}
