using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
   public class QuickSort<T>
      where T : IComparable<T>
   {
      private readonly T[] array;

      public QuickSort(T[] array)
      {

         this.array = array;
      }

      public void Sort()
      {
         SortRecursively(array, 0, array.Length - 1);
      }

      private void SortRecursively(T[] arrayToBeSorted, int lo, int hi)
      {
         if (hi <= lo)
         {
            return;
         }

         var pivot = lo;
         var origHi = hi;

         while (true)
         {
            while (lo + 1 < hi && arrayToBeSorted[pivot].CompareTo(arrayToBeSorted[lo + 1]) >= 0)
            {
               lo++;
            }

            while (hi > lo && (arrayToBeSorted[pivot].CompareTo(arrayToBeSorted[hi]) < 0))
            {
               hi--;
            }

            if (hi > lo)
            {
               arrayToBeSorted.Swap(lo, hi);
            }
            else if (hi == lo)
            {
               arrayToBeSorted.Swap(pivot, hi - 1);
            }
            
            SortRecursively(arrayToBeSorted, pivot, hi - 1);
            SortRecursively(arrayToBeSorted, hi, origHi);
         }
      }
   }
}
