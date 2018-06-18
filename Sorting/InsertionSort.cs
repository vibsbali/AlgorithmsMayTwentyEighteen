using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
   public class InsertionSort<T>
      where T : IComparable<T>
   {
      private readonly T[] arrayToBeSorted;

      public InsertionSort(T[] arrayToBeSorted)
      {
         this.arrayToBeSorted = arrayToBeSorted;
      }

      public void Sort()
      {
         for (int i = 1; i < arrayToBeSorted.Length; i++)
         {
            if (arrayToBeSorted[i].CompareTo(arrayToBeSorted[i - 1]) < 0)
            {
               for (int j = i; j > 0; j--)
               {
                  if (arrayToBeSorted[j].CompareTo(arrayToBeSorted[j - 1]) < 0)
                  {
                     arrayToBeSorted.Swap(j, j - 1);
                  }
                  else
                  {
                     break;
                  }
               }
            }
         }
      }
   }
}
