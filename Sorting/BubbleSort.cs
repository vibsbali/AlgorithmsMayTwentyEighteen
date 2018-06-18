using System;

namespace Sorting
{
   public class BubbleSort<T>
      where T : IComparable<T>
   {
      private readonly T[] arrayToBeSorted;

      public BubbleSort(T[] arrayToBeSorted)
      {
         this.arrayToBeSorted = arrayToBeSorted;
      }

      public void Sort()
      {
         for (int i = arrayToBeSorted.Length - 1; i > 0; i--)
         {
            var isSorted = true;
            for (int j = 0; j < i; j++)
            {
               if (arrayToBeSorted[j + 1].CompareTo(arrayToBeSorted[j]) < 0)
               {
                  arrayToBeSorted.Swap(j + 1, j);
                  isSorted = false;
               }
            }

            if (isSorted)
            {
               return;
            }
         }
      }
   }
}
